namespace WindowsFormsApplication1
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
            this.saveButton = new System.Windows.Forms.Button();
            this.backupTypeLable = new System.Windows.Forms.Label();
            this.backupLocationLabel = new System.Windows.Forms.Label();
            this.usernameLable = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.backupTypeTB = new System.Windows.Forms.TextBox();
            this.backupLocationTB = new System.Windows.Forms.TextBox();
            this.usernameTB = new System.Windows.Forms.TextBox();
            this.passwordTB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(197, 226);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "StartBackup";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(13, 226);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Save Config";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // backupTypeLable
            // 
            this.backupTypeLable.AutoSize = true;
            this.backupTypeLable.Location = new System.Drawing.Point(13, 13);
            this.backupTypeLable.Name = "backupTypeLable";
            this.backupTypeLable.Size = new System.Drawing.Size(68, 13);
            this.backupTypeLable.TabIndex = 2;
            this.backupTypeLable.Text = "BackupType";
            this.backupTypeLable.Click += new System.EventHandler(this.label1_Click);
            // 
            // backupLocationLabel
            // 
            this.backupLocationLabel.AutoSize = true;
            this.backupLocationLabel.Location = new System.Drawing.Point(13, 53);
            this.backupLocationLabel.Name = "backupLocationLabel";
            this.backupLocationLabel.Size = new System.Drawing.Size(88, 13);
            this.backupLocationLabel.TabIndex = 3;
            this.backupLocationLabel.Text = "Backup Location";
            // 
            // usernameLable
            // 
            this.usernameLable.AutoSize = true;
            this.usernameLable.Location = new System.Drawing.Point(13, 92);
            this.usernameLable.Name = "usernameLable";
            this.usernameLable.Size = new System.Drawing.Size(55, 13);
            this.usernameLable.TabIndex = 4;
            this.usernameLable.Text = "Username";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(13, 131);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(53, 13);
            this.passwordLabel.TabIndex = 5;
            this.passwordLabel.Text = "Password";
            // 
            // backupTypeTB
            // 
            this.backupTypeTB.Location = new System.Drawing.Point(13, 30);
            this.backupTypeTB.Name = "backupTypeTB";
            this.backupTypeTB.Size = new System.Drawing.Size(259, 20);
            this.backupTypeTB.TabIndex = 6;
            // 
            // backupLocationTB
            // 
            this.backupLocationTB.Location = new System.Drawing.Point(13, 69);
            this.backupLocationTB.Name = "backupLocationTB";
            this.backupLocationTB.Size = new System.Drawing.Size(259, 20);
            this.backupLocationTB.TabIndex = 7;
            // 
            // usernameTB
            // 
            this.usernameTB.Location = new System.Drawing.Point(16, 108);
            this.usernameTB.Name = "usernameTB";
            this.usernameTB.Size = new System.Drawing.Size(259, 20);
            this.usernameTB.TabIndex = 8;
            // 
            // passwordTB
            // 
            this.passwordTB.Location = new System.Drawing.Point(16, 147);
            this.passwordTB.Name = "passwordTB";
            this.passwordTB.Size = new System.Drawing.Size(259, 20);
            this.passwordTB.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.passwordTB);
            this.Controls.Add(this.usernameTB);
            this.Controls.Add(this.backupLocationTB);
            this.Controls.Add(this.backupTypeTB);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.usernameLable);
            this.Controls.Add(this.backupLocationLabel);
            this.Controls.Add(this.backupTypeLable);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.startButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label backupTypeLable;
        private System.Windows.Forms.Label backupLocationLabel;
        private System.Windows.Forms.Label usernameLable;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox backupTypeTB;
        private System.Windows.Forms.TextBox backupLocationTB;
        private System.Windows.Forms.TextBox usernameTB;
        private System.Windows.Forms.TextBox passwordTB;
    }
}

