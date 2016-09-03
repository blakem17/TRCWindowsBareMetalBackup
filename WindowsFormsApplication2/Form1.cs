using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Reflection;
using Microsoft.Win32;
using RealClassUpdater.Properties;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using Microsoft.PowerShell.Commands;
using PowerShell = System.Management.Automation.PowerShell;


namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        private const string noSelStr = "Please select a directory";
        private string filelocation = "";
        private string compIdent = "$companyName =";
        private string emToIdent = "$emailTo =";
        private string emFrIdent = "$emailFrom =";
        private string smtpIdent = "$smtpServer =";
        private string pthTpIdent = "$pathType =";
        private string credIdent = "$credential =";
        private string dirIdent = "$directory =";
        private string lgFlIdent = "$logFile =";
        private string locationIdent = "$location =";
        private string passwordIdent = "$password =";
        private string usernameIdent = "$username =";
        private string[] setArr = new string[8];
        public string installDirectory = Registry.CurrentUser.OpenSubKey(@"Software\Blakem\UserChoice").GetValue("InstallDirectory").ToString();


        public Form1()
        {
            InitializeComponent();
            setArr[0] = compIdent;
            setArr[1] = credIdent;
            setArr[2] = dirIdent;
            setArr[3] = emFrIdent;
            setArr[4] = emToIdent;
            setArr[5] = lgFlIdent;
            setArr[6] = pthTpIdent;
            setArr[7] = smtpIdent;
            var scriptlocation = installDirectory + "UserConfig.txt";
            if (!File.Exists(scriptlocation))
            {
                string myfile = Resources.UserConfig;
                File.WriteAllText(scriptlocation, myfile);
                string[] fileTextArr1 = File.ReadAllLines(scriptlocation);
                string joinded = String.Join(Environment.NewLine, fileTextArr1);
                textBox.Text = joinded;
                foreach (string s in fileTextArr1)
                {
                    if (s.Contains(compIdent))
                    {
                        var reg = new Regex("\".*?\"");
                        var matches = reg.Matches(s);
                        foreach (var item in matches)
                        {

                            string u = item.ToString().Replace("\"", "");
                            companyTB.Text = u;

                        }
                    }
                    if (s.Contains(emToIdent))
                    {
                        var reg = new Regex("\".*?\"");
                        var matches = reg.Matches(s);
                        foreach (var item in matches)
                        {

                            string u = item.ToString().Replace("\"", "");
                            emailToTB.Text = u;
                            if (emailToTB.Text.Length > 0)
                            {
                                emailCheck.Checked = true;
                            }
                        }
                    }
                    if (s.Contains(emFrIdent))
                    {
                        var reg = new Regex("\".*?\"");
                        var matches = reg.Matches(s);
                        foreach (var item in matches)
                        {

                            string u = item.ToString().Replace("\"", "");
                            emailFTB.Text = u;
                            if (emailFTB.Text.Length > 0)
                            {
                                emailCheck.Checked = true;
                            }
                        }
                    }
                    if (s.Contains(smtpIdent))
                    {
                        var reg = new Regex("\".*?\"");
                        var matches = reg.Matches(s);
                        foreach (var item in matches)
                        {

                            string u = item.ToString().Replace("\"", "");
                            smtpTB.Text = u;
                            if (smtpTB.Text.Length > 0)
                            {
                                emailCheck.Checked = true;
                            }
                        }
                    }
                    if (s.Contains(pthTpIdent))
                    {
                        var reg = new Regex("\".*?\"");
                        var matches = reg.Matches(s);
                        foreach (var item in matches)
                        {

                            string u = item.ToString().Replace("\"", "");
                            pathTYCB.Text = u;

                        }
                    }
                    if (s.Contains(dirIdent))
                    {
                        var reg = new Regex("\".*?\"");
                        var matches = reg.Matches(s);
                        foreach (var item in matches)
                        {

                            string u = item.ToString().Replace("\"", "");
                            directoryTB.Text = u;

                        }
                    }
                    if (s.Contains(lgFlIdent))
                    {
                        var reg = new Regex("\".*?\"");
                        var matches = reg.Matches(s);
                        foreach (var item in matches)
                        {

                            string u = item.ToString().Replace("\"", "");
                            logTB.Text = u;

                        }
                    }
                    if (s.Contains(locationIdent))
                    {
                        var reg = new Regex("\".*?\"");
                        var matches = reg.Matches(s);
                        foreach (var item in matches)
                        {

                            string u = item.ToString().Replace("\"", "");
                            locationTB.Text = u;

                        }
                    }
                    if (s.Contains(usernameIdent))
                    {
                        var reg = new Regex("\".*?\"");
                        var matches = reg.Matches(s);
                        foreach (var item in matches)
                        {

                            string u = item.ToString().Replace("\"", "");
                            userTB.Text = u;

                        }
                    }
                    if (s.Contains(passwordIdent))
                    {
                        var reg = new Regex("\".*?\"");
                        var matches = reg.Matches(s);
                        foreach (var item in matches)
                        {

                            string u = item.ToString().Replace("\"", "");
                            passwordTB.Text = u;

                        }
                    }

                }
            }
            else
            {
                string[] fileTextArr1 = File.ReadAllLines(scriptlocation);
                string joinded = String.Join(Environment.NewLine, fileTextArr1);
                textBox.Text = joinded;
                foreach (string s in fileTextArr1)
                {
                    if (s.Contains(compIdent))
                    {
                        var reg = new Regex("\".*?\"");
                        var matches = reg.Matches(s);
                        foreach (var item in matches)
                        {

                            string u = item.ToString().Replace("\"", "");
                            companyTB.Text = u;

                        }
                    }
                    if (s.Contains(emToIdent))
                    {
                        var reg = new Regex("\".*?\"");
                        var matches = reg.Matches(s);
                        foreach (var item in matches)
                        {

                            string u = item.ToString().Replace("\"", "");
                            emailToTB.Text = u;
                            if (emailToTB.Text.Length > 0)
                            {
                                emailCheck.Checked = true;
                            }

                        }
                    }
                    if (s.Contains(emFrIdent))
                    {
                        var reg = new Regex("\".*?\"");
                        var matches = reg.Matches(s);
                        foreach (var item in matches)
                        {

                            string u = item.ToString().Replace("\"", "");
                            emailFTB.Text = u;
                            if (emailFTB.Text.Length > 0)
                            {
                                emailCheck.Checked = true;
                            }

                        }
                    }
                    if (s.Contains(smtpIdent))
                    {
                        var reg = new Regex("\".*?\"");
                        var matches = reg.Matches(s);
                        foreach (var item in matches)
                        {

                            string u = item.ToString().Replace("\"", "");
                            smtpTB.Text = u;
                            if (smtpTB.Text.Length > 0)
                            {
                                emailCheck.Checked = true;
                            }

                        }
                    }
                    if (s.Contains(pthTpIdent))
                    {
                        var reg = new Regex("\".*?\"");
                        var matches = reg.Matches(s);
                        foreach (var item in matches)
                        {
                            if (item.ToString().Contains("NETWORKPATH"))
                            {
                                pathTYCB.SelectedIndex = 1;
                            }
                            if (item.ToString().Contains("DISK"))
                            {
                                pathTYCB.SelectedIndex = 0;
                            }
                            if (item.ToString().Contains("VOLUME"))
                            {
                                pathTYCB.SelectedIndex = 2;
                            }
                            if (item.ToString().Contains("VOLUMEPATH"))
                            {
                                pathTYCB.SelectedIndex = 3;
                            }
                            else
                            {
                                pathTYCB.SelectedIndex = 4;
                            }

                        }
                    }
                    if (s.Contains(dirIdent))
                    {
                        var reg = new Regex("\".*?\"");
                        var matches = reg.Matches(s);
                        foreach (var item in matches)
                        {

                            string u = item.ToString().Replace("\"", "");
                            directoryTB.Text = u;

                        }
                        ;
                    }
                    if (s.Contains(lgFlIdent))
                    {
                        var reg = new Regex("\".*?\"");
                        var matches = reg.Matches(s);
                        foreach (var item in matches)
                        {

                            string u = item.ToString().Replace("\"", "");
                            logTB.Text = u;

                        }
                    }
                    if (s.Contains(locationIdent))
                    {
                        var reg = new Regex("\".*?\"");
                        var matches = reg.Matches(s);
                        foreach (var item in matches)
                        {

                            string u = item.ToString().Replace("\"", "");
                            locationTB.Text = u;

                        }
                    }
                    if (s.Contains(usernameIdent))
                    {
                        var reg = new Regex("\".*?\"");
                        var matches = reg.Matches(s);
                        foreach (var item in matches)
                        {

                            string u = item.ToString().Replace("\"", "");
                            userTB.Text = u;

                        }
                    }
                    if (s.Contains(passwordIdent))
                    {
                        var reg = new Regex("\".*?\"");
                        var matches = reg.Matches(s);
                        foreach (var item in matches)
                        {

                            string u = item.ToString().Replace("\"", "");
                            passwordTB.Text = u;

                        }
                    }

                }
            }

        }

        private void seldirectoryBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        private void pathTYCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pathTYCB.SelectedIndex == 1)
            {
                userTB.Enabled = true;
                passwordTB.Enabled = true;
            }
            else
            {
                userTB.Enabled = false;
                passwordTB.Enabled = false;
            }
        }

        private void saveButtton_Click(object sender, EventArgs e)
        {
            string uCompany = companyTB.Text;
            string uDirectory = directoryTB.Text;
            string uEmailTo = emailToTB.Text;
            string uEmailFr = emailFTB.Text;
            string uLog = logTB.Text;
            string uSmtp = smtpTB.Text;
            string ulocation = locationTB.Text;
            string upathtype = pathTYCB.Text;
            string uusername = userTB.Text;
            string upassword = passwordTB.Text;
            int companyUpdate = 0;
            int directoryupdate = 0;
            int emailtoupdate = 0;
            int emailfrupdate = 0;
            int logupdate = 0;
            int smtpupdate = 0;
            int locationupdate = 0;
            int pathtypeupdate = 0;
            int usernameupdate = 0;
            int passwordupdate = 0;
            string scriptlocation = installDirectory + "UserConfig.txt";
            string[] lines = System.IO.File.ReadAllLines(scriptlocation);
            foreach (string line in lines)
            {
            }


            if (File.Exists(scriptlocation))
            {
                if (companyUpdate == 0)
                {
                    foreach (var line in textBox.Lines)
                    {

                    }
                }
                if (directoryupdate == 0)
                {
                    foreach (var line in textBox.Lines)
                    {
                        if (line.Contains(dirIdent))
                        {
                            textBox.Text = textBox.Text.Replace(line, dirIdent + " \"" + uDirectory + "\"");
                        }
                        directoryupdate++;
                    }
                }
                if (emailtoupdate == 0)
                {
                    foreach (var line in textBox.Lines)
                    {
                        if (line.Contains(emToIdent))
                        {
                            if (emailToTB.Enabled == true)
                            {
                                textBox.Text = textBox.Text.Replace(line, emToIdent + " \"" + uEmailTo + "\"");
                            }
                            else
                            {
                                textBox.Text = textBox.Text.Replace(line, emToIdent + " \"" + "\"");
                            }

                        }
                        emailtoupdate++;
                    }
                }
                if (emailfrupdate == 0)
                {
                    foreach (var line in textBox.Lines)
                    {
                        if (line.Contains(emFrIdent))
                        {
                            if (emailFTB.Enabled == true)
                            {
                                textBox.Text = textBox.Text.Replace(line, emFrIdent + " \"" + uEmailFr + "\"");
                            }
                            else
                            {
                                textBox.Text = textBox.Text.Replace(line, emFrIdent + " \"" + "\"");
                            }

                        }
                        emailfrupdate++;
                    }

                }
                if (logupdate == 0)
                {
                    foreach (var line in textBox.Lines)
                    {
                        if (line.Contains(lgFlIdent))
                        {
                            textBox.Text = textBox.Text.Replace(line, lgFlIdent + " \"" + uLog + "\"");
                        }
                        logupdate++;
                    }
                }
                if (smtpupdate == 0)
                {
                    foreach (var line in textBox.Lines)
                    {
                        if (line.Contains(smtpIdent))
                        {
                            if (smtpTB.Enabled == true)
                            {
                                textBox.Text = textBox.Text.Replace(line, smtpIdent + " \"" + uSmtp + "\"");
                            }
                            else
                            {
                                textBox.Text = textBox.Text.Replace(line, smtpIdent + " \"" + "\"");
                            }

                        }
                        smtpupdate++;
                    }

                }
                if (locationupdate == 0)
                {
                    foreach (var line in textBox.Lines)
                    {
                        if (line.Contains(locationIdent))
                        {
                            textBox.Text = textBox.Text.Replace(line, locationIdent + " \"" + ulocation + "\"");
                        }
                        locationupdate++;
                    }

                }
                if (pathtypeupdate == 0)
                {
                    foreach (var line in textBox.Lines)
                    {
                        if (line.Contains(pthTpIdent))
                        {
                            textBox.Text = textBox.Text.Replace(line, pthTpIdent + " \"" + upathtype + "\"");
                        }
                        locationupdate++;
                    }

                }
                if (usernameupdate == 0)
                {
                    foreach (var line in textBox.Lines)
                    {
                        if (line.Contains(usernameIdent))
                        {
                            textBox.Text = textBox.Text.Replace(line, usernameIdent + " \"" + uusername + "\"");
                        }
                        usernameupdate++;
                    }

                }
                if (passwordupdate == 0)
                {
                    foreach (var line in textBox.Lines)
                    {
                        if (line.Contains(passwordIdent))
                        {
                            textBox.Text = textBox.Text.Replace(line, passwordIdent + " \"" + upassword + "\"");
                        }
                        passwordupdate++;
                    }

                }
                if (companyUpdate + directoryupdate + emailtoupdate + emailfrupdate + logupdate +
                    smtpupdate + locationupdate + pathtypeupdate + usernameupdate + passwordupdate > 0 && !textBox.Text.Equals(noSelStr))
                {
                    File.WriteAllText(scriptlocation, textBox.Text);
                }

            }
        }

        public void getUserSettings(string[] arr)
        {
            foreach (Control c in Controls)
            {
                if (c is TextBox)
                {
                    string cname = c.Name;

                }
            }
        }



        private void locationButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fdb = new FolderBrowserDialog();
            fdb.RootFolder = Environment.SpecialFolder.MyComputer;
            if (fdb.ShowDialog() == DialogResult.OK)
            {
                locationTB.Text = fdb.SelectedPath;
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var scriptlocation = installDirectory + "UserConfig.txt";
            var scriptText = File.ReadAllText(scriptlocation);
            if (checkwindowsFeatureInsatlled() == true)
            {
                createBackup();

/*                textBox.AppendText(Environment.NewLine + "Server Backup Installed");
                PowerShell powerShell = PowerShell.Create();
                //            textBox.Text += (scriptText + "\r\n");

                powerShell.AddCommand("Import-Module").AddArgument("ServerManager");
                powerShell.AddCommand("Add-WindowsFeature");
                powerShell.AddArgument("Windows-Server-Backup");
                powerShell.AddCommand("Add-WBBareMetalRecovery").AddArgument("-Policy $backupPolicy");
                //            powerShell.AddScript(scriptText);
                PSDataCollection<PSObject> outputCollection = new PSDataCollection<PSObject>();
                outputCollection.DataAdded += outputCollection_DataAdded;
                var results = powerShell.Invoke();

                foreach (var item in results)
                {
                    string itemstring = item.ToString();
                    textBox.Text += (textBox.Text + "\r\n" + itemstring);
                }

                if (powerShell.Streams.Error.Count > 0)
                {
                    var error = powerShell.Streams.Error.ReadAll() as Collection<ErrorRecord>;
                    foreach (ErrorRecord er in error)
                    {
                        textBox.Text = er.Exception.Message;
                    }
                }*/
            }
            else
            {
                if (checkwindowsFeatureInstallable() == true)
                {
                    textBox.AppendText(Environment.NewLine + "Server Backup Installable");
                    if (InstalledWindowsBackupFeatures()== true)
                    {
                        textBox.AppendText(Environment.NewLine + "Server Backup Installed");
                    }
                }

            }


        }

        private void emailCheck_CheckedChanged(object sender, EventArgs e)
        {
            emailToTB.Enabled = (emailCheck.CheckState == CheckState.Checked);
            emailFTB.Enabled = (emailCheck.CheckState == CheckState.Checked);
            smtpTB.Enabled = (emailCheck.CheckState == CheckState.Checked);
        }

        void outputCollection_DataAdded(object sender, DataAddedEventArgs e)
        {
            // do something when an object is written to the output stream
            textBox.Text += ("Object added to output.");
        }

        private string createWinFeaturesText(string filelocation)
        {
            PowerShell powerShell = PowerShell.Create();
            string tempfilelocationUnformatted = installDirectory + "temp.txt";
            string tempfilelocation = "\"" + tempfilelocationUnformatted.Replace(@"\", @"\\") + "\"";
            string powershellScript = "import-module servermanager | Get-windowsFeature -Name Windows-Server-Backup > " + tempfilelocation;
            powerShell.AddScript(powershellScript);
            powerShell.Invoke();
            return filelocation = tempfilelocationUnformatted;
        }

        Boolean checkwindowsFeatureInsatlled()
        {
            textBox.Text = "";
            var l = 0;
            string[] stringarray = File.ReadAllLines(createWinFeaturesText(filelocation));
            foreach (string s in stringarray)
            {
                if (s.Contains("Windows-Server-Backup") && s.Contains("X"))
                {
                    textBox.AppendText(Environment.NewLine + s);
                    l = l + 1;
                }
            }
            if (l >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        Boolean checkwindowsFeatureInstallable()
        {
            textBox.Text = "";
            var l = 0;
            string[] stringarray = File.ReadAllLines(createWinFeaturesText(filelocation));
            foreach (string s in stringarray)
            {
                if (s.Contains("Windows-Server-Backup") && !s.Contains("X"))
                {
                    textBox.AppendText(Environment.NewLine + s);
                    l = l + 1;
                }
            }
            if (l >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        Boolean InstalledWindowsBackupFeatures()
        {
            InitialSessionState iss = InitialSessionState.CreateDefault();
            iss.ImportPSModule(new string[] { "ServerManager" });
            Runspace powerShellRunspace = RunspaceFactory.CreateRunspace(iss);
            powerShellRunspace.Open();
            using (PowerShell powershell = PowerShell.Create())
            {
                powershell.Runspace = powerShellRunspace;
                powershell.AddCommand("add-WindowsFeature");
                powershell.AddArgument("Windows-Server-Backup");
                powershell.Invoke();
            }
            powerShellRunspace.Close();
            return true;
        }

        void createBackup()
        {
            string backuplogdir = installDirectory + "backuplogs";
            string backupdaytime = DateTime.Now.ToString("MMddyyyyTHHmm");
            string backuplogfile = backuplogdir + "\\" + backupdaytime ;
            string backuplogfiletxt = backuplogdir + "\\" + backupdaytime + ".txt";
        
            if (!Directory.Exists(backuplogdir))
            {
                Directory.CreateDirectory(backuplogdir);
            }
            if(logTB.Text.Length > 0)
            {
                if (!File.Exists(logTB.Text))
                {
                    File.Create(logTB.Text);
                }
            }

            var BackupTarget = "";
            var username = "";
            var password = "";
            string selectedItem = pathTYCB.SelectedItem.ToString();
            if (selectedItem.Contains("NETWORKPATH"))
            {
                if (userTB.Text.Length > 0)
                {
                    
                    if (passwordTB.Text.Length > 0)
                    {
                                         
                        BackupTarget = " $BackupTarget = New-WBBackupTarget -NetworkPath \"$location\" -Credential $Cred";
                    }
                }
                else
                {
                    BackupTarget = " $BackupTarget = New-WBBackupTarget -NetworkPath \"$location\"";
                }
                
            }
            if (selectedItem.Contains("DISK"))
            {
                BackupTarget = " $BackupTarget = New-WBBackupTarget -Disk \"$location\"";
            }
            if (selectedItem.Contains("VOLUME "))
            {
                BackupTarget = " $BackupTarget = New-WBBackupTarget -Volume \"$location\"";
            }
            if (selectedItem.Contains("VOLUMEPATH"))
            {
                BackupTarget = " $BackupTarget = New-WBBackupTarget -Volumepath \"$location\"";
            }
            PowerShell psinstace = PowerShell.Create();
            psinstace.AddScript("Import-Module -Name ServerManager");
            psinstace.AddScript("$backupPolicy = New-WBPolicy");
            psinstace.AddScript("Add-WBBareMetalRecovery -Policy $backupPolicy");
            psinstace.AddScript(" $location = " + "\"" + locationTB.Text + "\"");
            if (userTB.Text.Length > 0)
            {
                username = userTB.Text;
                if (passwordTB.Text.Length > 0)
                {
                    password = passwordTB.Text;
                    psinstace.AddScript("$username = " + "\"" + userTB.Text + "\"");
                    psinstace.AddScript("$password = " + "\"" + password + "\"");
                    psinstace.AddScript("$SecurePassword = ConvertTo-SecureString -String $Password -AsPlainText -Force");
                    psinstace.AddScript("$cred = New-Object -TypeName System.Management.Automation.PSCredential -Argumentlist $username, $SecurePassword");
                }
    
            }
            psinstace.AddScript(BackupTarget);
            psinstace.AddScript("Add-WBBackupTarget $BackupTarget -Policy $backupPolicy");
            psinstace.AddScript("Start-WBBackup -Policy $backupPolicy");
            var results = psinstace.Invoke();
            var completeVar = 0;
            foreach (var item in results)
            {
                if(item.ToString().Contains("The Backup operation completed"))
                {
                    completeVar++;
                }
                File.AppendAllText(backuplogfiletxt, item.ToString());
                Console.WriteLine(item);

            }
            Console.WriteLine(psinstace.Streams.Error.Count().ToString() + "Error Counts");

           foreach (var errorRecord in psinstace.Streams.Error)
            {
               Console.WriteLine(errorRecord.ToString()+ "");
                File.AppendAllText(backuplogfiletxt, errorRecord.ToString());

            }
            Console.WriteLine(completeVar);
            if (completeVar > 0)
            {
                File.Move(backuplogfiletxt, backuplogfile + "COMPLETE.txt");
           }
            else
            {
                File.Move(backuplogfiletxt, backuplogfile + "FAILED.txt");
            }
            return;
        }

        private void locationTB_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
