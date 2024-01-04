@echo off
SETLOCAL EnableDelayedExpansion

set directory=%~dp0
set isCMD=0
if not "%~1"=="" (
	set directory=%~1
	set isCMD=1
)

if not "%~2"=="" (
	set external_output=%~2
)

cd /d "%directory%"
set input=..\..\HYFServer\HYFServer\Protos
set output=.\CSFiles
set grpc_root=.\grpc.tools\windows_x64

if not exist "%output%\" (
    mkdir "%output%"
)

REM 如果存在文件，删除这些文件
IF EXIST "%output%\*.cs" (
	del /Q "%output%\*.cs"
)

REM 生成cs文件
"%grpc_root%\protoc.exe" --plugin=protoc-gen-grpc="%grpc_root%\grpc_csharp_plugin.exe" --proto_path="%input%" --csharp_out="%output%" --grpc_out="%output%" "%input%\*.proto"

call :check_exit

REM 重命名文件
FOR %%F IN ("%output%\*.cs") DO (
    REM 获取不带扩展名的文件名
    SET "filename=%%~nF"
    REM 重命名文件
    REN "%%F" "!filename!.g.cs"
)
call :check_exit

REM 移动文件到目标目录
if "%external_output%" neq "" (
	if exist "%external_output%\*.cs" (
		del /Q "%external_output%\*.cs"
	)
	move "%output%\*.cs" "%external_output%"
)
call :check_exit

REM 不是CMD形式调用的时候
if %isCMD% equ 0 (
	if %ERRORLEVEL% equ 0 (
		echo Done.
	) else (
		echo Error.
	)
	
	pause
) else (
	exit /b %ERRORLEVEL%
)


:check_exit
if %isCMD% neq 0 (
	REM 检查退出码
	if %ERRORLEVEL% neq 0 (
		exit /b %ERRORLEVEL%
	)
)
goto :eof

REM 文件结尾
:eof