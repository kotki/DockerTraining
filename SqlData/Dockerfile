FROM microsoft/mssql-server-linux
ENV SA_PASSWORD=Passw0rd
ENV ACCEPT_EULA=Y
COPY SqlData/Scripts ./Scripts
CMD ["bin/bash", "-c", "sleep 20s \
&& for f in ./Scripts/*.sql; do /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P Passw0rd -d master -i $f; done \
& /opt/mssql/bin/sqlservr"]