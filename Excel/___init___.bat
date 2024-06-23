@SET EXCEL_FOLDER=.\excel
@SET JSON_FOLDER=.\json
@SET CS_FOLDER=.\cs

@SET JSON_FOLDER_2=..\Assets\GameScript\HotUpdate\Config\json
@SET CS_FOLDER_2=..\Assets\GameScript\HotUpdate\Config\cs

@SET EXE=.\excel2json.exe

@ECHO Converting excel files in folder %EXCEL_FOLDER% ...
for /f "delims=" %%i in ('dir /b /a-d /s %EXCEL_FOLDER%\*.xlsx') do (
	@echo %%i | findstr /i /c:"WelfareMenuConfig.xlsx" /c:"CheckInConfig.xlsx" /c:"RechargeConfig.xlsx" /c:"TodayGiftConfig.xlsx" /c:"MainUIBtnConfig.xlsx" /c:"GuideStepConfig.xlsx" > nul   
	REM 这里的使用List形式        默认使用字典形式
    if errorlevel 1 (
        @echo   processing %%~nxi 
        @CALL %EXE% --excel %EXCEL_FOLDER%\%%~nxi --json %JSON_FOLDER%\%%~ni.json --csharp  %CS_FOLDER%\%%~ni.cs --header 3  --exclude_prefix #
        @CALL %EXE% --excel %EXCEL_FOLDER%\%%~nxi --json %JSON_FOLDER_2%\%%~ni.json --csharp  %CS_FOLDER_2%\%%~ni.cs --header 3 --exclude_prefix #
    ) else (
        @echo   processing %%~nxi 
        @CALL %EXE% --excel %EXCEL_FOLDER%\%%~nxi --json %JSON_FOLDER%\%%~ni.json --csharp  %CS_FOLDER%\%%~ni.cs --header 3 --a --exclude_prefix #
        @CALL %EXE% --excel %EXCEL_FOLDER%\%%~nxi --json %JSON_FOLDER_2%\%%~ni.json --csharp  %CS_FOLDER_2%\%%~ni.cs --header 3 --a --exclude_prefix #
    )
)