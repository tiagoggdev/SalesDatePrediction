echo "Esperando a que SQL Server esté listo..."
sleep 15

/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "YourStrong!Pass123" -d master -i /init-db/DBSetup.sql
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "YourStrong!Pass123" -d StoreSample -i /init-db/create-view-for-back.sql
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "YourStrong!Pass123" -d StoreSample -i /init-db/spneworder.sql

echo "Scripts ejecutados correctamente."

exec /opt/mssql/bin/sqlservr