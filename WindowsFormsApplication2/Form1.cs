﻿using System;
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
        private string[] setArr = new string[8];

        string installDirectory =
            Registry.CurrentUser.OpenSubKey(@"Software\Blakem\UserChoice").GetValue("InstallDirectory").ToString();

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
            var scriptlocation = installDirectory + "WindowsBMR.ps1";
            if (!File.Exists(scriptlocation))
            {
                byte[] myfile = Resources.WindowsBMR;
                string myfileStr = System.Text.Encoding.UTF8.GetString(myfile);
                File.WriteAllText(scriptlocation, myfileStr);
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
                    if (s.Contains(credIdent) && s.Length > 13)
                    {
                        var reg = new Regex("\".*?\"");
                        var matches = reg.Matches(s);
                        foreach (var item in matches)
                        {

                            string u = item.ToString().Replace("\"", "");
                            credTB.Text = u;
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

                            string u = item.ToString().Replace("\"", "");
                            pathTYCB.Text = u;

                        }
                    }
                    if (s.Contains(credIdent) && s.Length > 13)
                    {
                        var reg = new Regex("\".*?\"");
                        var matches = reg.Matches(s);
                        foreach (var item in matches)
                        {

                            string u = item.ToString().Replace("\"", "");
                            credTB.Text = u;
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

        static string ConvertStringArrayToString(string[] array)
        {
            //
            // Concatenate all the elements into a StringBuilder.
            //
            StringBuilder builder = new StringBuilder();
            foreach (string value in array)
            {
                builder.Append(value);
                builder.Append('.');
            }
            return builder.ToString();
        }

        private void pathTYCB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void saveButtton_Click(object sender, EventArgs e)
        {
            string uCompany = companyTB.Text;
            string uCred = credTB.Text;
            string uDirectory = directoryTB.Text;
            string uEmailTo = emailToTB.Text;
            string uEmailFr = emailFTB.Text;
            string uLog = logTB.Text;
            string uSmtp = smtpTB.Text;
            string ulocation = locationTB.Text;
            string upathtype = pathTYCB.Text;
            int companyUpdate = 0;
            int credupdate = 0;
            int directoryupdate = 0;
            int emailtoupdate = 0;
            int emailfrupdate = 0;
            int logupdate = 0;
            int smtpupdate = 0;
            int locationupdate = 0;
            int pathtypeupdate = 0;
            string scriptlocation = installDirectory + "WindowsBMR.ps1";
            if (File.Exists(scriptlocation))
            {
                if (companyUpdate == 0)
                {
                    foreach (var line in textBox.Lines)
                    {
                        if (line.Contains(compIdent))
                        {
                            textBox.Text = textBox.Text.Replace(line, compIdent + " \"" + uCompany + "\"");
                        }
                        companyUpdate ++;
                    }
                }
                if (credupdate == 0)
                {
                    foreach (var line in textBox.Lines)
                    {
                        if (line.Contains(credIdent))
                        {
                            textBox.Text = textBox.Text.Replace(line, credIdent + " \"" + uCred + "\"");
                        }
                        credupdate++;
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
                if (companyUpdate + credupdate + directoryupdate + emailtoupdate + emailfrupdate + logupdate +
                    smtpupdate + locationupdate + pathtypeupdate > 0 && !textBox.Text.Equals(noSelStr))
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
            var scriptlocation = installDirectory + "WindowsBMR.ps1";
            var scriptText = File.ReadAllText(scriptlocation);
            if (checkwindowsFeatureInsatlled() == true)
            {
                textBox.AppendText(Environment.NewLine + "Server Backup Installed");
/*                PowerShell powerShell = PowerShell.Create();
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
        private string RunScript(string scriptText)
        {
            // create Powershell runspace 
            Runspace runspace = RunspaceFactory.CreateRunspace();

            // open it 
            runspace.Open();

            // create a pipeline and feed it the script text 
            Pipeline pipeline = runspace.CreatePipeline();
            pipeline.Commands.AddScript(scriptText);

            // add an extra command to transform the script output objects into nicely formatted strings 
            // remove this line to get the actual objects that the script returns. For example, the script 
            // "Get-Process" returns a collection of System.Diagnostics.Process instances. 
            pipeline.Commands.Add("Out-String");

            // execute the script 
            Collection<PSObject> results = pipeline.Invoke();

            // close the runspace 
            runspace.Close();

            // convert the script result into a single string 
            StringBuilder stringBuilder = new StringBuilder();
            foreach (PSObject obj in results)
            {
                stringBuilder.AppendLine(obj.ToString());
            }

            // return the results of the script that has 
            // now been converted to text 
            return stringBuilder.ToString();
        }
        private string LoadScript(string filename)
        {
            try
            {
                // Create an instance of StreamReader to read from our file. 
                // The using statement also closes the StreamReader. 
                using (StreamReader sr = new StreamReader(filename))
                {

                    // use a string builder to get all our lines from the file 
                    StringBuilder fileContents = new StringBuilder();

                    // string to hold the current line 
                    string curLine;

                    // loop through our file and read each line into our 
                    // stringbuilder as we go along 
                    while ((curLine = sr.ReadLine()) != null)
                    {
                        // read each line and MAKE SURE YOU ADD BACK THE 
                        // LINEFEED THAT IT THE ReadLine() METHOD STRIPS OFF 
                        fileContents.Append(curLine + "\n");
                    }

                    // call RunScript and pass in our file contents 
                    // converted to a string 
                    return fileContents.ToString();
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong. 
                string errorText = "The file could not be read:";
                errorText += e.Message + "\n";
                return errorText;
            }

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
            string tempfilelocationUnformatted = installDirectory + "temp.txt";
            string tempfilelocation = "\"" + tempfilelocationUnformatted.Replace(@"\", @"\\") + "\"";

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
    }
}
