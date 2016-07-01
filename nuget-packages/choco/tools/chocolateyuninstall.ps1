# Grab and stop any open processes
$tasks = tasklist /FI 'IMAGENAME eq NotifyMeCI.GUI.exe'
$processes = $tasks | Where-Object { $_ -match 'NotifyMeCI.GUI.exe' }
$count = ($processes | Measure-Object).Count

if ($count -gt 0)
{
    Write-Host 'Closing current instances of NotifyMeCI'
    taskkill /F /IM NotifyMeCI.GUI.exe | Out-Null
}
else
{
    Write-Host 'NotifyMeCI has no instances open'
}

$toolPath = Join-Path $env:chocolateyPackageFolder 'tools/NotifyMeCi'
if (Test-Path $toolPath)
{
    Write-Host 'Pre-cleanup of NotifyMeCI files'

    try
    {
        Remove-Item -Path $toolPath -Force -Recurse
    }
    catch { }
}
