FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["BarBestellSystem2/BarBestellSystem2.csproj", "./BarBestellSystem2/"]
COPY ["Application/Application.csproj", "./Application/"]
RUN dotnet restore "BarBestellSystem2/BarBestellSystem2.csproj"
COPY . .
RUN dotnet build "BarBestellSystem2/BarBestellSystem2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BarBestellSystem2/BarBestellSystem2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BarBestellSystem2.dll"]