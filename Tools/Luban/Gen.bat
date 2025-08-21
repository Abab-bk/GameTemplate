set WORKSPACE=.
set LUBAN_DLL=%WORKSPACE%\Luban\Luban.dll
set CONF_ROOT=.

dotnet %LUBAN_DLL% ^
    -t all ^
    -d bin ^
    -c cs-bin ^
    --conf %CONF_ROOT%\Luban.conf ^
    -x outputDataDir=..\..\Libs\DataBase\Assets ^
    -x outputCodeDir=..\..\Libs\DataBase\Scripts

pause