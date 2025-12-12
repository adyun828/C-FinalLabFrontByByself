@echo off
chcp 65001 >nul
echo ========================================
echo    Image Selection System Launcher
echo ========================================
echo.
echo Starting Backend...
echo.

cd /d "%~dp0Backend"
start "Backend API" cmd /k "dotnet run && pause"

timeout /t 5 /nobreak >nul

echo.
echo Starting Frontend...
echo.

cd /d "%~dp0Frontend"
start "Frontend App" cmd /k "dotnet run && pause"

echo.
echo ========================================
echo Both services are starting...
echo Backend: http://localhost:5000
echo Frontend: WPF Application Window
echo.
echo Test Accounts:
echo   admin / admin123
echo   testuser / test123
echo   user1 / password
echo ========================================
echo.
pause
