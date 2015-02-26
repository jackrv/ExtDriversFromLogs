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


/*
 * Test github 
 * Test github
 * Test github
*/
namespace ExtDriversFromLogs
{
    public partial class Form1 : Form
    {
        Dictionary<string, string> drivers = new Dictionary<string, string>();
        public void openFile(string path)
        {
            listView1.Items.Clear();
            drivers.Clear();
            string t_line = string.Empty;

            if (File.Exists(path))
            {
                string lines = File.ReadAllText(path, Encoding.Default);

                string pattern = @"\[.*\]\sSpawning\sGameTrailer\s\((?<name>.*?)\s\|\s(?<id>7656119[0-9]{10}$?)\)";

                Regex rgx = new Regex(pattern);
                foreach (Match match in rgx.Matches(lines))
                {
                    if (!drivers.ContainsKey(match.Groups["id"].Value))
                    {
                        drivers.Add(match.Groups["id"].Value, match.Groups["name"].Value);
                    }
                }
                load_list(nameBox.Text);
                //MessageBox.Show("Найдено " + drivers.Count + " водителей!", "Информация", MessageBoxButtons.OK);
            }
            else
                MessageBox.Show("Файл логов " + path + " не обнаружен!", "Ошибка открытия", MessageBoxButtons.OK);
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
                    MessageBox.Show("Не удалось загрузить файл: " + ex.Message);
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
                string tag = (string)readKey.GetValue("tag");
                string registry = (string)readKey.GetValue("registry");
                int pos_x = (int)readKey.GetValue("pos_x");
                int pos_y = (int)readKey.GetValue("pos_y");
                readKey.Close();
                nameBox.Text = tag;
                if (registry == "True")
                    checkBox1.Checked = true;
                else
                    checkBox1.Checked = false;

                this.Location = new System.Drawing.Point(pos_x, pos_y);
            }
            catch { }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Microsoft.Win32.RegistryKey saveKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("software\\extdfl");
                saveKey.SetValue("tag", nameBox.Text);
                saveKey.SetValue("registry", checkBox1.Checked);
                saveKey.SetValue("pos_x", this.Location.X);
                saveKey.SetValue("pos_y", this.Location.Y);
                saveKey.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось загрузить данные из реестра: " + ex.Message);
            }
        }

        private void checkBox1_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip1.Show("С учетом регистра", this.checkBox1);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            load_list(nameBox.Text);
        }
    }
}
