using System;
using System.Linq;
using System.ServiceProcess;
using System.IO;
using PowerShell = System.Management.Automation.PowerShell;

namespace WindowsService1
{
    public partial class TRCBMRService : ServiceBase
    {
        public TRCBMRService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            System.IO.File.Create(AppDomain.CurrentDomain.BaseDirectory + "Onstart.txt");
            string installDirectory = (AppDomain.CurrentDomain.BaseDirectory);
            var scriptlocation = installDirectory + "UserConfig.txt";
            var scriptText = File.ReadAllText(scriptlocation);
            if (checkwindowsFeatureInsatlled() == true)
            {
                //Let GUI know that the backup is starting
                createBackup();

            }
            else
            {
                if (checkwindowsFeatureInstallable() == true)
                {
                    //let gui know that service is installable
                    if (InstalledWindowsBackupFeatures() == true)
                    {
                        //Let gui know that service was installed
                        //Let GUI know that the backup is starting
                        createBackup();
                    }
                }

            }


        }

        private string createWinFeaturesText(string filelocation)
        {
            string installDirectory = (AppDomain.CurrentDomain.BaseDirectory);
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
            backupStatus.Text = "STARTED";
            string backuplogdir = installDirectory + "backuplogs";
            string backupdaytime = DateTime.Now.ToString("MMddyyyyTHHmmss");
            string backuplogfile = backuplogdir + "\\" + backupdaytime;
            string backuplogfiletxt = backuplogdir + "\\" + backupdaytime + ".txt";

            if (!Directory.Exists(backuplogdir))
            {
                textBox.AppendText(Environment.NewLine + "Backup Driectory Check FAILED: Creating Backup Log Driectory");
                Directory.CreateDirectory(backuplogdir);
            }
            else
            {
                textBox.AppendText(Environment.NewLine + "Backup Driectory Check PASSED");
            }
            if (logTB.Text.Length > 0)
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
            backupStatus.Text = "Running";
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
                if (item.ToString().Contains("The Backup operation completed"))
                {
                    completeVar++;
                }
                File.AppendAllText(backuplogfiletxt, item.ToString());
                Console.WriteLine(item);

            }
            Console.WriteLine(psinstace.Streams.Error.Count().ToString() + "Error Counts");

            foreach (var errorRecord in psinstace.Streams.Error)
            {
                Console.WriteLine(errorRecord.ToString() + "");
                File.AppendAllText(backuplogfiletxt, errorRecord.ToString());
                textBox.AppendText(Environment.NewLine + errorRecord.ToString());

            }
            Console.WriteLine(completeVar);
            if (completeVar > 0)
            {
                string backupfile = backuplogfile + "COMPLETE.txt";


                File.Move(backuplogfiletxt, backuplogfile + "COMPLETE.txt");
                backupStatus.Text = "COMPLETE";
            }
            else
            {
                string backupfile = backuplogfile + "COMPLETE.txt";

                File.Move(backuplogfiletxt, backuplogfile + "FAILED.txt");
                backupStatus.Text = "FAILED";
            }
            return;
        }
    }

        protected override void OnStop()
        {
        }
    }
}
