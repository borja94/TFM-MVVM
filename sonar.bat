SonarScanner.MSBuild.exe begin /k:"TFM-MVVM"
MSBuild.exe /t:Rebuild
SonarScanner.MSBuild.exe end