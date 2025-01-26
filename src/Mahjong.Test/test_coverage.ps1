Set-Location (Split-Path -Parent $MyInvocation.MyCommand.Path)
dotnet test --collect:"XPlat Code Coverage" 
$coverageFile = (Get-ChildItem -Path ".\TestResults" -Recurse -Include "*.xml"  | Sort-Object -Descending LastWriteTime)[0].FullName
Write-Output $coverageFile
$coverageDir = (Split-Path -Parent $coverageFile)
Write-Output $coverageDir
reportgenerator -reports:$coverageFile -targetdir:$coverageDir -reporttypes:Html
Invoke-Item ($coverageDir + "\index.html")