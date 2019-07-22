FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["SD2411.KPI2019.Web/SD2411.KPI2019.Web.csproj", "SD2411.KPI2019.Web/"]
RUN dotnet restore "SD2411.KPI2019.Web/SD2411.KPI2019.Web.csproj"
COPY . .
WORKDIR "/src/SD2411.KPI2019.Web"
RUN dotnet build "SD2411.KPI2019.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "SD2411.KPI2019.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SD2411.KPI2019.Web.dll"]