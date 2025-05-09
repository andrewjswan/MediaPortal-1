@ECHO OFF

rem build init
set project=TVServer_Client
call BuildInit.bat %1

REM if [%2]==[] (set ARCH=x86) ELSE (set ARCH=%2)
set ARCH=x86

rem build
echo.
echo Writing GIT revision assemblies...
rem %DeployVersionGIT% /git="%GIT_ROOT%" /path="%TVLibrary%" >> %log%
%DeployVersionGIT% /git="%GIT_ROOT%" /path="%CommonMPTV%" >> %log%

echo.
echo Building TV Server...
set xml=Build_Report_%BUILD_TYPE%_TvLibrary.xml
set html=Build_Report_%BUILD_TYPE%_TvLibrary.html
set logger=/l:XmlFileLogger,"BuildReport\MSBuild.ExtensionPack.Loggers.dll";logfile=%xml%

"%MSBUILD_PATH%" %logger% /target:Rebuild /property:Configuration=%BUILD_TYPE%;Platform=%ARCH% "%TVLibrary%\TvLibrary.sln" >> %log%
BuildReport\msxsl %xml% _BuildReport_Files\BuildReport.xslt -o %html%

echo.
echo Building TV Client plugin...
set xml=Build_Report_%BUILD_TYPE%_TvPlugin.xml
set html=Build_Report_%BUILD_TYPE%_TvPlugin.html
set logger=/l:XmlFileLogger,"BuildReport\MSBuild.ExtensionPack.Loggers.dll";logfile=%xml%

"%MSBUILD_PATH%" %logger% /target:Rebuild /property:Configuration=%BUILD_TYPE% "%TVLibrary%\TvPlugin\TvPlugin.sln" >> %log%
BuildReport\msxsl %xml% _BuildReport_Files\BuildReport.xslt -o %html%

echo.
echo Reverting assemblies...
rem %DeployVersionGIT% /git="%GIT_ROOT%" /path="%TVLibrary%" /revert >> %log%
%DeployVersionGIT% /git="%GIT_ROOT%" /path="%CommonMPTV%" /revert >> %log%

echo.
echo Reading the GIT revision...
%DeployVersionGIT% /git="%GIT_ROOT%" /path="%CommonMPTV%" /GetVersion >> %log%
rem SET /p version=<version.txt >> %log%
SET version=%errorlevel%
DEL version.txt >> %log%

echo.
echo Building Installer...
"%progpath%\NSIS\makensis.exe" /DBUILD_TYPE=%BUILD_TYPE% /DVER_BUILD=%version% /DArchitecture=%ARCH% "%TVLibrary%\Setup\setup.nsi" >> %log%
