set WORKSPACE=.
set LUBAN_DLL=%WORKSPACE%\Luban\Luban.dll
set CONF_ROOT=.

dotnet %LUBAN_DLL% ^
    -t all ^
    -d json ^
    -c cs-dotnet-json ^
    --conf %CONF_ROOT%\Luban.conf ^
    -x outputDataDir=..\..\Libs\DataBase\Assets ^
    -x outputCodeDir=..\..\Libs\DataBase\Scripts

pause