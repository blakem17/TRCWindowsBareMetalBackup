using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using System.Diagnostics;

namespace ConsoleApplication1
{
    class Program
    {
        public static string installDirectory = (AppDomain.CurrentDomain.BaseDirectory);
        public static string backuplogdir = installDirectory + "backuplogs";
        public static string backupconfigFile = installDirectory + "config.txt";

        static void Main(string[] args)
        {
            
            if (backupIsInstalled() == true)
            {
                runbackup();
            }
            else
            {
                if (backupIsInstallable() == true)
                {
                    installbackup();
                    runbackup();
                }
                else
                {
                    noSupport();
                }
            }
            
        }
        
        public static void installbackup()
        {
            var ps = PowerShell.Create();
            ps.AddScript("add-WindowsFeature Windows-Server-Backup");
            var output = ps.Invoke();
            var backupIsInstalled = output.FirstOrDefault()?.Members["Success"]?.Value ?? false;

            if (backupIsInstalled.Equals("true"))
            {
                runbackup();
            }

        }
        public static void runbackup()
        {
            string backupconfigstring = backupConfigStr();
            
            Debug.WriteLine("Creating and running backup");
            string backupdaytime = DateTime.Now.ToString("MMddyyyyTHHmmss");
            string backuplogfile = backuplogdir + "\\" + backupdaytime;
            string backuplogfiletxt = backuplogdir + "\\" + backupdaytime + ".txt";
            if (!Directory.Exists(backuplogdir))
            {
                Directory.CreateDirectory(backuplogdir);
                Debug.WriteLine("Created BackupLog Directory");
            }
            else
            {
            }
            if (File.Exists(backuplogfiletxt))
            {
                ////This has a potential to fail and should be changed later     CHANGEME
                Random random = new Random();
                string randomintString = random.Next(0, 20).ToString();
                backuplogfiletxt = backuplogfiletxt + randomintString;
            }
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
        public static void noSupport()
        {
            Debug.Write("Windows Service Backup is not installable on this system");

        }
        public static string backupLocationStr()
        {
            string backupLocation = "";
            return backupLocation;
        }
        public static string backupTypeStr()
        {
            string backupType = "";
            return backupType;
        }
        public static string backupUsernameStr()
        {
            string backupUsername = "";
            return backupUsername;
        }
        public static string backupPasswordStr()
        {
            string backuppassword = "";
            return backuppassword;
        }
        public static string backupTargetStr()
        {
            string backupLocation = backupLocationStr();
            string backupUsername = backupUsernameStr();
            string backupPassword = backupPasswordStr();
            string backupType = backupTypeStr();
            var BackupTargetVar = "";


            switch (backupType.ToUpperInvariant())
            {
                case "NETWORKPATH":
                    if (!string.IsNullOrWhiteSpace(backupUsername))
                    {

                        if (!string.IsNullOrWhiteSpace(backupPassword))
                        {
                            BackupTargetVar = " $BackupTarget = New-WBBackupTarget -NetworkPath \"$location\" -Credential $Cred";
                            return BackupTargetVar;
                        }
                    }
                    else
                    {
                        BackupTargetVar = " $BackupTarget = New-WBBackupTarget -NetworkPath \"$location\"";
                        return BackupTargetVar;
                    }
                    return BackupTargetVar;

                case "DISK":
                    BackupTargetVar = " $BackupTarget = New-WBBackupTarget -Disk \"$location\"";
                    return BackupTargetVar;
                    
                case "VOLUME":
                    BackupTargetVar = " $BackupTarget = New-WBBackupTarget -Volume \"$location\"";
                    return BackupTargetVar;

                case "VOLUMEPATH":
                    BackupTargetVar = " $BackupTarget = New-WBBackupTarget -Volumepath \"$location\"";
                    return BackupTargetVar;
                default:
                    Console.Error.WriteLine("No Valid Backup Type Selected");
                    BackupTargetVar = "bad";
                    return BackupTargetVar;
            }

        }
        public static Boolean backupIsInstalled()
        {
            var ps = PowerShell.Create();
            ps.AddScript("import-module servermanager | Get-windowsFeature");
            var output = ps.Invoke();
            var windowsServerIsInstalled =
                            output.Where(item => (string)item.Members["Name"].Value == "Windows-Server-Backup")
                                .Select(item => item.Members["Installed"].Value).FirstOrDefault();

            if (windowsServerIsInstalled != null)
            {
                if (windowsServerIsInstalled.Equals("true"))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }
        public static Boolean backupIsInstallable()
        {
            var ps = PowerShell.Create();
            ps.AddScript("import-module servermanager | Get-windowsFeature");
            var output = ps.Invoke();
            var backupIsAvailable = output.Where(item => (string)item.Members["Name"].Value == "Windows-Server-Backup");

            if (backupIsAvailable != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static string backupConfigStr()
        {
            string backupConfig = File.ReadAllText(backupconfigFile);
            return backupConfig;
        }
        public static string[] backupConfigStringArr()
        {
            string backupConfigString = backupConfigStr();
            string[] backupStringArray = backupConfigString.Split(',');
            return backupStringArray;
        }
    }   
}
