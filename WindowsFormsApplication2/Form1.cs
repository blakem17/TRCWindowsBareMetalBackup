﻿using System;
using System.Collections.Generic;
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

        public Form1()
        {
            InitializeComponent();
            selDirectoBox.Text = "";
            setArr[0] = compIdent;
            setArr[1] = credIdent;
            setArr[2] = dirIdent;
            setArr[3] = emFrIdent;
            setArr[4] = emToIdent;
            setArr[5] = lgFlIdent;
            setArr[6] = pthTpIdent;
            setArr[7] = smtpIdent;
            try
            {
                RegistryKey regKey = Registry.CurrentUser;
            regKey = regKey.OpenSubKey(@"Software\Blakem\UserChoice");
            textBox.Text = regKey.GetValue("InstallDirectory").ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            //            byte[] myfile = Resources.WindowsBMR;
            //            string myfileStr = System.Text.Encoding.UTF8.GetString(myfile);
            //            textBox.Text = myfileStr;

        }
        private void seldirectoryBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void startButton_Click(object sender, EventArgs e)
        {
            selDirectoBox.Text = filelocation;
            if  (selDirectoBox.Text.Equals(noSelStr))
            {
                textBox.Text = noSelStr;
            }
            if (selDirectoBox.Text.Equals(""))
            {
                textBox.Text = noSelStr;
                selDirectoBox.Text = noSelStr;
            }
            if (File.Exists(filelocation))
            {
                string[] fileTextArr1 = File.ReadAllLines(filelocation);
                string joinded = String.Join(Environment.NewLine, fileTextArr1);
                textBox.Text = joinded;
                foreach(string s in fileTextArr1)
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

                        };
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
                if(!File.Exists(filelocation) && selDirectoBox.Text.Equals(""))
                {
                    textBox.Text = "File Does Not Exit";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            openFileDialog1.ShowDialog();
            filelocation = openFileDialog1.InitialDirectory + openFileDialog1.FileName;
            if (filelocation.Equals("openFileDialog1"))
            {
                selDirectoBox.Text = noSelStr;
            }
            else
            {
                selDirectoBox.Text = filelocation;
            }
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
            selDirectoBox.Text = filelocation;
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
            selDirectoBox.Text = filelocation;
            if (selDirectoBox.Text.Equals(noSelStr))
            {
                textBox.Text = noSelStr;
            }
            if (selDirectoBox.Text.Equals(""))
            {
                textBox.Text = noSelStr;
                selDirectoBox.Text = noSelStr;
            }
            if (File.Exists(filelocation))
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
                            textBox.Text = textBox.Text.Replace(line, emToIdent + " \"" + uEmailTo + "\"");
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
                            textBox.Text = textBox.Text.Replace(line, emFrIdent + " \"" + uEmailFr + "\"");
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
                            textBox.Text = textBox.Text.Replace(line, smtpIdent + " \"" + uSmtp + "\"");
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
                if (companyUpdate + credupdate + directoryupdate + emailtoupdate + emailfrupdate + logupdate + smtpupdate + locationupdate + pathtypeupdate > 0 && !textBox.Text.Equals(noSelStr))
                {
                    File.WriteAllText(filelocation, textBox.Text);
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

        }
    }
}
