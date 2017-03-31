$items = Get-ChildItem -Path "C:\ProgramData\chocolatey\lib\docker\tools"
 
# enumerate the items array
foreach ($item in $items)
{
      # if the item is a directory, then process it.
     
            Write-Host $item.Name
    
}
#Test-Path "C:\Program Files\Docker\dockercli.exe"
 #& 'C:\Program Files\Docker\DockerCli.exe' -SwitchDaemon
