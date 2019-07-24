FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["src/Hosts/SD2411.KPI2019.HostStandard/SD2411.KPI2019.HostStandard.csproj", "src/Hosts/SD2411.KPI2019.HostStandard/"]
RUN dotnet restore "src/Hosts/SD2411.KPI2019.HostStandard/SD2411.KPI2019.HostStandard.csproj"
COPY . .
WORKDIR "/src/src/Hosts/SD2411.KPI2019.HostStandard"
RUN dotnet build "SD2411.KPI2019.HostStandard.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "SD2411.KPI2019.HostStandard.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SD2411.KPI2019.HostStandard.dll"]