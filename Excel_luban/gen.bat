set WORKSPACE=..
set LUBAN_DLL=Tools\Luban\Luban.dll
set CONF_ROOT=.

dotnet %LUBAN_DLL% ^
    -t client ^
    -d bin ^
	-c cs-bin ^
    --conf %CONF_ROOT%\luban.conf ^
	-x outputCodeDir=../Assets/GameScript/HotUpdate/Config/lubanCodes ^
    -x outputDataDir=../Assets/GameScript/HotUpdate/Config/lubanBytes
	
pause