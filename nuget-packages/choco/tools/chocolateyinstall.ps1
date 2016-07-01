$ErrorActionPreference = 'Stop';

$packageName= 'NotifyMeCI'
$toolsDir   = "$(Split-Path -parent $MyInvocation.MyCommand.Definition)"
$url        = 'https://github.com/Badgerati/NotifyMeCI/releases/download/v$version$/$version$-Binaries.zip'

$packageArgs = @{
  packageName   = $packageName
  unzipLocation = $toolsDir
  url           = $url
}

# Grab and stop any open processes first
$tasks = tasklist /FI 'IMAGENAME eq NotifyMeCI.GUI.exe'
$processes = $tasks | Where-Object { $_ -match 'NotifyMeCI.GUI.exe' }
$count = ($processes | Measure-Object).Count

if ($count -gt 0)
{
    Write-Host 'Closing current instances of NotifyMeCI'
    taskkill /F /IM NotifyMeCI.GUI.exe | Out-Null
}

# Install NotifyMeCI
Install-ChocolateyZipPackage @packageArgs

# Attempt to start NotifyMeCI again, if it was previously running
if ($count -gt 0)
{
    Write-Host 'Re-opening NotifyMeCI'
    Start-Process NotifyMeCI.GUI.exe
}
