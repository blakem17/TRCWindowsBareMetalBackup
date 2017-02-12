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
using System.Diagnostics;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public static string installDirectory = (AppDomain.CurrentDomain.BaseDirectory);
        public static string backuplogdir = installDirectory + "backuplogs";
        public static string backupconfigFile = installDirectory + "config.txt";
        public static string backupConfigBase = "none,none,none,none";
        public Form1()
        {
            InitializeComponent();
            if (!File.Exists(backupconfigFile))
            {
                installDefaultConfig();

            }
            if (configIsValid() == true)
            {
                populateTB();
            }
            else
            {
                showConfigError();
                installDefaultConfig();
                populateTB();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public static string backupConfigStr()
        {
            if (File.Exists(backupconfigFile))
            {
                string backupConfig = File.ReadAllText(backupconfigFile);
                return backupConfig;
            }
            else
            {
                return null;
            }

        }
        public static string[] backupConfigStringArr()
        {
            string backupConfigString = backupConfigStr();
            string[] backupStringArray = backupConfigString.Split(',');
            return backupStringArray;
        }
        public void populateTB()
        {
            int i = 0;
            foreach (string st in backupConfigStringArr())
            {
                switch (i)
                {
                    case 0:
                        backupTypeTB.Text = st;
                        i = i + 1;
                        break;
                    case 1:
                        backupLocationTB.Text = st;
                        i = i + 1;
                        break;
                    case 2:
                        usernameTB.Text = st;
                        i = i + 1;
                        break;
                    case 3:
                        passwordTB.Text = st;
                        break;
                    default:
                        Console.WriteLine("Error Default switch");
                        break;
                }
                
            }

        }
        public void configStringBuildAndSave()
            {
            string configString = backupTypeTB.Text + "," + backupLocationTB.Text + "," + usernameTB.Text + "," + passwordTB.Text;
            File.WriteAllText(backupconfigFile, configString);
            }

        private void saveButton_Click(object sender, EventArgs e)
        {
            configStringBuildAndSave();
        }
        public Boolean configIsValid()
        {
            int arrLenght = backupConfigStringArr().Length;
            if (arrLenght.Equals(4))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public void showConfigError()
        {
            MessageBox.Show("The configuration file has become corrupt. Reverting to Default");
        }
        public static void installDefaultConfig()
        {
            File.WriteAllText(backupconfigFile, backupConfigBase);
        }
    }
}
