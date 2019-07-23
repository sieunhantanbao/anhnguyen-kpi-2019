FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["src/Hosts/SD2411.KPI2019.Host/SD2411.KPI2019.Host.csproj", "src/Hosts/SD2411.KPI2019.Host/"]
RUN dotnet restore "src/Hosts/SD2411.KPI2019.Host/SD2411.KPI2019.Host.csproj"
COPY . .
WORKDIR "/src/src/Hosts/SD2411.KPI2019.Host"
RUN dotnet build "SD2411.KPI2019.Host.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "SD2411.KPI2019.Host.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SD2411.KPI2019.Host.dll"]