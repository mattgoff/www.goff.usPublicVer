FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env

WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Realease -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
EXPOSE 80 443
COPY --from=build-env /app/out .
VOLUME /app/db
ENTRYPOINT [ "dotnet", "www.goff.us.dll" ]



