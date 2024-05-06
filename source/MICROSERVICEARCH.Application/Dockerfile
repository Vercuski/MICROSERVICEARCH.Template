FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER app
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MICROSERVICEARCH.Application/MICROSERVICEARCH.Application.csproj", "MICROSERVICEARCH.Application/"]
RUN dotnet restore "./MICROSERVICEARCH.Application/MICROSERVICEARCH.Application.csproj"
COPY . .
WORKDIR "/src/MICROSERVICEARCH.Application"
RUN dotnet build "./MICROSERVICEARCH.Application.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MICROSERVICEARCH.Application.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MICROSERVICEARCH.Application.dll"]