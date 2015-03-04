using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace ExtDriversFromLogs
{
    public partial class Form1 : Form
    {
        string language = "Rus";
        string message_cCase_tooltip = "С учетом регистра";
        string message_errorWriteToReg = "Не удалось сохранить данные в реестр: ";
        string message_errorFileOpen = "Не удалось открыть файл: ";
        string message_errorFileLoad = "Файл логов {0} не обнаружен!";
        Dictionary<string, string> drivers = new Dictionary<string, string>();
        public void openFile(string path)
        {
            listView1.Items.Clear();
            drivers.Clear();
            string t_line = string.Empty;

            if (File.Exists(path))
            {
                string lines = File.ReadAllText(path, Encoding.Default);

                string pattern = @"\[.*\]\sSpawning\sGameTruck\s\((?<name>[\s\S]*?)\s\|\s(?<id>7656119[0-9]{10}$?)\)";

                Regex rgx = new Regex(pattern);
                foreach (Match match in rgx.Matches(lines))
                {
                    if (!drivers.ContainsKey(match.Groups["id"].Value))
                    {
                        drivers.Add(match.Groups["id"].Value, match.Groups["name"].Value);
                    }
                }
                rgx = new Regex(@".*\\log_spawning_(?<date>.*?).log");
                this.Text = "ExtDfL (MP) - [" + rgx.Matches(path)[0].Groups[1].Value.Replace("_", " ") + "]";

                load_list(nameBox.Text);
            }
            else
                MessageBox.Show(string.Format(message_errorFileLoad, path));
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(button2, new Point(0, button2.Height));
        }

        private void openButton1_Click_1(object sender, EventArgs e)
        {
            string personal_dir = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string date = DateTime.Now.Date.ToString("dd_MM_yyyy");
            string path = personal_dir + "\\ETS2MP\\logs\\log_spawning_" + date + ".log";
            openFile(path);
        }

        private void вчераToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string personal_dir = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string date = DateTime.Now.AddDays(-1).ToString("dd_MM_yyyy");
            string path = personal_dir + "\\ETS2MP\\logs\\log_spawning_" + date + ".log";
            openFile(path);
        }

        private void другаяДатаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string md = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog1.InitialDirectory = md + "\\ETS2MP\\logs";
            openFileDialog1.Filter = "Log files|log_spawning_*.log";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string personal_dir = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    string path = openFileDialog1.FileName;
                    openFile(path);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(message_errorFileOpen + ex.Message);
                }
            }
        }

        private void load_list(string tag)
        {
            int i = 0;
            foreach(KeyValuePair<string, string> k in drivers)
            {
                string value = k.Value;
                if (!checkBox1.Checked)
                {
                    tag = tag.ToLowerInvariant();
                    value = k.Value.ToLowerInvariant();
                }

                if (value.Contains(tag))
                {
                    i++;
                    listView1.Items.Add(new ListViewItem(new[] { i.ToString(), k.Value, k.Key }));
                }
                
            }
            label1.Text = i + " / " + drivers.Count;
        }

        private void nameBox_TextChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            load_list(nameBox.Text);
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            Clipboard.SetText(listView1.FocusedItem.SubItems[1].Text + " " + listView1.FocusedItem.SubItems[2].Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Win32.RegistryKey readKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software\\extdfl");
                if (readKey != null)
                {

                    if ((string)readKey.GetValue("cCase") == "True")
                        checkBox1.Checked = true;
                    else
                        checkBox1.Checked = false;

                    nameBox.Text = (string)readKey.GetValue("tag");
                    this.StartPosition = FormStartPosition.Manual;
                    this.Location = new System.Drawing.Point((int)readKey.GetValue("pos_x"), (int)readKey.GetValue("pos_y"));
                    if ((string)readKey.GetValue("lang") == "Eng")
                        changeLang("Eng");
                    else if ((string)readKey.GetValue("lang") == "Ukr")
                        changeLang("Ukr");
                    else
                        changeLang("Rus");
                    readKey.Close();
                }
            }
            catch { }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Microsoft.Win32.RegistryKey saveKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("software\\extdfl");
                saveKey.SetValue("tag", nameBox.Text);
                saveKey.SetValue("cCase", checkBox1.Checked);
                saveKey.SetValue("pos_x", this.Location.X);
                saveKey.SetValue("pos_y", this.Location.Y);
                saveKey.SetValue("lang", language);
                saveKey.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(message_errorWriteToReg + ex.Message);
            }
        }

        private void checkBox1_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip1.Show(message_cCase_tooltip, this.checkBox1);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            load_list(nameBox.Text);
        }

        private void changeLang(string lang)
        {
            switch (lang)
            {
                case "Eng":
                    label3.BorderStyle = label4.BorderStyle = BorderStyle.None;
                    label2.BorderStyle = BorderStyle.Fixed3D;
                    button1.Text = "Exit";
                    groupBox1.Text = "Open log";
                    openButton1.Text = "From today";
                    вчераToolStripMenuItem.Text = "From yesterday";
                    другаяДатаToolStripMenuItem.Text = "Another date";
                    columnHeader2.Text = "Game nickname";
                    message_cCase_tooltip = "Case sensitive characters";
                    message_errorFileOpen = "Don't open file: ";
                    message_errorFileLoad = "Log file {0} don't exist";
                    language = "Eng";

                    break;
                case "Rus":
                    label2.BorderStyle = label4.BorderStyle = BorderStyle.None;
                    label3.BorderStyle = BorderStyle.Fixed3D;
                    button1.Text = "Выход";
                    groupBox1.Text = "Открыть лог";
                    openButton1.Text = "Сегодняшний";
                    вчераToolStripMenuItem.Text = "Вчерашний";
                    другаяДатаToolStripMenuItem.Text = "Другая дата";
                    columnHeader2.Text = "Игровой никнейм";
                    message_cCase_tooltip = "С учетом регистра символов";
                    message_errorFileOpen = "Не удалось открыть файл: ";
                    message_errorFileLoad = "Файл логов {0} не обнаружен!";
                    language = "Rus";
                    break;
                case "Ukr":
                    label2.BorderStyle = label3.BorderStyle = BorderStyle.None;
                    label4.BorderStyle = BorderStyle.Fixed3D;
                    button1.Text = "Вихід";
                    groupBox1.Text = "Відкрити лог";
                    openButton1.Text = "Сьогоднішній";
                    вчераToolStripMenuItem.Text = "Вчорашній";
                    другаяДатаToolStripMenuItem.Text = "Інша дата";
                    columnHeader2.Text = "Ігровий нікнейм";
                    message_cCase_tooltip = "З урахуванням регістру символів";
                    message_errorFileOpen = "Не вдалось відкрити файл: ";
                    message_errorFileLoad = "Файл логів {0} не знайдений!";
                    language = "Ukr";
                    break;
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {
            changeLang("Eng");
        }

        private void label3_Click(object sender, EventArgs e)
        {
            changeLang("Rus");
        }

        private void label4_Click(object sender, EventArgs e)
        {
            changeLang("Ukr");
        }
    }
}
