@echo off
REM ========================================
REM Quick Build Script for eLibrary XML
REM Creates a small executable that requires .NET Runtime
REM ========================================

echo.
echo ========================================
echo eLibrary XML Application
echo Quick Build for Windows
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

REM Build release version
echo ========================================
echo Building executable...
echo ========================================
echo.
echo Configuration:
echo - Target: Windows x64
echo - Self-contained: No (requires .NET 8.0 Runtime)
echo - Single file: Yes
echo - Size: ~1-5 MB
echo.

dotnet publish -c Release -r win-x64 --self-contained false -p:PublishSingleFile=true

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
    echo IMPORTANT: This executable requires .NET 8.0 Runtime on the target PC.
    echo For standalone version without .NET requirement, use build_standalone.bat
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
