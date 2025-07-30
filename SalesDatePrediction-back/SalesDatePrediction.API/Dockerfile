FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SalesDatePrediction.API/SalesDatePrediction.API.csproj", "SalesDatePrediction.API/"]
COPY ["SalesDatePrediction.Application/SalesDatePrediction.Application.csproj", "SalesDatePrediction.Application/"]
COPY ["SalesDatePrediction.Infrastructure/SalesDatePrediction.Infrastructure.csproj", "SalesDatePrediction.Infrastructure/"]
COPY ["SalesDatePrediction.Domain/SalesDatePrediction.Domain.csproj", "SalesDatePrediction.Domain/"]
RUN dotnet restore "./SalesDatePrediction.API/SalesDatePrediction.API.csproj"
COPY . .
WORKDIR "/src/SalesDatePrediction.API"
RUN dotnet build "./SalesDatePrediction.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SalesDatePrediction.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SalesDatePrediction.API.dll"]