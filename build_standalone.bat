@echo off
REM ========================================
REM Standalone Build Script for eLibrary XML
REM Creates a self-contained Windows executable
REM ========================================

echo.
echo ========================================
echo eLibrary XML Application
echo Standalone Build for Windows
echo ========================================
echo.

REM Check if .NET SDK is installed
where dotnet >nul 2>nul
if %ERRORLEVEL% NEQ 0 (
    echo ERROR: .NET SDK not found!
    echo.
    echo Please install .NET 8.0 SDK from:
    echo https://dotnet.microsoft.com/download/dotnet/8.0
    echo.
    pause
    exit /b 1
)

echo Checking .NET version...
dotnet --version
echo.

cd elibraryXMLApp

REM Clean previous builds
echo Cleaning previous builds...
if exist bin\Release rd /s /q bin\Release
if exist obj rd /s /q obj
echo.

REM Build standalone version
echo ========================================
echo Building standalone executable...
echo This will take a few minutes...
echo ========================================
echo.
echo Configuration:
echo - Target: Windows x64
echo - Self-contained: Yes (includes .NET Runtime)
echo - Single file: Yes
echo - Size: ~150-200 MB
echo.

dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true -p:PublishTrimmed=false

if %ERRORLEVEL% EQU 0 (
    echo.
    echo ========================================
    echo Build SUCCESSFUL!
    echo ========================================
    echo.
    echo Executable location:
    echo %CD%\bin\Release\net8.0-windows\win-x64\publish\elibraryXMLApp.exe
    echo.
    echo File size:
    dir "%CD%\bin\Release\net8.0-windows\win-x64\publish\elibraryXMLApp.exe" | find "elibraryXMLApp.exe"
    echo.
    echo This is a STANDALONE executable that includes all dependencies.
    echo You can distribute this file without requiring .NET installation.
    echo.
    echo To create a distribution package:
    echo 1. Copy elibraryXMLApp.exe from the publish folder
    echo 2. Copy journal.xsd from the root folder
    echo 3. Create a ZIP archive
    echo.
) else (
    echo.
    echo ========================================
    echo Build FAILED!
    echo ========================================
    echo.
    echo Please check the error messages above.
    echo Common issues:
    echo - .NET SDK version is too old (need 8.0+)
    echo - Insufficient disk space
    echo - Build files are locked by another process
    echo.
    pause
    exit /b 1
)

cd ..
pause
