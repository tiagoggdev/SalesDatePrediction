#!/bin/bash

/opt/mssql/bin/sqlservr &

echo "Waiting SQLServer init"
sleep 20

for file in /init-db/*.sql; do
  /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P 'salesPred314!' -i "$file"
done

wait
¿