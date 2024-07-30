#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/WebApi/MultiTenantJobTracking.WebApi/MultiTenantJobTracking.WebApi.csproj", "src/WebApi/MultiTenantJobTracking.WebApi/"]
COPY ["src/Business/MultiTenantJobTracking.Business/MultiTenantJobTracking.Business.csproj", "src/Business/MultiTenantJobTracking.Business/"]
COPY ["src/DataAccess/MultiTenantJobTracking.DataAccess/MultiTenantJobTracking.DataAccess.csproj", "src/DataAccess/MultiTenantJobTracking.DataAccess/"]
RUN dotnet restore "./src/WebApi/MultiTenantJobTracking.WebApi/./MultiTenantJobTracking.WebApi.csproj"
COPY . .
WORKDIR "/src/src/WebApi/MultiTenantJobTracking.WebApi"
RUN dotnet build "./MultiTenantJobTracking.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MultiTenantJobTracking.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MultiTenantJobTracking.WebApi.dll"]