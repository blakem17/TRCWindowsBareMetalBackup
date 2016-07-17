using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

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
        private string[] setArr = new string[8];
        private string[] updateArr = new string[7] { "company", "cred", "directory", "emailTo", "emailF", "log", "smtp"};


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
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            textBox.Text = filelocation;
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
                textBox.Text = "";
                string[] fileTextArr = File.ReadAllLines(filelocation);
                string fileText = ConvertStringArrayToString(fileTextArr);
                foreach (string t in setArr)
                {
                    foreach (string s in fileTextArr)
                    {
                        if (s.Contains(t))
                        {
                            string scont = s;
                            if (s.Contains(" = \""))
                            {
                                    textBox.AppendText(Environment.NewLine + s);
                                foreach (string upstring in updateArr)
                                {
                                    if (s.Contains(upstring))
                                    {
                                        foreach (Control c in this.Controls)
                                        {
                                            string cname = c.Name;
                                            if (c is TextBox)
                                            {
                                                if (cname.Contains(upstring))
                                                {
                                                    var reg = new Regex("\".*?\"");
                                                    var matches = reg.Matches(s);
                                                    foreach (var item in matches)
                                                    {

                                                        string u = item.ToString().Replace("\"", "");
                                                        c.Text = u;

                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
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
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    foreach (string d in updateArr)
                    {
                        string tbName = c.Name;
                        if (tbName.Contains(d))
                        {
                            string txtboxInput = c.Text;
                            foreach (string t in setArr)
                            {
                                if (t.Contains(d))
                                {
                                    string toadd = t + " \"" + txtboxInput + "\"";
                                    textBox.AppendText(Environment.NewLine + toadd);
                                }
                            }
                        }
                    }

                }
            }

        }

        private void seldirectoryBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
