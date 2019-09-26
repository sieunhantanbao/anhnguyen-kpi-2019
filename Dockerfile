FROM mcr.microsoft.com/dotnet/core/sdk:3.0.100 AS build
WORKDIR /app

EXPOSE 80
EXPOSE 443

COPY . ./

RUN sed -i 's#<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="3.0.0" />#<PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="3.0.0" />#' src/SD2411.KPI2019.HostStandard/SD2411.KPI2019.HostStandard.csproj
RUN sed -i 's/UseSqlServer/UseSqlite/' src/SD2411.KPI2019.HostStandard/Startup.cs
RUN sed -i 's/"DefaultConnection": ".*"/"DefaultConnection": "Data Source=sd2411-kpi2019.db"/' src/SD2411.KPI2019.HostStandard/appsettings.json

RUN rm src/SD2411.KPI2019.HostStandard/Migrations/*

RUN dotnet tool install --global dotnet-ef --version 3.0.0

ENV PATH="${PATH}:/root/.dotnet/tools"

RUN dotnet restore && dotnet build \
    && cd src/SD2411.KPI2019.HostStandard \
    && dotnet ef migrations add initialSchema \
    && dotnet ef database update

RUN dotnet build -c Release \
	&& cd src/SD2411.KPI2019.HostStandard \
	&& dotnet build -c Release \
	&& dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0.0

WORKDIR /app	
COPY --from=build /app/src/SD2411.KPI2019.HostStandard/out ./
COPY --from=build /app/src/SD2411.KPI2019.HostStandard/sd2411-kpi2019.db ./

ENTRYPOINT ["dotnet", "SD2411.KPI2019.HostStandard.dll"]
