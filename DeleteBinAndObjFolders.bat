@ECHO off
cls

ECHO Deleting all BIN and OBJ folders...
ECHO.

FOR /d /r . %%d in (bin,obj) DO (
	IF EXIST "%%d" (		 	 
		ECHO %%d | FIND /I "\node_modules\" > Nul && ( 
			ECHO.Skipping: %%d
		) || (
			ECHO.Deleting: %%d
			rd /s/q "%%d"
		)
	)
)

ECHO.
ECHO.BIN and OBJ folders have been successfully deleted.
ECHO Press any key to exit.
ECHO pause > nul