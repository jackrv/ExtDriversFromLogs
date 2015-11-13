using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ExtDriversFromLogs
{
    public partial class options : Form
    {
        Dictionary<int, Lang> languages = new Dictionary<int, Lang>();
        private struct Lang
        {
            public string name;
            public XmlDocument xml;
        }

        public options()
        {
            InitializeComponent();
            getLangFiles();
        }

        private void setText (Control control, XmlNode node)
        {
            if (node != null)
                control.Text = node.InnerText;
        }

        private void localize(XmlDocument xml = null)
        {
            if (xml == null)
                xml = Properties.Settings.Default.Language;
            
            setText(this,               xml.SelectSingleNode("/Language/mainForm/btnOptions"));
            setText(this.tabMain,       xml.SelectSingleNode("/Language/optionsForm/tabMain"));
            setText(this.tabAdv,        xml.SelectSingleNode("/Language/optionsForm/tabAdv"));
            setText(this.grpLang,       xml.SelectSingleNode("/Language/optionsForm/groupLanguage"));
            setText(this.grpOptions,    xml.SelectSingleNode("/Language/optionsForm/groupOptionSearch"));
            setText(this.chckByID,      xml.SelectSingleNode("/Language/optionsForm/chckById"));
            setText(this.chckByTag,     xml.SelectSingleNode("/Language/optionsForm/chckByTag"));
            setText(this.chckCCase,     xml.SelectSingleNode("/Language/optionsForm/chckCCase"));
            setText(this.btnSave,       xml.SelectSingleNode("/Language/optionsForm/btnSave"));
            setText(this.grpRegLine,    xml.SelectSingleNode("/Language/optionsForm/groupRegLine"));
            setText(this.lblAttention,  xml.SelectSingleNode("/Language/optionsForm/lblRegAttention"));
            setText(this.btnRestore,    xml.SelectSingleNode("/Language/optionsForm/btnRestore"));
        }

        private void addLanguages(string language, string file, XmlDocument xml)
        {
            Lang myLang = new Lang();
            int count   = languages.Count;
            myLang.name = language;
            myLang.xml  = xml;
            languages.Add(count, myLang);
            cmbLang.Items.Add(language);
            if (language == Properties.Settings.Default.Language.SelectSingleNode("/Language/@name").Value)
                cmbLang.SelectedIndex = count;
        }

        private void getLangFiles()
        {
            string langDir = Directory.GetCurrentDirectory() + "\\lang";

            if (Directory.Exists(langDir))
            {
                string[] allLanguages = Directory.GetFiles(langDir, "*.xml");
                foreach (string file in allLanguages)
                {
                    XmlDocument xdoc = new XmlDocument();
                    xdoc.LoadXml(File.ReadAllText(file, Encoding.UTF8));

                    addLanguages(xdoc.SelectSingleNode("/Language/@name").Value, file, xdoc);

                    cmbLang.Enabled = true;
                }
            }
            else
                cmbLang.Enabled = false;
        }

        private void options_Load(object sender, EventArgs e)
        {
            this.Location       = new Point(Properties.Settings.Default.windowPositon.X + 150, Properties.Settings.Default.windowPositon.Y + 30);
            txtRegLine.Text     = Properties.Settings.Default.regPattern;
            chckByID.Checked    = Properties.Settings.Default.chckSearchByID;
            chckByTag.Checked   = Properties.Settings.Default.chckSearchByTag;
            chckCCase.Checked   = Properties.Settings.Default.chckCCase;
        }

        private void cmbLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Language = languages[cmbLang.SelectedIndex].xml;
            localize(languages[cmbLang.SelectedIndex].xml);
        }

        private void chckByID_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.chckSearchByID = chckByID.Checked;
        }

        private void chckByTag_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.chckSearchByTag = chckByTag.Checked;
        }

        private void chckCCase_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.chckCCase = chckCCase.Checked;
        }

        private void txtRegLine_Enter(object sender, EventArgs e)
        {
            string errorMsg = Properties.Settings.Default.Language.SelectSingleNode("/Language/messages/msgEnterToRegLine") != null ? Properties.Settings.Default.Language.SelectSingleNode("/Language/messages/msgEnterToRegLine").InnerText : "Attention, this string can break the program!";
            MessageBox.Show(errorMsg);
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            XmlDocument xdoc    = new XmlDocument();
            xdoc.LoadXml(Properties.Settings.Default.Properties["Language"].DefaultValue as string);
            Properties.Settings.Default.Language        = xdoc;

            Properties.Settings.Default.txtSearchLine   = Properties.Settings.Default.Properties["txtSearchLine"].DefaultValue as string;

            string[] pos        = (Properties.Settings.Default.Properties["windowPositon"].DefaultValue as string).Split(',');
            Properties.Settings.Default.windowPositon   = new Point(int.Parse(pos[0]), int.Parse(pos[1]));

            string[] size       = (Properties.Settings.Default.Properties["windowSize"].DefaultValue as string).Split(',');
            Properties.Settings.Default.windowSize      = new Size(int.Parse(size[0]), int.Parse(size[1]));

            Properties.Settings.Default.chckCCase       = bool.Parse(Properties.Settings.Default.Properties["chckCCase"].DefaultValue as string);
            Properties.Settings.Default.chckSearchByID  = bool.Parse(Properties.Settings.Default.Properties["chckSearchByID"].DefaultValue as string);
            Properties.Settings.Default.chckSearchByTag = bool.Parse(Properties.Settings.Default.Properties["chckSearchByTag"].DefaultValue as string);
            Properties.Settings.Default.regPattern      = Properties.Settings.Default.Properties["regPattern"].DefaultValue as string;
            txtRegLine.Text     = Properties.Settings.Default.regPattern;

            localize();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.regPattern = txtRegLine.Text;

            Properties.Settings.Default.Save();
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
