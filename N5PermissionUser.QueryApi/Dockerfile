#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["N5PermissionUser.QueryApi.csproj", "."]

RUN dotnet restore "./N5PermissionUser.QueryApi.csproj"

COPY . .
WORKDIR "/src/."
RUN dotnet build "N5PermissionUser.QueryApi.csproj" -c Release -o /app/build

# Ejecutar las migraciones
RUN dotnet ef database update --no-build --context N5PermissionUserContext

FROM build AS publish
RUN dotnet publish "N5PermissionUser.QueryApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "N5PermissionUser.QueryApi.dll"]
