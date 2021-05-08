ECHO off

rem batch file to run a script to create a db
rem 9/10/2020

rem sqlcmd -S localhost -E -i ygo_db.sql
sqlcmd -S localhost\sqlexpress -E -i ygo_db.sql
rem sqlcmd -S localhost\mssqlserver -E -i ygo_db.sql


ECHO .
ECHO if no error messages appear DB was created
PAUSE
