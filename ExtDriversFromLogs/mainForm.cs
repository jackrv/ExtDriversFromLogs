using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ExtDriversFromLogs
{
   
    public partial class mainForm : Form
    {
        string currentLanguage;
        options settings;
        Dictionary<int, Driver> drivers = new Dictionary<int, Driver>();

        private struct Driver
        {
            private string truckName;
            public string time;
            public string name;
            public int gameID;
            public int ets2mpID;
            public string tag;
            public string adData;
            public string adInfo;
            public string truck {
                get
                {
                    return truckName;
                }
                set
                {
                    switch (value)
                    {
                        case "daf.xf_euro6":
                            truckName = "DAF XF Euro 6";
                            break;
                        case "daf.xf":
                            truckName = "DAF XF 105";
                            break;
                        case "iveco.stralis":
                            truckName = "Iveco Stralis";
                            break;
                        case "iveco.hiway":
                            truckName = "Iveco Hi-Way";
                            break;
                        case "man.tgx":
                            truckName = "MAN TGX";
                            break;
                        case "mercedes.actros":
                            truckName = "Mercedes Actros";
                            break;
                        case "mercedes.actros2014":
                            truckName = "Mercedes New Actros";
                            break;
                        case "renault.magnum":
                            truckName = "Renault Magnum";
                            break;
                        case "renault.premium":
                            truckName = "Renault Premium";
                            break;
                        case "scania.r":
                            truckName = "Scania R 2012";
                            break;
                        case "scania.streamline":
                            truckName = "Scania StreamLine";
                            break;
						case "scania.r_2016":
							truckName = "Scania R";
							break;
						case "scania.s_2016":
							truckName = "Scania S";
							break;
                        case "volvo.fh16":
                            truckName = "Volvo FH16 2009";
                            break;
                        case "volvo.fh16_2012":
                            truckName = "Volvo FH16 2012";
                            break;
                        case "skoda.superb":
                            truckName = "Scout Super_D";
                            break;
						case "peterbilt.389":
							truckName = "Peterbilt 389";
							break;
                        case "peterbilt.579":
                            truckName = "Peterbilt 579";
                            break;
                        case "kenworth.t680":
                            truckName = "Kenworth T680";
                            break;
                        case "kenworth.w900":
                            truckName = "Kenworth W900";
                            break;
                    }
                }
            }
        }

        public mainForm()
        {
            
            InitializeComponent();
            localize();
        }

        private void setText(string control, XmlNode node)
        {
            if (node != null)
                control = node.InnerText;
        }

        private void localize()
        {
            currentLanguage                 = Properties.Settings.Default.Language.SelectSingleNode("/Language/@name").Value;
            if (Properties.Settings.Default.Language.SelectSingleNode("/Language/mainForm/colTruck") != null)
                this.columnHeader6.Text         = Properties.Settings.Default.Language.SelectSingleNode("/Language/mainForm/colTruck").InnerText;
            if (Properties.Settings.Default.Language.SelectSingleNode("/Language/mainForm/colTag") != null)
                this.columnHeader5.Text = Properties.Settings.Default.Language.SelectSingleNode("/Language/mainForm/colTag").InnerText;
            if (Properties.Settings.Default.Language.SelectSingleNode("/Language/mainForm/colNickname") != null)
                this.columnHeader2.Text = Properties.Settings.Default.Language.SelectSingleNode("/Language/mainForm/colNickname").InnerText;
            if (Properties.Settings.Default.Language.SelectSingleNode("/Language/mainForm/colGameID") != null)
                this.columnHeader4.Text = Properties.Settings.Default.Language.SelectSingleNode("/Language/mainForm/colGameID").InnerText;
            if (Properties.Settings.Default.Language.SelectSingleNode("/Language/mainForm/btnOpenYesterday") != null)
                this.btnOpenYesterday.Text = Properties.Settings.Default.Language.SelectSingleNode("/Language/mainForm/btnOpenYesterday").InnerText;
            if (Properties.Settings.Default.Language.SelectSingleNode("/Language/mainForm/btnOpenAnother") != null)
                this.btnOpenAnother.Text = Properties.Settings.Default.Language.SelectSingleNode("/Language/mainForm/btnOpenAnother").InnerText;
            if (Properties.Settings.Default.Language.SelectSingleNode("/Language/mainForm/btnExit") != null)
                this.btnExit.Text = Properties.Settings.Default.Language.SelectSingleNode("/Language/mainForm/btnExit").InnerText;
            if (Properties.Settings.Default.Language.SelectSingleNode("/Language/mainForm/btnOptions") != null)
                this.btnOptions.Text = Properties.Settings.Default.Language.SelectSingleNode("/Language/mainForm/btnOptions").InnerText;
            if (Properties.Settings.Default.Language.SelectSingleNode("/Language/mainForm/groupSearch") != null)
                this.grpSearch.Text = Properties.Settings.Default.Language.SelectSingleNode("/Language/mainForm/groupSearch").InnerText;
            if (Properties.Settings.Default.Language.SelectSingleNode("/Language/mainForm/groupOpen") != null)
                this.grpOpen.Text = Properties.Settings.Default.Language.SelectSingleNode("/Language/mainForm/groupOpen").InnerText;
            if (Properties.Settings.Default.Language.SelectSingleNode("/Language/mainForm/btnOpen") != null)
                this.btnOpen.Text = Properties.Settings.Default.Language.SelectSingleNode("/Language/mainForm/btnOpen").InnerText;
            if (Properties.Settings.Default.Language.SelectSingleNode("/Language/mainForm/menuOpenProfile") != null)
                this.drvMenu_OpenProfile.Text = Properties.Settings.Default.Language.SelectSingleNode("/Language/mainForm/menuOpenProfile").InnerText;
            if (Properties.Settings.Default.Language.SelectSingleNode("/Language/mainForm/menuCopyName") != null)
                this.drvMenu_CopyName.Text = Properties.Settings.Default.Language.SelectSingleNode("/Language/mainForm/menuCopyName").InnerText;
            if (Properties.Settings.Default.Language.SelectSingleNode("/Language/mainForm/menuCopyID") != null)
                this.drvMenu_CopyID.Text = Properties.Settings.Default.Language.SelectSingleNode("/Language/mainForm/menuCopyID").InnerText;
            if (Properties.Settings.Default.Language.SelectSingleNode("/Language/mainForm/selectGame") != null)
                this.gameGroup.Text = Properties.Settings.Default.Language.SelectSingleNode("/Language/mainForm/selectGame").InnerText;
        }

        private void openFile(string path)
        {
            drivers.Clear();
            try
            {
                if (File.Exists(path))
                {
                    string file = File.ReadAllText(path, Encoding.Unicode);
                    Regex rgx = new Regex(Properties.Settings.Default.regPattern);
                    foreach (Match match in rgx.Matches(file))
                    {
                        int ets2mpID = int.Parse(match.Groups["ets2mpID"].Value);
                        if (!drivers.ContainsKey(ets2mpID))
                        {
                            string tag = "";
                            if (match.Groups["adInfo"].Value != "")
                            {
                                string[] otherInfo = Regex.Split(match.Groups["adInfo"].Value, @"\s-\s")[1].Split(':');
                                if (otherInfo[0] == "Tag")
                                    tag = otherInfo[1];
                            }

                            Driver driver = new Driver();

                            driver.time = String.Format("{0}:{1}:{2}", match.Groups["tHours"].Value, match.Groups["tMinutes"].Value, match.Groups["tSeconds"].Value);
                            driver.name = match.Groups["name"].Value;
                            driver.gameID = int.Parse(match.Groups["gameID"].Value);
                            driver.ets2mpID = ets2mpID;
                            driver.tag = tag;
                            driver.adData = match.Groups["adData"].Value;
                            driver.truck = match.Groups["truck"].Value;
                            driver.adInfo = match.Groups["adInfo"].Value;

                            drivers.Add(ets2mpID, driver);
                        }
                    }
                    rgx = new Regex(@".*\\log_spawning_(?<day>\d{2}?).(?<month>\d{2}?).(?<year>\d{4}?).log");
                    this.Text = String.Format("ExtDfL - [{0}-{1}-{2}]", rgx.Matches(path)[0].Groups["day"].Value, rgx.Matches(path)[0].Groups["month"].Value, rgx.Matches(path)[0].Groups["year"].Value);

                    load_list();

                }
                else
                {
                    string errorMsg = Properties.Settings.Default.Language.SelectSingleNode("/Language/messages/msgNoFile") != null ? Properties.Settings.Default.Language.SelectSingleNode("/Language/messages/msgNoFile").InnerText : "Log file {0} don't exist!";
                    MessageBox.Show(string.Format(errorMsg, path));
                }
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void load_list()
        {
            lstDrivers.Items.Clear();
            string searchLine   = Properties.Settings.Default.chckCCase ? txtSearch.Text : txtSearch.Text.ToLowerInvariant();
            foreach (KeyValuePair<int, Driver> k in drivers)
            {
                string valName  = Properties.Settings.Default.chckCCase ? k.Value.name : k.Value.name.ToLowerInvariant();
                string valTag   = Properties.Settings.Default.chckCCase ? k.Value.tag : k.Value.tag.ToLowerInvariant();
                string valID    = k.Value.gameID.ToString();

                if ((valName.Contains(searchLine)) || ((valTag.Contains(searchLine)) && (Properties.Settings.Default.chckSearchByTag)) || (valID.Contains(searchLine) && (Properties.Settings.Default.chckSearchByID)))
                {
                    lstDrivers.Items.Add(new ListViewItem(new[] {
                        (lstDrivers.Items.Count + 1).ToString(),
                        k.Value.truck,
                        k.Value.tag,
                        k.Value.name,
                        k.Value.gameID.ToString(),
                        k.Value.ets2mpID.ToString()
                    }));
                }
            }

            lblStat.Text = lstDrivers.Items.Count + " / " + drivers.Count;
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            txtSearch.Text      = Properties.Settings.Default.txtSearchLine;
            this.Size           = Properties.Settings.Default.windowSize;
            this.Location       = Properties.Settings.Default.windowPositon;
            if (Properties.Settings.Default.gameATS)
                radioATS.Checked = true;
            radioETS.Checked = !radioATS.Checked;
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.gameATS         = radioATS.Checked;
            Properties.Settings.Default.txtSearchLine   = txtSearch.Text;
            Properties.Settings.Default.windowPositon   = this.Location;
            Properties.Settings.Default.windowSize      = this.Size;
            Properties.Settings.Default.Save();
        }

        private void mainForm_Resize(object sender, EventArgs e)
        {
            lstDrivers.Columns[3].Width = this.Width - 665;
        }

        private void lstDrivers_DoubleClick(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://truckersmp.com/en_US/user/" + lstDrivers.FocusedItem.SubItems[5].Text);
        }

        private void lstDrivers_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cntxtDriversMenu.Show(this, e.X, e.Y);
            }
        }

        private void drvMenu_CopyName_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lstDrivers.FocusedItem.SubItems[3].Text);
        }

        private void drvMenu_CopyID_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lstDrivers.FocusedItem.SubItems[5].Text);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            load_list();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            string date = DateTime.Now.Date.ToString("dd.MM.yyyy");
            string path = String.Format(((radioETS.Checked)? ("ETS2MP") : ("ATSMP")) + "\\logs\\log_spawning_{0}.log", date);
            string personalDir = Properties.Settings.Default.personalDir == "" ? Environment.GetFolderPath(Environment.SpecialFolder.Personal) : Properties.Settings.Default.personalDir;
            path = personalDir + "\\" + path;
            openFile(path);
        }

        private void btnOther_Click(object sender, EventArgs e)
        {
            cntxtOpenMenu.Show(btnOtherOpen, new Point(0, btnOtherOpen.Height));
        }

        private void btnOpenYesterday_Click(object sender, EventArgs e)
        {
            string date = DateTime.Now.AddDays(-1).ToString("dd.MM.yyyy");
            string path = String.Format(((radioETS.Checked) ? ("ETS2MP") : ("ATSMP")) + "\\logs\\log_spawning_{0}.log", date);
            string personalDir = Properties.Settings.Default.personalDir == "" ? Environment.GetFolderPath(Environment.SpecialFolder.Personal) : Properties.Settings.Default.personalDir;
            path = personalDir + "\\" + path;
            openFile(path);
        }

        private void btnOpenAnother_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = String.Format(((radioETS.Checked) ? ("ETS2MP") : ("ATSMP")) + "\\logs");
            openFileDialog.Filter = "Log files|log_spawning_*.log";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                openFile(openFileDialog.FileName);
            }
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            settings = new options();
            if (settings.ShowDialog() == DialogResult.OK)
            {
                txtSearch.Text = Properties.Settings.Default.txtSearchLine;
                if (currentLanguage != Properties.Settings.Default.Language.SelectSingleNode("/Language/@name").Value)
                    localize();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
