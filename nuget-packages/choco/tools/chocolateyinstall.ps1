$ErrorActionPreference = 'Stop';

$packageName= 'NotifyMeCI'
$toolsDir   = "$(Split-Path -parent $MyInvocation.MyCommand.Definition)"
$url        = 'https://github.com/Badgerati/NotifyMeCI/releases/download/v$version$/$version$-Binaries.zip'

$packageArgs = @{
  packageName   = $packageName
  unzipLocation = $toolsDir
  url           = $url
}

Install-ChocolateyZipPackage @packageArgs