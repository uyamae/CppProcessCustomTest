cd /d %~dp0
set DSTDIR=.\CppProcessCustomTest\packages
if exist %DSTDIR% rmdir /Q /S %DSTDIR%
nuget install CppCustomTask -OutputDir %DSTDIR% -Source %CD%\CppCustomTask\bin\Debug