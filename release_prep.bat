@echo off

set WD=%CD%

REM --------------------- Release Cleanup ---------------------
pushd GW2PAO\bin\x86\Release
xcopy de\GW2PAO.resources.dll Locale\de\ /Y
xcopy es\GW2PAO.resources.dll Locale\es\ /Y
xcopy fr\GW2PAO.resources.dll Locale\fr\ /Y
xcopy ru\GW2PAO.resources.dll Locale\ru\ /Y
xcopy ko\GW2PAO.resources.dll Locale\ko\ /Y
rd /S /Q en 2>NUL
rd /S /Q it 2>NUL
rd /S /Q ja 2>NUL
rd /S /Q ko 2>NUL
rd /S /Q ru 2>NUL
rd /S /Q zh-Hans 2>NUL
rd /S /Q zh-Hant 2>NUL
rd /S /Q de 2>NUL
rd /S /Q es 2>NUL
rd /S /Q fr 2>NUL
rd /S /Q hu 2>NUL
rd /S /Q ro 2>NUL
rd /S /Q sv 2>NUL
rd /S /Q pt-BR 2>NUL
del /Q *.xml 2>NUL
del /Q *.pdb 2>NUL
del /Q BitFactory.dll 2>NUL
del /Q GW2NET.* 2>NUL
del /Q GW2PAO.*.dll 2>NUL
del /Q GwApiNET.dll 2>NUL
del /Q Hardcodet.Wpf.TaskbarNotification.dll 2>NUL
del /Q Intellibox.dll 2>NUL
del /Q Microsoft.Expression.* 2>NUL
del /Q Microsoft.Practices.* 2>NUL
del /Q Microsoft.Xaml.Behaviors.* 2>NUL
del /Q Newtonsoft.Json.dll 2>NUL
del /Q NHotkey.* 2>NUL
del /Q NLog.dll 2>NUL
del /Q OxyPlot.* 2>NUL
del /Q RestSharp.dll 2>NUL
del /Q SLF.* 2>NUL
del /Q System.Windows.Interactivity.dll 2>NUL
del /Q TS3QueryLib.Core.Framework.dll 2>NUL
del /Q Xceed.Wpf.* 2>NUL
del /Q FileDb* 2>NUL
del /Q ImageFileCache.WPF.* 2>NUL
del /Q MapControl.WPF.* 2>NUL
del /Q FontAwesome.Sharp.* 2>NUL
del /Q *.vshost.* 2>NUL
del /Q Logs/* 2>NUL
del /Q UserData/* 2>NUL
popd

xcopy AnetCopyright.txt GW2PAO\bin\x86\Release\ /Y
xcopy LICENSE.txt GW2PAO\bin\x86\Release\ /Y
xcopy ThirdPartyLicenses.txt GW2PAO\bin\x86\Release\ /Y
xcopy Tasks GW2PAO\bin\x86\Release\Tasks\ /Y /S /E
xcopy Drawings GW2PAO\bin\x86\Release\Drawings\ /Y /S /E

REM --------------------- Release_NoBrowser ---------------------
pushd GW2PAO\bin\x86\Release_WithoutBrowser
xcopy de\GW2PAO.resources.dll Locale\de\ /Y
xcopy es\GW2PAO.resources.dll Locale\es\ /Y
xcopy fr\GW2PAO.resources.dll Locale\fr\ /Y
xcopy ru\GW2PAO.resources.dll Locale\ru\ /Y
xcopy ko\GW2PAO.resources.dll Locale\ko\ /Y
rd /S /Q de 2>NUL
rd /S /Q en 2>NUL
rd /S /Q es 2>NUL
rd /S /Q fr 2>NUL
rd /S /Q it 2>NUL
rd /S /Q ja 2>NUL
rd /S /Q ko 2>NUL
rd /S /Q ru 2>NUL
rd /S /Q zh-Hans 2>NUL
rd /S /Q zh-Hant 2>NUL
rd /S /Q hu 2>NUL
rd /S /Q ro 2>NUL
rd /S /Q sv 2>NUL
rd /S /Q pt-BR 2>NUL
del /Q *.xml 2>NUL
del /Q *.pdb 2>NUL
del /Q BitFactory.dll 2>NUL
del /Q GW2NET.* 2>NUL
del /Q GW2PAO.*.dll 2>NUL
del /Q GwApiNET.dll 2>NUL
del /Q Hardcodet.Wpf.TaskbarNotification.dll 2>NUL
del /Q Intellibox.dll 2>NUL
del /Q Microsoft.Expression.* 2>NUL
del /Q Microsoft.Practices.* 2>NUL
del /Q Microsoft.Xaml.Behaviors.* 2>NUL
del /Q Newtonsoft.Json.dll 2>NUL
del /Q NHotkey.* 2>NUL
del /Q NLog.dll 2>NUL
del /Q OxyPlot.* 2>NUL
del /Q RestSharp.dll 2>NUL
del /Q SLF.* 2>NUL
del /Q System.Windows.Interactivity.dll 2>NUL
del /Q TS3QueryLib.Core.Framework.dll 2>NUL
del /Q Xceed.Wpf.* 2>NUL
del /Q avcodec-53.dll 2>NUL
del /Q avformat-53.dll 2>NUL
del /Q avutil-51.dll 2>NUL
del /Q Awesomium* 2>NUL
del /Q icudt.dll 2>NUL
del /Q inspector.pak 2>NUL
del /Q libEGL.dll 2>NUL
del /Q libGLESv2.dll 2>NUL
del /Q xinput9_1_0.dll 2>NUL
del /Q pdf_js.pak 2>NUL
del /Q FileDb* 2>NUL
del /Q ImageFileCache.WPF.* 2>NUL
del /Q MapControl.WPF.* 2>NUL
del /Q FontAwesome.Sharp.* 2>NUL
del /Q *.vshost.* 2>NUL
del /Q Logs/* 2>NUL
del /Q UserData/* 2>NUL
popd

xcopy AnetCopyright.txt GW2PAO\bin\x86\Release_WithoutBrowser\ /Y
xcopy LICENSE.txt GW2PAO\bin\x86\Release_WithoutBrowser\ /Y
xcopy ThirdPartyLicenses.txt GW2PAO\bin\x86\Release_WithoutBrowser\ /Y
xcopy Tasks GW2PAO\bin\x86\Release_WithoutBrowser\Tasks\ /Y /S /E
xcopy Drawings GW2PAO\bin\x86\Release_WithoutBrowser\Drawings\ /Y /S /E

cd /d "%WD%"
