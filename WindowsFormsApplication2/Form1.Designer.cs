namespace WindowsFormsApplication2
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
            this.startButton = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.RichTextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.selDirectoBox = new System.Windows.Forms.TextBox();
            this.directoryLabel = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.companyTB = new System.Windows.Forms.TextBox();
            this.credTB = new System.Windows.Forms.TextBox();
            this.directoryTB = new System.Windows.Forms.TextBox();
            this.emailToTB = new System.Windows.Forms.TextBox();
            this.emailFRTB = new System.Windows.Forms.TextBox();
            this.logTB = new System.Windows.Forms.TextBox();
            this.smtpTB = new System.Windows.Forms.TextBox();
            this.companyLB = new System.Windows.Forms.Label();
            this.credLB = new System.Windows.Forms.Label();
            this.directoryLB = new System.Windows.Forms.Label();
            this.emailToLB = new System.Windows.Forms.Label();
            this.emailFRLB = new System.Windows.Forms.Label();
            this.logLB = new System.Windows.Forms.Label();
            this.pathTyLB = new System.Windows.Forms.Label();
            this.smtpLB = new System.Windows.Forms.Label();
            this.pathTYCB = new System.Windows.Forms.ComboBox();
            this.saveButtton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(311, 41);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(12, 219);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(687, 307);
            this.textBox.TabIndex = 1;
            this.textBox.Text = "";
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(311, 12);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 2;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // selDirectoBox
            // 
            this.selDirectoBox.Location = new System.Drawing.Point(26, 29);
            this.selDirectoBox.Name = "selDirectoBox";
            this.selDirectoBox.Size = new System.Drawing.Size(279, 20);
            this.selDirectoBox.TabIndex = 3;
            this.selDirectoBox.TextChanged += new System.EventHandler(this.seldirectoryBox_TextChanged);
            // 
            // directoryLabel
            // 
            this.directoryLabel.AutoSize = true;
            this.directoryLabel.Location = new System.Drawing.Point(26, 10);
            this.directoryLabel.Name = "directoryLabel";
            this.directoryLabel.Size = new System.Drawing.Size(49, 13);
            this.directoryLabel.TabIndex = 4;
            this.directoryLabel.Text = "Directory";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // companyTB
            // 
            this.companyTB.Location = new System.Drawing.Point(29, 91);
            this.companyTB.Name = "companyTB";
            this.companyTB.Size = new System.Drawing.Size(161, 20);
            this.companyTB.TabIndex = 5;
            // 
            // credTB
            // 
            this.credTB.Location = new System.Drawing.Point(29, 117);
            this.credTB.Name = "credTB";
            this.credTB.Size = new System.Drawing.Size(161, 20);
            this.credTB.TabIndex = 6;
            // 
            // directoryTB
            // 
            this.directoryTB.Location = new System.Drawing.Point(29, 143);
            this.directoryTB.Name = "directoryTB";
            this.directoryTB.Size = new System.Drawing.Size(161, 20);
            this.directoryTB.TabIndex = 7;
            // 
            // emailToTB
            // 
            this.emailToTB.Location = new System.Drawing.Point(29, 169);
            this.emailToTB.Name = "emailToTB";
            this.emailToTB.Size = new System.Drawing.Size(161, 20);
            this.emailToTB.TabIndex = 8;
            // 
            // emailFRTB
            // 
            this.emailFRTB.Location = new System.Drawing.Point(363, 91);
            this.emailFRTB.Name = "emailFRTB";
            this.emailFRTB.Size = new System.Drawing.Size(161, 20);
            this.emailFRTB.TabIndex = 10;
            // 
            // logTB
            // 
            this.logTB.Location = new System.Drawing.Point(363, 117);
            this.logTB.Name = "logTB";
            this.logTB.Size = new System.Drawing.Size(161, 20);
            this.logTB.TabIndex = 11;
            // 
            // smtpTB
            // 
            this.smtpTB.Location = new System.Drawing.Point(363, 169);
            this.smtpTB.Name = "smtpTB";
            this.smtpTB.Size = new System.Drawing.Size(161, 20);
            this.smtpTB.TabIndex = 12;
            // 
            // companyLB
            // 
            this.companyLB.AutoSize = true;
            this.companyLB.Location = new System.Drawing.Point(207, 91);
            this.companyLB.Name = "companyLB";
            this.companyLB.Size = new System.Drawing.Size(51, 13);
            this.companyLB.TabIndex = 13;
            this.companyLB.Text = "Company";
            // 
            // credLB
            // 
            this.credLB.AutoSize = true;
            this.credLB.Location = new System.Drawing.Point(207, 120);
            this.credLB.Name = "credLB";
            this.credLB.Size = new System.Drawing.Size(59, 13);
            this.credLB.TabIndex = 14;
            this.credLB.Text = "Credentials";
            // 
            // directoryLB
            // 
            this.directoryLB.AutoSize = true;
            this.directoryLB.Location = new System.Drawing.Point(207, 146);
            this.directoryLB.Name = "directoryLB";
            this.directoryLB.Size = new System.Drawing.Size(49, 13);
            this.directoryLB.TabIndex = 15;
            this.directoryLB.Text = "Directory";
            // 
            // emailToLB
            // 
            this.emailToLB.AutoSize = true;
            this.emailToLB.Location = new System.Drawing.Point(207, 172);
            this.emailToLB.Name = "emailToLB";
            this.emailToLB.Size = new System.Drawing.Size(76, 13);
            this.emailToLB.TabIndex = 16;
            this.emailToLB.Text = "Send Email To";
            // 
            // emailFRLB
            // 
            this.emailFRLB.AutoSize = true;
            this.emailFRLB.Location = new System.Drawing.Point(553, 94);
            this.emailFRLB.Name = "emailFRLB";
            this.emailFRLB.Size = new System.Drawing.Size(54, 13);
            this.emailFRLB.TabIndex = 17;
            this.emailFRLB.Text = "email from";
            // 
            // logLB
            // 
            this.logLB.AutoSize = true;
            this.logLB.Location = new System.Drawing.Point(553, 117);
            this.logLB.Name = "logLB";
            this.logLB.Size = new System.Drawing.Size(25, 13);
            this.logLB.TabIndex = 18;
            this.logLB.Text = "Log";
            // 
            // pathTyLB
            // 
            this.pathTyLB.AutoSize = true;
            this.pathTyLB.Location = new System.Drawing.Point(553, 150);
            this.pathTyLB.Name = "pathTyLB";
            this.pathTyLB.Size = new System.Drawing.Size(56, 13);
            this.pathTyLB.TabIndex = 19;
            this.pathTyLB.Text = "Path Type";
            // 
            // smtpLB
            // 
            this.smtpLB.AutoSize = true;
            this.smtpLB.Location = new System.Drawing.Point(553, 176);
            this.smtpLB.Name = "smtpLB";
            this.smtpLB.Size = new System.Drawing.Size(61, 13);
            this.smtpLB.TabIndex = 20;
            this.smtpLB.Text = "smtp server";
            // 
            // pathTYCB
            // 
            this.pathTYCB.FormattingEnabled = true;
            this.pathTYCB.Location = new System.Drawing.Point(363, 143);
            this.pathTYCB.Name = "pathTYCB";
            this.pathTYCB.Size = new System.Drawing.Size(161, 21);
            this.pathTYCB.TabIndex = 21;
            this.pathTYCB.SelectedIndexChanged += new System.EventHandler(this.pathTYCB_SelectedIndexChanged);
            // 
            // saveButtton
            // 
            this.saveButtton.Location = new System.Drawing.Point(392, 12);
            this.saveButtton.Name = "saveButtton";
            this.saveButtton.Size = new System.Drawing.Size(75, 23);
            this.saveButtton.TabIndex = 22;
            this.saveButtton.Text = "Save";
            this.saveButtton.UseVisualStyleBackColor = true;
            this.saveButtton.Click += new System.EventHandler(this.saveButtton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 538);
            this.Controls.Add(this.saveButtton);
            this.Controls.Add(this.pathTYCB);
            this.Controls.Add(this.smtpLB);
            this.Controls.Add(this.pathTyLB);
            this.Controls.Add(this.logLB);
            this.Controls.Add(this.emailFRLB);
            this.Controls.Add(this.emailToLB);
            this.Controls.Add(this.directoryLB);
            this.Controls.Add(this.credLB);
            this.Controls.Add(this.companyLB);
            this.Controls.Add(this.smtpTB);
            this.Controls.Add(this.logTB);
            this.Controls.Add(this.emailFRTB);
            this.Controls.Add(this.emailToTB);
            this.Controls.Add(this.directoryTB);
            this.Controls.Add(this.credTB);
            this.Controls.Add(this.companyTB);
            this.Controls.Add(this.directoryLabel);
            this.Controls.Add(this.selDirectoBox);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.startButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.RichTextBox textBox;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.TextBox selDirectoBox;
        private System.Windows.Forms.Label directoryLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox companyTB;
        private System.Windows.Forms.TextBox credTB;
        private System.Windows.Forms.TextBox directoryTB;
        private System.Windows.Forms.TextBox emailToTB;
        private System.Windows.Forms.TextBox emailFRTB;
        private System.Windows.Forms.TextBox logTB;
        private System.Windows.Forms.TextBox smtpTB;
        private System.Windows.Forms.Label companyLB;
        private System.Windows.Forms.Label credLB;
        private System.Windows.Forms.Label directoryLB;
        private System.Windows.Forms.Label emailToLB;
        private System.Windows.Forms.Label emailFRLB;
        private System.Windows.Forms.Label logLB;
        private System.Windows.Forms.Label pathTyLB;
        private System.Windows.Forms.Label smtpLB;
        private System.Windows.Forms.ComboBox pathTYCB;
        private System.Windows.Forms.Button saveButtton;
    }
}

