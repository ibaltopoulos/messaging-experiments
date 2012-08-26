@echo off
cls

REM Bootstrap some necessary tools.
IF NOT EXIST tools\nuget\NuGet.exe (
  wget http://ci.nuget.org:8080/guestAuth/repository/download/bt4/.lastSuccessful/Console/NuGet.exe
  mkdir tools\nuget
  mv -f NuGet.exe tools/nuget
)

IF NOT EXIST tools\mongo\bin\mongo.exe (
REM http://www.mongodb.org/dr/downloads.mongodb.org/win32/mongodb-win32-x86_64-2008plus-v2.0-latest.zip/download
  wget http://downloads.mongodb.org/win32/mongodb-win32-x86_64-2008plus-v2.0-latest.zip
  unzip mongodb-win32-x86_64-2008plus-v2.0-latest.zip
  mv mongodb-win32-x86_64-2008plus-v2.0-*/ tools/mongo
  mkdir -p tools/mongo/data/db
  rm mongodb-win32-x86_64-2008plus-v2.0-latest.zip
)

set EnableNuGetPackageRestore=true
tools\nuget\NuGet.exe install -OutputDirectory libs packages.config

set msbuild=c:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe
msbuild /p:TreatWarningsAsErrors=true /verbosity:minimal /nologo  projects\messaging\messaging.sln
@if ERRORLEVEL 1 pause