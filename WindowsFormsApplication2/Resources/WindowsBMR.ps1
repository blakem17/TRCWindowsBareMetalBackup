###########################################################################################
####################Script Created By Blake Morgan#########################################
####################  Backup	 10/14/2015#################################################
###########################################################################################
##################### User Defined Variables###############################################
$companyName = "Blakem"
$compName = "$env:computername.$env:userdnsdomain"
$emailTo = "me@blakemorgan.us"
$emailFrom = "me@blakemorgan.us"
$smtpServer = "smtp.o2.ie"
$pathType = "NETWORKPATH"
$location = "\\10.10.10.4\e"
$credential = ""
$directory = "C:\blakem"
$dirExists = Test-Path $directory
$logFile = "C:\blakem\log.txt"
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
Add-WBBareMetalRecovery -Policy $backupPolicy
if($pathType -like "NetworkPath"){$BackupLocation = New-WBBackupTarget -NetworkPath "$location"}
if($pathType -like "Disk"){$BackupLocation = New-WBBackupTarget -Disk "$location"}
if($pathType -like "Volume"){$BackupLocation = New-WBBackupTarget -Volume "$location"}
if($pathType -like "Volume"){$BackupLocation = New-WBBackupTarget -Volumepath "$location"}
Add-WBBackupTarget -Policy $backupPolicy -Target $BackupLocation
###############################################################################################
start-transcript -path $logFile 				####Start Backup Log
Start-WBBackup -Policy $backupPolicy			####startBackup
stop-transcript									#####End Backup Log

$log = Get-Content $logFile | out-string

if($log -contains $sucStr){send-mailmessage -to $emailTo -subject "Backup on $CompanyName $CompName was Successfull" -from $emailFrom -smtpserver $smtpServer -body "$log"}
if($log -notcontains $sucStr){send-mailmessage -to $emailTo -subject "Backup on $CompanyName $CompName Failed" -from $emailFrom -smtpserver $smtpServer -body "$log"}