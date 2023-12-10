@echo off

REM Start Python HTTP server
start cmd /k "py -m http.server 8000"

REM Keep the console window open
pause