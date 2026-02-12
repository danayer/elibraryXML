@echo off
REM Batch file to build and run eLibrary XML Application

echo ========================================
echo eLibrary XML Application
echo ========================================
echo.

REM Check if .NET SDK is installed
where dotnet >nul 2>nul
if %ERRORLEVEL% NEQ 0 (
    echo ERROR: .NET SDK not found!
    echo Please install .NET 8.0 SDK from https://dotnet.microsoft.com/download
    pause
    exit /b 1
)

echo Building application...
cd elibraryXMLApp
dotnet build -c Release

if %ERRORLEVEL% EQU 0 (
    echo.
    echo Build successful!
    echo.
    echo Running application...
    dotnet run
) else (
    echo.
    echo ERROR: Build failed!
    pause
    exit /b 1
)
