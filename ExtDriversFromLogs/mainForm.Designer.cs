using System.Xml;
namespace ExtDriversFromLogs
{
    partial class mainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lstDrivers = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cntxtOpenMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnOpenYesterday = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpenAnother = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnOptions = new System.Windows.Forms.Button();
            this.grpSearch = new System.Windows.Forms.GroupBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.grpOpen = new System.Windows.Forms.GroupBox();
            this.lblStat = new System.Windows.Forms.Label();
            this.btnOtherOpen = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.cntxtDriversMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.drvMenu_OpenProfile = new System.Windows.Forms.ToolStripMenuItem();
            this.drvMenu_CopyName = new System.Windows.Forms.ToolStripMenuItem();
            this.drvMenu_CopyID = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cntxtOpenMenu.SuspendLayout();
            this.grpSearch.SuspendLayout();
            this.grpOpen.SuspendLayout();
            this.cntxtDriversMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // lstDrivers
            // 
            this.lstDrivers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstDrivers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader6,
            this.columnHeader5,
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader3});
            this.lstDrivers.FullRowSelect = true;
            this.lstDrivers.Location = new System.Drawing.Point(0, 0);
            this.lstDrivers.Name = "lstDrivers";
            this.lstDrivers.Size = new System.Drawing.Size(622, 261);
            this.lstDrivers.TabIndex = 1;
            this.lstDrivers.UseCompatibleStateImageBehavior = false;
            this.lstDrivers.View = System.Windows.Forms.View.Details;
            this.lstDrivers.DoubleClick += new System.EventHandler(this.lstDrivers_DoubleClick);
            this.lstDrivers.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstDrivers_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "№";
            this.columnHeader1.Width = 30;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Truck";
            this.columnHeader6.Width = 120;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Tag";
            this.columnHeader5.Width = 90;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Game nickname";
            this.columnHeader2.Width = 135;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Game ID";
            this.columnHeader4.Width = 106;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "TruckersMP ID";
            this.columnHeader3.Width = 123;
            // 
            // cntxtOpenMenu
            // 
            this.cntxtOpenMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpenYesterday,
            this.btnOpenAnother});
            this.cntxtOpenMenu.Name = "contextMenuStrip1";
            this.cntxtOpenMenu.ShowImageMargin = false;
            this.cntxtOpenMenu.Size = new System.Drawing.Size(131, 48);
            // 
            // btnOpenYesterday
            // 
            this.btnOpenYesterday.Name = "btnOpenYesterday";
            this.btnOpenYesterday.Size = new System.Drawing.Size(130, 22);
            this.btnOpenYesterday.Text = "From yesterday";
            this.btnOpenYesterday.Click += new System.EventHandler(this.btnOpenYesterday_Click);
            // 
            // btnOpenAnother
            // 
            this.btnOpenAnother.Name = "btnOpenAnother";
            this.btnOpenAnother.Size = new System.Drawing.Size(130, 22);
            this.btnOpenAnother.Text = "Open file";
            this.btnOpenAnother.Click += new System.EventHandler(this.btnOpenAnother_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(628, 226);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(144, 23);
            this.btnExit.TabIndex = 14;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnOptions
            // 
            this.btnOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOptions.Location = new System.Drawing.Point(628, 197);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(144, 23);
            this.btnOptions.TabIndex = 13;
            this.btnOptions.Text = "Options";
            this.btnOptions.UseVisualStyleBackColor = true;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // grpSearch
            // 
            this.grpSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSearch.Controls.Add(this.txtSearch);
            this.grpSearch.Location = new System.Drawing.Point(628, 93);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Size = new System.Drawing.Size(144, 50);
            this.grpSearch.TabIndex = 12;
            this.grpSearch.TabStop = false;
            this.grpSearch.Text = "Search";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(6, 19);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(132, 20);
            this.txtSearch.TabIndex = 12;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // grpOpen
            // 
            this.grpOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpOpen.Controls.Add(this.lblStat);
            this.grpOpen.Controls.Add(this.btnOtherOpen);
            this.grpOpen.Controls.Add(this.btnOpen);
            this.grpOpen.Location = new System.Drawing.Point(628, 12);
            this.grpOpen.Name = "grpOpen";
            this.grpOpen.Size = new System.Drawing.Size(144, 64);
            this.grpOpen.TabIndex = 10;
            this.grpOpen.TabStop = false;
            this.grpOpen.Text = "Open log";
            // 
            // lblStat
            // 
            this.lblStat.AutoSize = true;
            this.lblStat.Location = new System.Drawing.Point(6, 45);
            this.lblStat.Name = "lblStat";
            this.lblStat.Size = new System.Drawing.Size(30, 13);
            this.lblStat.TabIndex = 12;
            this.lblStat.Text = "0 / 0";
            // 
            // btnOtherOpen
            // 
            this.btnOtherOpen.Location = new System.Drawing.Point(122, 19);
            this.btnOtherOpen.Name = "btnOtherOpen";
            this.btnOtherOpen.Size = new System.Drawing.Size(16, 23);
            this.btnOtherOpen.TabIndex = 4;
            this.btnOtherOpen.Text = "▼";
            this.btnOtherOpen.UseVisualStyleBackColor = true;
            this.btnOtherOpen.Click += new System.EventHandler(this.btnOther_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(6, 19);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(129, 23);
            this.btnOpen.TabIndex = 3;
            this.btnOpen.Text = "From today";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // cntxtDriversMenu
            // 
            this.cntxtDriversMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drvMenu_OpenProfile,
            this.drvMenu_CopyName,
            this.drvMenu_CopyID});
            this.cntxtDriversMenu.Name = "contextMenuStrip1";
            this.cntxtDriversMenu.ShowImageMargin = false;
            this.cntxtDriversMenu.Size = new System.Drawing.Size(144, 70);
            // 
            // drvMenu_OpenProfile
            // 
            this.drvMenu_OpenProfile.Name = "drvMenu_OpenProfile";
            this.drvMenu_OpenProfile.Size = new System.Drawing.Size(143, 22);
            this.drvMenu_OpenProfile.Text = "Open profile";
            this.drvMenu_OpenProfile.Click += new System.EventHandler(this.lstDrivers_DoubleClick);
            // 
            // drvMenu_CopyName
            // 
            this.drvMenu_CopyName.Name = "drvMenu_CopyName";
            this.drvMenu_CopyName.Size = new System.Drawing.Size(143, 22);
            this.drvMenu_CopyName.Text = "Copy driver name";
            this.drvMenu_CopyName.Click += new System.EventHandler(this.drvMenu_CopyName_Click);
            // 
            // drvMenu_CopyID
            // 
            this.drvMenu_CopyID.Name = "drvMenu_CopyID";
            this.drvMenu_CopyID.Size = new System.Drawing.Size(143, 22);
            this.drvMenu_CopyID.Text = "Copy ETS2MP ID";
            this.drvMenu_CopyID.Click += new System.EventHandler(this.drvMenu_CopyID_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.AllowDrop = true;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "ETS2MP",
            "ATSMP"});
            this.comboBox1.Location = new System.Drawing.Point(634, 170);
            this.comboBox1.MaxDropDownItems = 2;
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 15;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(656, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Select game";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 261);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnOptions);
            this.Controls.Add(this.grpSearch);
            this.Controls.Add(this.grpOpen);
            this.Controls.Add(this.lstDrivers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 300);
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ExtDfL";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.Resize += new System.EventHandler(this.mainForm_Resize);
            this.cntxtOpenMenu.ResumeLayout(false);
            this.grpSearch.ResumeLayout(false);
            this.grpSearch.PerformLayout();
            this.grpOpen.ResumeLayout(false);
            this.grpOpen.PerformLayout();
            this.cntxtDriversMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ListView lstDrivers;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ToolStripMenuItem btnOpenYesterday;
        private System.Windows.Forms.ToolStripMenuItem btnOpenAnother;
        private System.Windows.Forms.GroupBox grpOpen;
        private System.Windows.Forms.Button btnOtherOpen;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label lblStat;
        private System.Windows.Forms.ContextMenuStrip cntxtOpenMenu;
        private System.Windows.Forms.GroupBox grpSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button btnOptions;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ContextMenuStrip cntxtDriversMenu;
        private System.Windows.Forms.ToolStripMenuItem drvMenu_CopyName;
        private System.Windows.Forms.ToolStripMenuItem drvMenu_CopyID;
        private System.Windows.Forms.ToolStripMenuItem drvMenu_OpenProfile;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
    }
}

