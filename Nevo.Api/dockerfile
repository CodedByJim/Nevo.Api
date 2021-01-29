FROM mcr.microsoft.com/dotnet/sdk:5.0.102-ca-patch-buster-slim AS build
WORKDIR /app

COPY ./ ./

RUN dotnet restore

WORKDIR /app/Nevo.Api
RUN ls
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:latest AS runtime
WORKDIR /app
COPY --from=build /app/Nevo.Api/out ./
COPY --from=build /app/Nevo.Api/appsettings.docker.json ./appsettings.json
COPY --from=build /app/Nevo.Data/SQLite/nevo.db ./nevo.db

ENV ASPNETCORE_URLS="https://+;http://+"
ENV ASPNETCORE_CAPTURESTARTUPERRORS=true
ENV ASPNETCORE_DETAILEDERRORS=true
ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_HTTPS_PORT=443
ENV ASPNETCORE_URLS=https://*:443;http://*:80
ENV ASPNETCORE_SHUTDOWNTIMEOUTSECONDS=300
ENV ASPNETCORE_WEBROOT=wwwroot
ENV ASPNETCORE_Kestrel__Certificates__Default__Path="./webserver.pfx"
ENV ASPNETCORE_Kestrel__Certificates__Default__Password="1234"
RUN openssl req -new -nodes -x509 -newkey rsa:4096 -keyout key.pem -out cert.pem -subj "/C=NL/ST=Amsterdam/L=Amsterdam/O=CodedByJim/CN=localhost.local" -days 36525
RUN openssl pkcs12 -export -out webserver.pfx -inkey key.pem -in cert.pem -password pass:$ASPNETCORE_Kestrel__Certificates__Default__Password

ENTRYPOINT ["dotnet", "Nevo.Api.dll"]
EXPOSE 80 443