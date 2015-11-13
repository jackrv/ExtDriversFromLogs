namespace ExtDriversFromLogs
{
    partial class options
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(options));
            this.btnSave = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.grpOptions = new System.Windows.Forms.GroupBox();
            this.chckCCase = new System.Windows.Forms.CheckBox();
            this.chckByTag = new System.Windows.Forms.CheckBox();
            this.chckByID = new System.Windows.Forms.CheckBox();
            this.grpLang = new System.Windows.Forms.GroupBox();
            this.cmbLang = new System.Windows.Forms.ComboBox();
            this.tabAdv = new System.Windows.Forms.TabPage();
            this.btnRestore = new System.Windows.Forms.Button();
            this.grpRegLine = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAttention = new System.Windows.Forms.Label();
            this.txtRegLine = new System.Windows.Forms.TextBox();
            this.tabControl.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.grpOptions.SuspendLayout();
            this.grpLang.SuspendLayout();
            this.tabAdv.SuspendLayout();
            this.grpRegLine.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(5, 208);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(290, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabMain);
            this.tabControl.Controls.Add(this.tabAdv);
            this.tabControl.Location = new System.Drawing.Point(5, 8);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(290, 194);
            this.tabControl.TabIndex = 2;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.grpOptions);
            this.tabMain.Controls.Add(this.grpLang);
            this.tabMain.Location = new System.Drawing.Point(4, 22);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabMain.Size = new System.Drawing.Size(282, 168);
            this.tabMain.TabIndex = 0;
            this.tabMain.Text = "Main";
            this.tabMain.UseVisualStyleBackColor = true;
            // 
            // grpOptions
            // 
            this.grpOptions.Controls.Add(this.chckCCase);
            this.grpOptions.Controls.Add(this.chckByTag);
            this.grpOptions.Controls.Add(this.chckByID);
            this.grpOptions.Location = new System.Drawing.Point(6, 59);
            this.grpOptions.Name = "grpOptions";
            this.grpOptions.Size = new System.Drawing.Size(270, 71);
            this.grpOptions.TabIndex = 1;
            this.grpOptions.TabStop = false;
            this.grpOptions.Text = "Search options";
            // 
            // chckCCase
            // 
            this.chckCCase.AutoSize = true;
            this.chckCCase.Location = new System.Drawing.Point(6, 42);
            this.chckCCase.Name = "chckCCase";
            this.chckCCase.Size = new System.Drawing.Size(147, 17);
            this.chckCCase.TabIndex = 2;
            this.chckCCase.Text = "Case sensitive characters";
            this.chckCCase.UseVisualStyleBackColor = true;
            this.chckCCase.CheckedChanged += new System.EventHandler(this.chckCCase_CheckedChanged);
            // 
            // chckByTag
            // 
            this.chckByTag.AutoSize = true;
            this.chckByTag.Location = new System.Drawing.Point(144, 19);
            this.chckByTag.Name = "chckByTag";
            this.chckByTag.Size = new System.Drawing.Size(96, 17);
            this.chckByTag.TabIndex = 1;
            this.chckByTag.Text = "Search by Tag";
            this.chckByTag.UseVisualStyleBackColor = true;
            this.chckByTag.CheckedChanged += new System.EventHandler(this.chckByTag_CheckedChanged);
            // 
            // chckByID
            // 
            this.chckByID.AutoSize = true;
            this.chckByID.Location = new System.Drawing.Point(6, 19);
            this.chckByID.Name = "chckByID";
            this.chckByID.Size = new System.Drawing.Size(88, 17);
            this.chckByID.TabIndex = 0;
            this.chckByID.Text = "Search by ID";
            this.chckByID.UseVisualStyleBackColor = true;
            this.chckByID.CheckedChanged += new System.EventHandler(this.chckByID_CheckedChanged);
            // 
            // grpLang
            // 
            this.grpLang.Controls.Add(this.cmbLang);
            this.grpLang.Location = new System.Drawing.Point(6, 6);
            this.grpLang.Name = "grpLang";
            this.grpLang.Size = new System.Drawing.Size(270, 47);
            this.grpLang.TabIndex = 0;
            this.grpLang.TabStop = false;
            this.grpLang.Text = "Language";
            // 
            // cmbLang
            // 
            this.cmbLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLang.FormattingEnabled = true;
            this.cmbLang.Location = new System.Drawing.Point(6, 19);
            this.cmbLang.Name = "cmbLang";
            this.cmbLang.Size = new System.Drawing.Size(258, 21);
            this.cmbLang.TabIndex = 0;
            this.cmbLang.SelectedIndexChanged += new System.EventHandler(this.cmbLang_SelectedIndexChanged);
            // 
            // tabAdv
            // 
            this.tabAdv.Controls.Add(this.btnRestore);
            this.tabAdv.Controls.Add(this.grpRegLine);
            this.tabAdv.Location = new System.Drawing.Point(4, 22);
            this.tabAdv.Name = "tabAdv";
            this.tabAdv.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdv.Size = new System.Drawing.Size(282, 168);
            this.tabAdv.TabIndex = 1;
            this.tabAdv.Text = "Advanced";
            this.tabAdv.UseVisualStyleBackColor = true;
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(160, 139);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(116, 23);
            this.btnRestore.TabIndex = 1;
            this.btnRestore.Text = "Restore parameters";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // grpRegLine
            // 
            this.grpRegLine.Controls.Add(this.label1);
            this.grpRegLine.Controls.Add(this.lblAttention);
            this.grpRegLine.Controls.Add(this.txtRegLine);
            this.grpRegLine.Location = new System.Drawing.Point(8, 6);
            this.grpRegLine.Name = "grpRegLine";
            this.grpRegLine.Size = new System.Drawing.Size(268, 61);
            this.grpRegLine.TabIndex = 0;
            this.grpRegLine.TabStop = false;
            this.grpRegLine.Text = "Regular expression line";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(14, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "*";
            // 
            // lblAttention
            // 
            this.lblAttention.AutoSize = true;
            this.lblAttention.ForeColor = System.Drawing.Color.Red;
            this.lblAttention.Location = new System.Drawing.Point(24, 42);
            this.lblAttention.Name = "lblAttention";
            this.lblAttention.Size = new System.Drawing.Size(201, 13);
            this.lblAttention.TabIndex = 1;
            this.lblAttention.Text = "Do not modify unless you know what it is!";
            // 
            // txtRegLine
            // 
            this.txtRegLine.Location = new System.Drawing.Point(6, 19);
            this.txtRegLine.Name = "txtRegLine";
            this.txtRegLine.Size = new System.Drawing.Size(256, 20);
            this.txtRegLine.TabIndex = 0;
            this.txtRegLine.Enter += new System.EventHandler(this.txtRegLine_Enter);
            // 
            // options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 234);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "options";
            this.Text = "options";
            this.Load += new System.EventHandler(this.options_Load);
            this.tabControl.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.grpOptions.ResumeLayout(false);
            this.grpOptions.PerformLayout();
            this.grpLang.ResumeLayout(false);
            this.tabAdv.ResumeLayout(false);
            this.grpRegLine.ResumeLayout(false);
            this.grpRegLine.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabMain;
        private System.Windows.Forms.TabPage tabAdv;
        private System.Windows.Forms.GroupBox grpRegLine;
        private System.Windows.Forms.TextBox txtRegLine;
        private System.Windows.Forms.GroupBox grpLang;
        private System.Windows.Forms.ComboBox cmbLang;
        private System.Windows.Forms.GroupBox grpOptions;
        private System.Windows.Forms.CheckBox chckByTag;
        private System.Windows.Forms.CheckBox chckByID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAttention;
        private System.Windows.Forms.CheckBox chckCCase;
        private System.Windows.Forms.Button btnRestore;

    }
}