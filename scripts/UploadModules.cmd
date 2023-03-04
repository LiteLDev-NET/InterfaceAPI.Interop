@echo off

cd %~dp0..
setlocal enabledelayedexpansion

set LLNET_MODULE_REMOTE_PATH=https://github.com/LiteLDev-NET/Modules.git

@REM rem Process System Proxy
@REM for /f "tokens=3* delims= " %%i in ('Reg query "HKCU\Software\Microsoft\Windows\CurrentVersion\Internet Settings" /v ProxyEnable') do (
@REM     if %%i==0x1 (
@REM         echo [INFO] System Proxy enabled. Adapting Settings...
@REM         for /f "tokens=3* delims= " %%a in ('Reg query "HKCU\Software\Microsoft\Windows\CurrentVersion\Internet Settings" /v ProxyServer') do set PROXY_ADDR=%%a
@REM         set http_proxy=http://!PROXY_ADDR!
@REM         set https_proxy=http://!PROXY_ADDR!
@REM         echo [INFO] System Proxy enabled. Adapting Settings finished.
@REM         echo.
@REM     )
@REM )


echo [INFO] Fetching InteropServices to GitHub ...
echo.

for /f "delims=" %%i in ('git rev-parse --abbrev-ref HEAD') do set LLNET_MODULE_NOW_BRANCH=%%i
for /f "delims=" %%i in ('git describe --tags --always') do set LLNET_MODULE_NOW_TAG_LONG=%%i
for /f "delims=-" %%i in ('git describe --tags --always') do set LLNET_MODULE_NOW_TAG=%%i

echo LLNET_MODULE_NOW_BRANCH %LLNET_MODULE_NOW_BRANCH%
echo LLNET_MODULE_NOW_TAG_LONG %LLNET_MODULE_NOW_TAG_LONG%
echo LLNET_MODULE_NOW_TAG %LLNET_MODULE_NOW_TAG%
echo.

if not exist Modules/InterfaceAPI.Interop/LiteLoader.InterfaceAPI.Interop.dll (
    echo [WARNING] InterfaceAPI.Interop files no found. Pulling from remote...
    echo.
    git clone %LLNET_MODULE_REMOTE_PATH%
)

cd Modules
git fetch --all
git reset --hard origin/%LLNET_MODULE_NOW_BRANCH%
git checkout %LLNET_MODULE_NOW_BRANCH%
cd ..

echo.
echo [INFO] Fetching InterfaceAPI.Interop to GitHub finished
echo.

@REM remove InterfaceAPI.Interop directory in Modules
echo [INFO] Removing Modules\InterfaceAPI.Interop
rd /s /q Modules\InterfaceAPI.Interop

@REM copy InterfaceAPI.Interop to Modules
xcopy /e /y /i /q src\native\build\Release\LiteLoader.InterfaceAPI.Interop.Native.dll Modules\InterfaceAPI.Interop\
xcopy /e /y /i /q src\managed\LiteLoader.InterfaceAPI.Interop\bin\Release\net7.0\LiteLoader.InterfaceAPI.Interop.dll Modules\InterfaceAPI.Interop\

cd Modules
for /f "delims=" %%i in ('git status . -s') do set LLNET_MODULE_NOW_STATUS=%%i
if "%LLNET_MODULE_NOW_STATUS%" neq "" (
    echo [INFO] Modified files found.
    echo.
    git add .
    if "%LLNET_MODULE_NOW_BRANCH%" == "main" (
        git commit -m "From InterfaceAPI.Interop %LLNET_MODULE_NOW_TAG%"
        if [%2] == [release] (
            git tag %LLNET_MODULE_NOW_TAG%
        )
    ) else (
        git commit -m "From InterfaceAPI.Interop %LLNET_MODULE_NOW_TAG_LONG%"
    )
    echo.
    echo [INFO] Pushing to origin...
    echo.
    if [%1] neq [action] (
        git push origin %LLNET_MODULE_NOW_BRANCH%
        git push --tags origin %LLNET_MODULE_NOW_BRANCH%
    ) else (
        git push https://%USERNAME%:%REPO_KEY%@github.com/LiteLDev-NET/Modules.git %LLNET_MODULE_NOW_BRANCH%
        git push --tags https://%USERNAME%:%REPO_KEY%@github.com/LiteLDev-NET/Modules.git %LLNET_MODULE_NOW_BRANCH%
    )
    cd ..
    echo.
    echo [INFO] Upload finished.
    echo.
    goto Finish
) else (
    cd ..
    echo.
    echo.
    echo [INFO] No modified files found.
    echo [INFO] No need to Upgrade InterfaceAPI.Interop.
    goto Finish
)

:Finish
if [%1]==[action] goto End
timeout /t 3 >nul
:End