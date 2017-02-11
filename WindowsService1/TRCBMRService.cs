using System;
using System.Linq;
using System.ServiceProcess;
using System.IO;
using System.Management.Automation;
using System.Collections.ObjectModel;
using System.Management.Automation.Runspaces;
using System.Diagnostics;
using PowerShell = System.Management.Automation.PowerShell;
using System.Text;

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
            string onstart = AppDomain.CurrentDomain.BaseDirectory + "Onstart.txt";
            System.Diagnostics.Debugger.Launch();
            if (File.Exists(onstart))
            {
            }
            else
            {
                File.Create(onstart);
            }
            
            Debug.WriteLine("Created onstart");
            string installDirectory = (AppDomain.CurrentDomain.BaseDirectory);
            var scriptlocation = installDirectory + "UserConfig.txt";
            //if (File.Exists(scriptlocation))
            //{
            //    var scriptText = File.ReadAllText(scriptlocation);
            //}
            //else
            //{
            //    System.Environment.Exit(1);
            //}
            if (checkwindowsFeatureInsatlled() == true)
            {
                Debug.WriteLine("Windows featured is installed");
                //Let GUI know that the backup is starting
                createBackup();
            }
            else
            {
                Debug.WriteLine("Windows featured is not installed");
                if (checkwindowsFeatureInstallable() == true)
                {
                    //let gui know that service is installable
                    if (InstalledWindowsBackupFeatures() == true)
                    {
                        Debug.WriteLine("Installed Windows Feature");
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
            string tempfilelocationUnformatted = installDirectory + "temp.txt";
            string tempfilelocation = "\"" + tempfilelocationUnformatted.Replace(@"\", @"\\") + "\"";

            return filelocation = tempfilelocationUnformatted;
        }

        Boolean checkwindowsFeatureInsatlled()
        {
            Debug.WriteLine("Checking If windows feature is installed");
            string installDirectory = (AppDomain.CurrentDomain.BaseDirectory);
            string tempfilelocationUnformatted = installDirectory + "temp.txt";
            var l = 0;
            string powershellScript = "import-module servermanager | Get-windowsFeature -Name Windows-Server-Backup";
           
            Runspace runspace = RunspaceFactory.CreateRunspace();
            Debug.WriteLine("Created runspace");
            runspace.Open();
            Debug.WriteLine("Opened runspace");
            Pipeline pipeline = runspace.CreatePipeline();
            Debug.WriteLine("Opened Runspace pipleine");
            pipeline.Commands.AddScript(powershellScript);
            Debug.WriteLine("Added Script to pipleine");
            pipeline.Commands.Add("Out-String");
            Debug.WriteLine("Told pipline to output to string");
            Collection<PSObject> results = pipeline.Invoke();
            Debug.WriteLine("Invoked the pipleine");
            runspace.Close();
            Debug.WriteLine("Closed the runspace");
            StringBuilder stringBuilder = new StringBuilder();
            Debug.WriteLine("Created StringBuildere");
            foreach (PSObject obj in results)
            {
                stringBuilder.AppendLine(obj.ToString());
                Debug.WriteLine("Generating the string");
            }
            string s = stringBuilder.ToString();
            Debug.WriteLine(s);
            Debug.WriteLine("Output the string");

            //PowerShell powerShell = PowerShell.Create();
            //string powershellScript = "import-module servermanager | Get-windowsFeature -Name Windows-Server-Backup" ;
            //powerShell.AddScript(powershellScript);
            //var results = powerShell.Invoke();
            //Debug.WriteLine("Running Powershell");
            //var l = 0;
            //foreach (var item in results)
            //{

            //    string s = item.ToString();
            //    Debug.WriteLine(s);
            //    File.WriteAllText(tempfilelocationUnformatted, s);
            //    if (s.Contains("Windows-Server-Backup") && s.Contains("X"))
            //    {
            //          l = l + 1;
            //    }
            //}
            if (l >= 1)
            {
                return true;
            }
            else
            {
                Debug.WriteLine("Windows Feature is not installed");
                return false;
            }

        }

        Boolean checkwindowsFeatureInstallable()
        {
            Debug.WriteLine("Checking if windows feature is installable");
            string installDirectory = (AppDomain.CurrentDomain.BaseDirectory);
            string tempfilelocationUnformatted = installDirectory + "temp.txt";
            PowerShell powerShell = PowerShell.Create();
            string powershellScript = "import-module servermanager | Get-windowsFeature -Name Windows-Server-Backup";
            powerShell.AddScript(powershellScript);
            Debug.WriteLine("Running Powershell");
            Collection<PSObject> results = powerShell.Invoke();
            var l = 0;
            foreach (PSObject psObject in results)
            {
                foreach (PSProperty psPropertyinfo in psObject.Properties)
                {
                    string value = "";
                    if (psPropertyinfo.Value != null)
                    {
                         value = psPropertyinfo.Value.ToString();
                    }
                    if (value.Contains("backup"))
                    {
                        Debug.Write(psPropertyinfo.MemberType);
                    //    Debug.Write(value + "123456789");
                    //    using (StreamWriter sw = File.AppendText(tempfilelocationUnformatted))
                    //    {
                    //        sw.WriteLine(psPropertyinfo.Name);
                    //        sw.WriteLine(psPropertyinfo.Value);
                    //        sw.WriteLine(psPropertyinfo.MemberType);
                    //    }
                    }


                }

                Debug.WriteLine("Writing data to text file");
                

               
               // if (s.Contains("Windows-Server-Backup") && !s.Contains("X"))
               // {
               //     l = l + 1;
              //  }
            }
            if (l >= 1)
            {
                return true;
            }
            else
            {
                Debug.WriteLine("Windows feature not installable");
                return false;
            }
        }

        Boolean InstalledWindowsBackupFeatures()
        {
            Debug.WriteLine("Installing windows backup feature");
            InitialSessionState iss = InitialSessionState.CreateDefault();
            iss.ImportPSModule(new string[] { "ServerManager" });
            Runspace powerShellRunspace = RunspaceFactory.CreateRunspace(iss);
            powerShellRunspace.Open();
            Debug.WriteLine("Running powershell");
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
            Debug.WriteLine("Creating and running backup");
            string installDirectory = (AppDomain.CurrentDomain.BaseDirectory);
            string backuplogdir = installDirectory + "backuplogs";
            string backupdaytime = DateTime.Now.ToString("MMddyyyyTHHmmss");
            string backuplogfile = backuplogdir + "\\" + backupdaytime;
            string backuplogfiletxt = backuplogdir + "\\" + backupdaytime + ".txt";

            if (!Directory.Exists(backuplogdir))
            {
              //  textBox.AppendText(Environment.NewLine + "Backup Driectory Check FAILED: Creating Backup Log Driectory");
                Directory.CreateDirectory(backuplogdir);
            }
            else
            {
              //  textBox.AppendText(Environment.NewLine + "Backup Driectory Check PASSED");
            }
            //if (logTB.Text.Length > 0)
            //{
            //    if (!File.Exists(logTB.Text))
            //    {
            //        File.Create(logTB.Text);
            //    }
            //}

            var BackupTarget = "";
            var username = "";
            var password = "";
            //string selectedItem = pathTYCB.SelectedItem.ToString();
            //if (selectedItem.Contains("NETWORKPATH"))
            //{
            //    if (userTB.Text.Length > 0)
            //    {

            //        if (passwordTB.Text.Length > 0)
            //        {

            //          BackupTarget = " $BackupTarget = New-WBBackupTarget -NetworkPath \"$location\" -Credential $Cred";
            //        }
            //    }
            //    else
            //    {
            //        BackupTarget = " $BackupTarget = New-WBBackupTarget -NetworkPath \"$location\"";
            //    }

            //}
            //if (selectedItem.Contains("DISK"))
            //{
            //    BackupTarget = " $BackupTarget = New-WBBackupTarget -Disk \"$location\"";
            //}
            //if (selectedItem.Contains("VOLUME "))
            //{
            //    BackupTarget = " $BackupTarget = New-WBBackupTarget -Volume \"$location\"";
            //}
            //if (selectedItem.Contains("VOLUMEPATH"))
            //{
            //    BackupTarget = " $BackupTarget = New-WBBackupTarget -Volumepath \"$location\"";
            //}
            ////Backup State is now running the script
            PowerShell psinstace = PowerShell.Create();
            psinstace.AddScript("Import-Module -Name ServerManager");
            psinstace.AddScript("$backupPolicy = New-WBPolicy");
            psinstace.AddScript("Add-WBBareMetalRecovery -Policy $backupPolicy");
          //  psinstace.AddScript(" $location = " + "\"" + locationTB.Text + "\"");
           // if (userTB.Text.Length > 0)
          //  {
           //     username = userTB.Text;
            //    if (passwordTB.Text.Length > 0)
             //   {
            //        password = passwordTB.Text;
             //       psinstace.AddScript("$username = " + "\"" + userTB.Text + "\"");
             //       psinstace.AddScript("$password = " + "\"" + password + "\"");
             //       psinstace.AddScript("$SecurePassword = ConvertTo-SecureString -String $Password -AsPlainText -Force");
             //       psinstace.AddScript("$cred = New-Object -TypeName System.Management.Automation.PSCredential -Argumentlist $username, $SecurePassword");
             //   }

          //  }
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
                //Report Errors

            }
            Console.WriteLine(completeVar);
            if (completeVar > 0)
            {
                string backupfile = backuplogfile + "COMPLETE.txt";


                File.Move(backuplogfiletxt, backuplogfile + "COMPLETE.txt");
                /////Report Backup Status as Complete
            }
            else
            {
                string backupfile = backuplogfile + "COMPLETE.txt";

                File.Move(backuplogfiletxt, backuplogfile + "FAILED.txt");
                //Report Backup Status as FAILED
            }
            return;
        }

        protected override void OnStop()
        {
        }
    }
}
