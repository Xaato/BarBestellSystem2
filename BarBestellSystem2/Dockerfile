FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["BarBestellSystem2/BarBestellSystem2.csproj", "BarBestellSystem2/"]
COPY ["Application/Application.csproj", "Application/"]
RUN dotnet restore "BarBestellSystem2/BarBestellSystem2.csproj"
COPY . .
WORKDIR "/src/BarBestellSystem2"
RUN dotnet build "BarBestellSystem2.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "BarBestellSystem2.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BarBestellSystem2.dll"]
