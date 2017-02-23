$ErrorActionPreference = 'Stop';

$packageName    = 'NotifyMeCI'
$toolsDir       = "$(Split-Path -parent $MyInvocation.MyCommand.Definition)"
$url            = 'https://github.com/Badgerati/NotifyMeCI/releases/download/v$version$/$version$-Binaries.zip'
$checksum       = '$checksum$'
$checksumType   = 'sha256'

$packageArgs = @{
  PackageName   = $packageName
  UnzipLocation = $toolsDir
  Url           = $url
  Checksum      = $checksum
  ChecksumType  = $checksumType
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
$reopenPath = Join-Path $env:chocolateyPackageFolder 'tools/.reopen'
if ($count -gt 0 -or (Test-Path $reopenPath))
{
    Write-Host 'Re-opening NotifyMeCI'
    Start-Process NotifyMeCI.GUI.exe
}

if (Test-Path $reopenPath)
{
    try
    {
        Remove-Item -Path $reopenPath -Force | Out-Null
    }
    catch { }
}
