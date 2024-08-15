#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Client/MultiTenantJobTracking.Client/MultiTenantJobTracking.Client.csproj", "src/Client/MultiTenantJobTracking.Client/"]
COPY ["src/Common/MultiTenantJobTracking.Common/MultiTenantJobTracking.Common.csproj", "src/Common/MultiTenantJobTracking.Common/"]
RUN dotnet restore "./src/Client/MultiTenantJobTracking.Client/./MultiTenantJobTracking.Client.csproj"
COPY . .
WORKDIR "/src/src/Client/MultiTenantJobTracking.Client"
RUN dotnet build "./MultiTenantJobTracking.Client.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MultiTenantJobTracking.Client.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MultiTenantJobTracking.Client.dll"]