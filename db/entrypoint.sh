#!/bin/bash

/opt/mssql/bin/sqlservr &

echo "Esperando a que SQL Server inicie..."
sleep 20

for file in /init-db/*.sql; do
  echo "Ejecutando $file"
  /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P 'salesPred314!' -i "$file"
done

wait
¿