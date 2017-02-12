﻿using System;
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
            Console.WriteLine("Creating and running backup");
            string backupconfigstring = backupConfigStr();
            string backupdaytime = DateTime.Now.ToString("MMddyyyyTHHmmss");
            string backuplogfile = backuplogdir + "\\" + backupdaytime;
            string backuplogfiletxt = backuplogdir + "\\" + backupdaytime + ".txt";

            //Checkig if Backup Log Directory Exits and if not creating it
            if (!Directory.Exists(backuplogdir))
            {
                Directory.CreateDirectory(backuplogdir);
                Console.WriteLine("Created BackupLog Directory");
            }
            if (File.Exists(backuplogfiletxt))
            {
                ////This has a potential to fail and should be changed later     CHANGEME
                Random random = new Random();
                string randomintString = random.Next(0, 20).ToString();
                backuplogfiletxt = backuplogfiletxt + randomintString;
            }
            ////Backup State is now running the script
            PowerShell psinstace = PowerShell.Create();
            psinstace.AddScript("");
            psinstace.AddScript("");
            psinstace.AddScript("");
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
            int i = 0;
            foreach (string st in backupConfigStringArr())
            {
                switch (i)
                {
                    case 0:
                        backupLocation = st;
                        break;
                    default:
                        Console.WriteLine("");
                        break;
                }

            }

            return backupLocation;
        }
        public static string backupTypeStr()
        {
            string backupType = "";
            int i = 0;
            foreach (string st in backupConfigStringArr())
            {
                switch (i)
                {
                    case 0:
                        i = i + 1;
                        break;
                    case 1:
                        backupType = st;
                        i = i + 1;
                        break;
                    default:
                        Console.WriteLine("Error Default switch");
                        break;
                }

            }

            return backupType;
        }
        public static string backupUsernameStr()
        {
            string backupUsername = "";
            int i = 0;
            foreach (string st in backupConfigStringArr())
            {
                switch (i)
                {
                    case 0:
                        i = i + 1;
                        break;
                    case 1:
                        i = i + 1;
                        break;
                    case 2:
                        backupUsername = st;
                        i = i + 1;
                        break;
                    default:
                        Console.WriteLine("Error Default switch");
                        break;
                }

            }
            return backupUsername;
        }
        public static string backupPasswordStr()
        {
            string backupPassword = "";
            int i = 0;
            foreach (string st in backupConfigStringArr())
            {
                switch (i)
                {
                    case 0:
                        i = i + 1;
                        break;
                    case 1:
                        i = i + 1;
                        break;
                    case 2:
                        i = i + 1;
                        break;
                    case 3:
                        backupPassword = st;
                        break;
                    default:
                        Console.WriteLine("Error Default switch");
                        break;
                }

            }
            return backupPassword;
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
        public static string backupScriptString()
        {
            string location = backupLocationStr();
            string username = backupUsernameStr();
            string password = backupPasswordStr();
            
            string serverManImport = "Import-Module -Name ServerManager";
            string backupPolicy = "$backupPolicy = New-WBPolicy";
            string backupPolicyAdd = "Add-WBBareMetalRecovery -Policy $backupPolicy";
            string backupTarget = backupTargetStr();
            string backupPolicyAddTarget = "Add-WBBackupTarget $BackupTarget -Policy $backupPolicy";
            string backupTargetiAdd = "$location = " + "\"" + backupTarget + "\"";
            string backupLocation = " $location = " + "\"" + location + "\"";
            string backupUserName = "$username = " + "\"" + username + "\"";
            string backupPassword = "$password = " + "\"" + password + "\"";
            string passToSecureString = "$SecurePassword = ConvertTo-SecureString -String $Password -AsPlainText -Force";
            string setcredentials = "$cred = New-Object -TypeName System.Management.Automation.PSCredential -Argumentlist $username, $SecurePassword";
            string startBackup = "Start-WBBackup -Policy $backupPolicy";

            string backupScript = "";
            return backupScript;
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
            if (File.Exists(backupconfigFile))
            {
                string backupConfig = File.ReadAllText(backupconfigFile);
                return backupConfig;
            }
            else
            {
                Console.WriteLine("ERROR No backup configuration please create one through the GUI");
                return null;
            }

        }
        public static string[] backupConfigStringArr()
        {
            string backupConfigString = backupConfigStr();
            string[] backupStringArray = backupConfigString.Split(',');
            return backupStringArray;
        }

    }   
}
