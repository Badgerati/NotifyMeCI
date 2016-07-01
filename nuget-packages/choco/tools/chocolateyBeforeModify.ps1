# Grab and stop any open processes
$tasks = tasklist /FI 'IMAGENAME eq NotifyMeCI.GUI.exe'
$processes = $tasks | Where-Object { $_ -match 'NotifyMeCI.GUI.exe' }
$count = ($processes | Measure-Object).Count

if ($count -gt 0)
{
    Write-Host 'Closing current instances of NotifyMeCI before modifying'
    taskkill /F /IM NotifyMeCI.GUI.exe | Out-Null

    try
    {
        $reopenPath = Join-Path $env:chocolateyPackageFolder 'tools/.reopen'
        New-Item -ItemType File $reopenPath -Force | Out-Null
    }
    catch { }
}
