###########################################################################################
####################Script Created By Blake Morgan#########################################
####################  Backup	 10/14/2015#################################################
###########################################################################################
##################### User Defined Variables###############################################
$companyName = "The Larrabee Center"
$compName = "$env:computername.$env:userdnsdomain"
$emailTo = "bmorgan@maxtechseattle.com"
$emailFrom = "msm@maxtechseattle.com"
$smtpServer = "mail.maxtechseattle.com"
$pathType = "NETWORKPATH"
$location = "Z:\"
$credential = ""
$directory = "C:\maxtech"
$dirExists = Test-Path $directory
$logFile = "C:\maxtech\log.txt"
$fileExists = Test-Path $logFile
$sucStr = "The backup operation completed"

####################################### Create Directory if it Does not exist######################
If ($dirExists -eq $false) {New-Item -Path $directory -type directory}
If ($fileExists -eq $false) {New-Item -Path $logfile -type file}

################################ Install Backup If not Installed##################################
Import-module ServerManager
Add-WindowsFeature Windows-Server-Backup
#########################Create Backup Job#########################################
$backupPolicy = New-WBPolicy
Add-WBBareMetalRecovery �Policy $backupPolicy
if($pathType -like "NetworkPath"){$BackupLocation = New-WBBackupTarget -NetworkPath "$location"}
if($pathType -like "Disk"){$BackupLocation = New-WBBackupTarget -Disk "$location"}
if($pathType -like "Volume"){$BackupLocation = New-WBBackupTarget -Volume "$location"}
if($pathType -like "Volume"){$BackupLocation = New-WBBackupTarget -Volumepath "$location"}
Add-WBBackupTarget -Policy $backupPolicy -Target $BackupLocation
###############################################################################################
