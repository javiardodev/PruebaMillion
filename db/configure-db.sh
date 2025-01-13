#!/bin/bash

#wait for the SQL Server to come up
sleep 30s

echo "======== MSSQL SERVER STARTED =========" 
echo " *******running set up script********* "
#run the setup script to create the DB and the schema in the DB
/opt/mssql-tools18/bin/sqlcmd -S mssql-db -U sa -P $MSSQL_SA_PASSWORD -C -d master -i ./db/setup-db.sql
echo "======== MSSQL CONFIG COMPLETE ========"