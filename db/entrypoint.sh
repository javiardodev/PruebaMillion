#!/bin/bash

echo " *******running sqlservr service********* "
#start SQL Server, start the script to create/setup the DB 
./configure-db.sh & /opt/mssql/bin/sqlservr