# TRCWindowsBareMetalBackup
This Latest Release has been tested on Server 2012 x64 only.

Curent DevBranch is ServiceSeperation

You can Now start a backup from the userinterface but it will lock up due to the lack of threading on the applcation, the backup is still running, you must be patient. 

When The application attempts to preform a backup It will create log files detailing the success or failure of the backup which are viewable in the main window.

There were also some major bugfixes, all of which were documented in the commit history.









Older Version Update:

At this point the software will install windows server backup on your windows server. It has some functionality for editing a powershell script that will install and run windows server backup("This powershell Script is being removed in the future");

The latest Commit on this project has added some new functionality but restrictions on using this software.

You must build the solution and run the setup exe.

You must be running it on a x64 machine or you will notice hangups.

You must be running it on windows server to use the start button.

The script editing functionality is fully there but if you try and run with the start button you will see exceptions being thrown.

I have removed the Email and logging functionality from the scripts for them to be readded later.


Older Versions.

user interface for updating a script file

You cannot push branch master to remote origin because there are new commits in the remote repository’s branch. Pushing this branch would result in a non-fast-forward update on the branch in the remote repository.


Future Plans for this project.
-Ability to run backups.
-Running a a windows service.
-Add logging functionality
-Add email functionality
-Add Backup set options(Daily, Rotating, and so on)
-Web portal for managing the backups?
