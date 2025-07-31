FROM mcr.microsoft.com/mssql/server:2019-latest

ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=salesPred314!
ENV MSSQL_PID=Developer

USER root

# Instala sqlcmd
RUN apt-get update && \
    apt-get install -y curl gnupg apt-transport-https && \
    curl https://packages.microsoft.com/keys/microsoft.asc | apt-key add - && \
    curl https://packages.microsoft.com/config/debian/10/prod.list > /etc/apt/sources.list.d/mssql-release.list && \
    apt-get update && \
    ACCEPT_EULA=Y apt-get install -y mssql-tools unixodbc-dev && \
    echo 'export PATH="$PATH:/opt/mssql-tools/bin"' >> ~/.bashrc && \
    apt-get clean && \
    rm -rf /var/lib/apt/lists/*

# Copia scripts y entrypoint
COPY ./init-db/ /init-db/
COPY ./entrypoint.sh /entrypoint.sh

RUN chmod +x /entrypoint.sh
USER mssql

CMD [ "/entrypoint.sh" ]
