﻿namespace WindowsFormsApplication2
{
    partial class Form1
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.passwordLB = new System.Windows.Forms.Label();
            this.passwordTB = new System.Windows.Forms.TextBox();
            this.emailCheck = new System.Windows.Forms.CheckBox();
            this.startButton = new System.Windows.Forms.Button();
            this.locationButton = new System.Windows.Forms.Button();
            this.companyTB = new System.Windows.Forms.TextBox();
            this.locationTB = new System.Windows.Forms.TextBox();
            this.saveButtton = new System.Windows.Forms.Button();
            this.pathTYCB = new System.Windows.Forms.ComboBox();
            this.smtpLB = new System.Windows.Forms.Label();
            this.pathTyLB = new System.Windows.Forms.Label();
            this.userTB = new System.Windows.Forms.TextBox();
            this.logLB = new System.Windows.Forms.Label();
            this.directoryTB = new System.Windows.Forms.TextBox();
            this.emailFRLB = new System.Windows.Forms.Label();
            this.emailToTB = new System.Windows.Forms.TextBox();
            this.emailToLB = new System.Windows.Forms.Label();
            this.emailFTB = new System.Windows.Forms.TextBox();
            this.directoryLB = new System.Windows.Forms.Label();
            this.logTB = new System.Windows.Forms.TextBox();
            this.userLB = new System.Windows.Forms.Label();
            this.smtpTB = new System.Windows.Forms.TextBox();
            this.companyLB = new System.Windows.Forms.Label();
            this.backupStatusTitle = new System.Windows.Forms.Label();
            this.backupStatus = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBox = new System.Windows.Forms.RichTextBox();
            this.fileListB = new System.Windows.Forms.ListBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(707, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(319, 523);
            this.tabControl1.TabIndex = 25;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.backupStatus);
            this.tabPage1.Controls.Add(this.backupStatusTitle);
            this.tabPage1.Controls.Add(this.passwordLB);
            this.tabPage1.Controls.Add(this.passwordTB);
            this.tabPage1.Controls.Add(this.emailCheck);
            this.tabPage1.Controls.Add(this.startButton);
            this.tabPage1.Controls.Add(this.locationButton);
            this.tabPage1.Controls.Add(this.companyTB);
            this.tabPage1.Controls.Add(this.locationTB);
            this.tabPage1.Controls.Add(this.saveButtton);
            this.tabPage1.Controls.Add(this.pathTYCB);
            this.tabPage1.Controls.Add(this.smtpLB);
            this.tabPage1.Controls.Add(this.pathTyLB);
            this.tabPage1.Controls.Add(this.userTB);
            this.tabPage1.Controls.Add(this.logLB);
            this.tabPage1.Controls.Add(this.directoryTB);
            this.tabPage1.Controls.Add(this.emailFRLB);
            this.tabPage1.Controls.Add(this.emailToTB);
            this.tabPage1.Controls.Add(this.emailToLB);
            this.tabPage1.Controls.Add(this.emailFTB);
            this.tabPage1.Controls.Add(this.directoryLB);
            this.tabPage1.Controls.Add(this.logTB);
            this.tabPage1.Controls.Add(this.userLB);
            this.tabPage1.Controls.Add(this.smtpTB);
            this.tabPage1.Controls.Add(this.companyLB);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(311, 497);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Configuration";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // passwordLB
            // 
            this.passwordLB.AutoSize = true;
            this.passwordLB.ForeColor = System.Drawing.SystemColors.Desktop;
            this.passwordLB.Location = new System.Drawing.Point(234, 283);
            this.passwordLB.MinimumSize = new System.Drawing.Size(10, 10);
            this.passwordLB.Name = "passwordLB";
            this.passwordLB.Size = new System.Drawing.Size(53, 13);
            this.passwordLB.TabIndex = 28;
            this.passwordLB.Text = "Password";
            // 
            // passwordTB
            // 
            this.passwordTB.ForeColor = System.Drawing.SystemColors.Desktop;
            this.passwordTB.Location = new System.Drawing.Point(151, 276);
            this.passwordTB.MinimumSize = new System.Drawing.Size(10, 10);
            this.passwordTB.Name = "passwordTB";
            this.passwordTB.Size = new System.Drawing.Size(78, 20);
            this.passwordTB.TabIndex = 4;
            // 
            // emailCheck
            // 
            this.emailCheck.AutoSize = true;
            this.emailCheck.Location = new System.Drawing.Point(11, 168);
            this.emailCheck.Name = "emailCheck";
            this.emailCheck.Size = new System.Drawing.Size(136, 17);
            this.emailCheck.TabIndex = 26;
            this.emailCheck.Text = "Enable Eamil Reporting";
            this.emailCheck.UseVisualStyleBackColor = true;
            this.emailCheck.CheckedChanged += new System.EventHandler(this.emailCheck_CheckedChanged);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(216, 221);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 13;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // locationButton
            // 
            this.locationButton.ForeColor = System.Drawing.SystemColors.Desktop;
            this.locationButton.Location = new System.Drawing.Point(178, 328);
            this.locationButton.MinimumSize = new System.Drawing.Size(10, 10);
            this.locationButton.Name = "locationButton";
            this.locationButton.Size = new System.Drawing.Size(69, 23);
            this.locationButton.TabIndex = 7;
            this.locationButton.Text = "location";
            this.locationButton.UseVisualStyleBackColor = true;
            this.locationButton.Click += new System.EventHandler(this.locationButton_Click);
            // 
            // companyTB
            // 
            this.companyTB.ForeColor = System.Drawing.SystemColors.Desktop;
            this.companyTB.Location = new System.Drawing.Point(11, 250);
            this.companyTB.MinimumSize = new System.Drawing.Size(10, 10);
            this.companyTB.Name = "companyTB";
            this.companyTB.Size = new System.Drawing.Size(161, 20);
            this.companyTB.TabIndex = 2;
            // 
            // locationTB
            // 
            this.locationTB.ForeColor = System.Drawing.SystemColors.Desktop;
            this.locationTB.Location = new System.Drawing.Point(11, 328);
            this.locationTB.MinimumSize = new System.Drawing.Size(10, 10);
            this.locationTB.Name = "locationTB";
            this.locationTB.Size = new System.Drawing.Size(163, 20);
            this.locationTB.TabIndex = 6;
            this.locationTB.TextChanged += new System.EventHandler(this.locationTB_TextChanged);
            // 
            // saveButtton
            // 
            this.saveButtton.ForeColor = System.Drawing.SystemColors.Desktop;
            this.saveButtton.Location = new System.Drawing.Point(14, 221);
            this.saveButtton.MinimumSize = new System.Drawing.Size(10, 10);
            this.saveButtton.Name = "saveButtton";
            this.saveButtton.Size = new System.Drawing.Size(75, 23);
            this.saveButtton.TabIndex = 1;
            this.saveButtton.Text = "Save";
            this.saveButtton.UseVisualStyleBackColor = true;
            this.saveButtton.Click += new System.EventHandler(this.saveButtton_Click);
            // 
            // pathTYCB
            // 
            this.pathTYCB.ForeColor = System.Drawing.SystemColors.Desktop;
            this.pathTYCB.FormattingEnabled = true;
            this.pathTYCB.Items.AddRange(new object[] {
            "DISK",
            "NETWORKPATH",
            "VOLUME ",
            "VOLUMEPATH",
            " "});
            this.pathTYCB.Location = new System.Drawing.Point(11, 301);
            this.pathTYCB.MinimumSize = new System.Drawing.Size(10, 0);
            this.pathTYCB.Name = "pathTYCB";
            this.pathTYCB.Size = new System.Drawing.Size(161, 21);
            this.pathTYCB.TabIndex = 5;
            this.pathTYCB.SelectedIndexChanged += new System.EventHandler(this.pathTYCB_SelectedIndexChanged);
            // 
            // smtpLB
            // 
            this.smtpLB.AutoSize = true;
            this.smtpLB.ForeColor = System.Drawing.SystemColors.Desktop;
            this.smtpLB.Location = new System.Drawing.Point(178, 433);
            this.smtpLB.MinimumSize = new System.Drawing.Size(10, 10);
            this.smtpLB.Name = "smtpLB";
            this.smtpLB.Size = new System.Drawing.Size(37, 13);
            this.smtpLB.TabIndex = 20;
            this.smtpLB.Text = "SMTP";
            // 
            // pathTyLB
            // 
            this.pathTyLB.AutoSize = true;
            this.pathTyLB.ForeColor = System.Drawing.SystemColors.Desktop;
            this.pathTyLB.Location = new System.Drawing.Point(179, 304);
            this.pathTyLB.MinimumSize = new System.Drawing.Size(10, 10);
            this.pathTyLB.Name = "pathTyLB";
            this.pathTyLB.Size = new System.Drawing.Size(56, 13);
            this.pathTyLB.TabIndex = 19;
            this.pathTyLB.Text = "Path Type";
            // 
            // userTB
            // 
            this.userTB.ForeColor = System.Drawing.SystemColors.Desktop;
            this.userTB.Location = new System.Drawing.Point(11, 276);
            this.userTB.MinimumSize = new System.Drawing.Size(10, 10);
            this.userTB.Name = "userTB";
            this.userTB.Size = new System.Drawing.Size(78, 20);
            this.userTB.TabIndex = 3;
            // 
            // logLB
            // 
            this.logLB.AutoSize = true;
            this.logLB.ForeColor = System.Drawing.SystemColors.Desktop;
            this.logLB.Location = new System.Drawing.Point(183, 385);
            this.logLB.MinimumSize = new System.Drawing.Size(10, 10);
            this.logLB.Name = "logLB";
            this.logLB.Size = new System.Drawing.Size(44, 13);
            this.logLB.TabIndex = 18;
            this.logLB.Text = "Log File";
            // 
            // directoryTB
            // 
            this.directoryTB.ForeColor = System.Drawing.SystemColors.Desktop;
            this.directoryTB.Location = new System.Drawing.Point(11, 352);
            this.directoryTB.MinimumSize = new System.Drawing.Size(10, 10);
            this.directoryTB.Name = "directoryTB";
            this.directoryTB.Size = new System.Drawing.Size(161, 20);
            this.directoryTB.TabIndex = 8;
            // 
            // emailFRLB
            // 
            this.emailFRLB.AutoSize = true;
            this.emailFRLB.ForeColor = System.Drawing.SystemColors.Desktop;
            this.emailFRLB.Location = new System.Drawing.Point(180, 407);
            this.emailFRLB.MinimumSize = new System.Drawing.Size(10, 10);
            this.emailFRLB.Name = "emailFRLB";
            this.emailFRLB.Size = new System.Drawing.Size(58, 13);
            this.emailFRLB.TabIndex = 17;
            this.emailFRLB.Text = "Email From";
            // 
            // emailToTB
            // 
            this.emailToTB.ForeColor = System.Drawing.SystemColors.Desktop;
            this.emailToTB.Location = new System.Drawing.Point(11, 453);
            this.emailToTB.MinimumSize = new System.Drawing.Size(10, 10);
            this.emailToTB.Name = "emailToTB";
            this.emailToTB.Size = new System.Drawing.Size(161, 20);
            this.emailToTB.TabIndex = 12;
            // 
            // emailToLB
            // 
            this.emailToLB.AutoSize = true;
            this.emailToLB.ForeColor = System.Drawing.SystemColors.Desktop;
            this.emailToLB.Location = new System.Drawing.Point(176, 456);
            this.emailToLB.MinimumSize = new System.Drawing.Size(10, 10);
            this.emailToLB.Name = "emailToLB";
            this.emailToLB.Size = new System.Drawing.Size(48, 13);
            this.emailToLB.TabIndex = 16;
            this.emailToLB.Text = "Email To";
            // 
            // emailFTB
            // 
            this.emailFTB.ForeColor = System.Drawing.SystemColors.Desktop;
            this.emailFTB.Location = new System.Drawing.Point(11, 404);
            this.emailFTB.MinimumSize = new System.Drawing.Size(10, 10);
            this.emailFTB.Name = "emailFTB";
            this.emailFTB.Size = new System.Drawing.Size(161, 20);
            this.emailFTB.TabIndex = 10;
            // 
            // directoryLB
            // 
            this.directoryLB.AutoSize = true;
            this.directoryLB.ForeColor = System.Drawing.SystemColors.Desktop;
            this.directoryLB.Location = new System.Drawing.Point(178, 359);
            this.directoryLB.MinimumSize = new System.Drawing.Size(10, 10);
            this.directoryLB.Name = "directoryLB";
            this.directoryLB.Size = new System.Drawing.Size(66, 13);
            this.directoryLB.TabIndex = 15;
            this.directoryLB.Text = "App Director";
            // 
            // logTB
            // 
            this.logTB.ForeColor = System.Drawing.SystemColors.Desktop;
            this.logTB.Location = new System.Drawing.Point(11, 378);
            this.logTB.MinimumSize = new System.Drawing.Size(10, 10);
            this.logTB.Name = "logTB";
            this.logTB.Size = new System.Drawing.Size(161, 20);
            this.logTB.TabIndex = 9;
            // 
            // userLB
            // 
            this.userLB.AutoSize = true;
            this.userLB.ForeColor = System.Drawing.SystemColors.Desktop;
            this.userLB.Location = new System.Drawing.Point(95, 283);
            this.userLB.MinimumSize = new System.Drawing.Size(10, 10);
            this.userLB.Name = "userLB";
            this.userLB.Size = new System.Drawing.Size(57, 13);
            this.userLB.TabIndex = 14;
            this.userLB.Text = "UserName";
            // 
            // smtpTB
            // 
            this.smtpTB.ForeColor = System.Drawing.SystemColors.Desktop;
            this.smtpTB.Location = new System.Drawing.Point(11, 430);
            this.smtpTB.MinimumSize = new System.Drawing.Size(10, 10);
            this.smtpTB.Name = "smtpTB";
            this.smtpTB.Size = new System.Drawing.Size(161, 20);
            this.smtpTB.TabIndex = 11;
            // 
            // companyLB
            // 
            this.companyLB.AutoSize = true;
            this.companyLB.ForeColor = System.Drawing.SystemColors.Desktop;
            this.companyLB.Location = new System.Drawing.Point(178, 253);
            this.companyLB.MinimumSize = new System.Drawing.Size(10, 10);
            this.companyLB.Name = "companyLB";
            this.companyLB.Size = new System.Drawing.Size(51, 13);
            this.companyLB.TabIndex = 13;
            this.companyLB.Text = "Company";
            // 
            // backupStatusTitle
            // 
            this.backupStatusTitle.AutoSize = true;
            this.backupStatusTitle.Location = new System.Drawing.Point(11, 104);
            this.backupStatusTitle.Name = "backupStatusTitle";
            this.backupStatusTitle.Size = new System.Drawing.Size(80, 13);
            this.backupStatusTitle.TabIndex = 29;
            this.backupStatusTitle.Text = "Backup Status:";
            this.backupStatusTitle.Click += new System.EventHandler(this.label1_Click);
            // 
            // backupStatus
            // 
            this.backupStatus.AutoSize = true;
            this.backupStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backupStatus.Location = new System.Drawing.Point(97, 104);
            this.backupStatus.Name = "backupStatus";
            this.backupStatus.Size = new System.Drawing.Size(40, 22);
            this.backupStatus.TabIndex = 30;
            this.backupStatus.Text = "N/A";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.fileListB);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(311, 497);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Logs";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(12, 12);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(687, 514);
            this.textBox.TabIndex = 26;
            this.textBox.Text = "";
            // 
            // fileListB
            // 
            this.fileListB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileListB.FormattingEnabled = true;
            this.fileListB.ItemHeight = 16;
            this.fileListB.Location = new System.Drawing.Point(4, 7);
            this.fileListB.Name = "fileListB";
            this.fileListB.Size = new System.Drawing.Size(304, 484);
            this.fileListB.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1039, 531);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button locationButton;
        private System.Windows.Forms.TextBox companyTB;
        private System.Windows.Forms.TextBox locationTB;
        private System.Windows.Forms.Button saveButtton;
        private System.Windows.Forms.ComboBox pathTYCB;
        private System.Windows.Forms.Label smtpLB;
        private System.Windows.Forms.Label pathTyLB;
        private System.Windows.Forms.TextBox userTB;
        private System.Windows.Forms.Label logLB;
        private System.Windows.Forms.TextBox directoryTB;
        private System.Windows.Forms.Label emailFRLB;
        private System.Windows.Forms.TextBox emailToTB;
        private System.Windows.Forms.Label emailToLB;
        private System.Windows.Forms.TextBox emailFTB;
        private System.Windows.Forms.Label directoryLB;
        private System.Windows.Forms.TextBox logTB;
        private System.Windows.Forms.Label userLB;
        private System.Windows.Forms.TextBox smtpTB;
        private System.Windows.Forms.Label companyLB;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.CheckBox emailCheck;
        private System.Windows.Forms.Label passwordLB;
        private System.Windows.Forms.TextBox passwordTB;
        private System.Windows.Forms.Label backupStatusTitle;
        private System.Windows.Forms.Label backupStatus;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox textBox;
        private System.Windows.Forms.ListBox fileListB;
    }
}

