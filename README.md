# ANHNGUYEN - KPI - 2019

### Build Status


| Build server    | Platform       | Status      |
|-----------------|----------------|-------------|
| Azure Pipelines | Docker         |[![Build status](https://dev.azure.com/nguyensieuanh/anhnguyen-kpi-2019/_apis/build/status/GitHub_Source/Source%20GitHub%20CI%20YML)](https://dev.azure.com/nguyensieuanh/anhnguyen-kpi-2019/_build/latest?definitionId=4)

### Online Demo (Azure) [Website is stopped]
- ~~https://sd2411-kpi-client.azurewebsites.net (sieunhantanbao@gmail.com/Admin123!@#)~~

### Docker
For testing only

- Step 1: Using below command to run API
> `docker run -p 81:80 sieunhantanbao/sd2411-kpi2019-api-testing`
- Step 2: Using below command to run Client
> `docker run -p 82:80 sieunhantanbao/sd2411-kpi2019-client-testing`
- Step 3: Open Google Chrome in [disabled security mode ](https://stackoverflow.com/questions/24290149/creating-google-chrome-shortcut-with-disable-web-security) (due to CORS issue) and visit
> [http://localhost:82](http://localhost:82) (sieunhantanbao@gmail.com/Admin123!@#)
### Try with your self
#### Prerequisites
- Visual Studio 2019 version 16.2 or later which support [.NET Core 3.0](https://dotnet.microsoft.com/download/dotnet-core)
- SQL Server
#### Steps to run
TBD
### Technologies and frameworks used
- ASP.NET CORE 3.0
- Entity Framework Core 3.0
- Angular 8.2.2