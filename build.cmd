@echo off
cls

REM Bootstrap some necessary tools.
IF NOT EXIST tools\nuget\NuGet.exe (
  wget http://ci.nuget.org:8080/guestAuth/repository/download/bt4/.lastSuccessful/Console/NuGet.exe
  mkdir tools\nuget
  mv -f NuGet.exe tools/nuget
)
set EnableNuGetPackageRestore=true
tools\nuget\NuGet.exe install -OutputDirectory libs packages.config