@echo off

set WD=%CD%

set VERSION=%1
if [%VERSION%]==[] (
    echo ERROR: Missing parameter VERSION
    exit /B 1
)

if exist GW2PAO\bin\x86\Release (
    pushd GW2PAO\bin\x86\Release
    del /Q Logs\* 2>NUL
    del /Q UserData\* 2>NUL
    del /Q debug.log 2>NUL

    del /Q "..\..\..\..\GW2PAO_%VERSION%.zip" 2>NUL
    call :Zip "..\..\..\..\GW2PAO_%VERSION%.zip"
    popd
)

if exist GW2PAO\bin\x86\Release_WithoutBrowser (
    pushd GW2PAO\bin\x86\Release_WithoutBrowser
    del /Q Logs\* 2>NUL
    del /Q UserData\* 2>NUL
    del /Q debug.log 2>NUL

    del /Q "..\..\..\..\GW2PAO_%VERSION%_NoBrowser.zip" 2>NUL
    call :Zip "..\..\..\..\GW2PAO_%VERSION%_NoBrowser.zip"
    popd
)

cd /d "%WD%"
goto :eof

:Zip
powershell -ExecutionPolicy Unrestricted -NoProfile -NonInteractive -Command "& {Add-Type -AssemblyName System.IO.Compression.FileSystem; [System.IO.Compression.ZipFile]::CreateFromDirectory('.', '%1', 0, $false)}"
exit /B
