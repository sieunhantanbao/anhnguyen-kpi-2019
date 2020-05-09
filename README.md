# ANHNGUYEN - KPI - 2019

### High level architecture

![SD2411-KPI - Architecture](https://raw.githubusercontent.com/sieunhantanbao/anhnguyen-kpi-2019/master/sd2411-architecture.png)

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
- Visual Studio 2019 version 16.2 or later which support [.NET Core 3.1](https://dotnet.microsoft.com/download/dotnet-core) AND/OR Visual Studio Code.
- SQL Server
#### Steps to run
***By Visual Studio 2019***

- Step 1:  Update the ConnectionString in the file 
> `\src\SD2411.KPI2019.HostStandard\appsettings.json`
- Step 2: Open `Package Manager Console`and make sure the Default project `Hosts\SD2411.KPI2019.HostStandard` is selected, then run command:
> `Update-Database`
- Step 3: Make sure the project `SD2411.KPI2019.HostStandard`is as Startup Project, then press F5 to run back-end API.
- Step 4: Update the **baseUrl** to match with the back-end API URL that you see at step 3 in the **environment.prod.ts** file
> `\client\src\environments\environment.prod.ts`
- Step 5: Navigate to folder `client` then run bellow commands
> `npm install`

> `npm run start-dev`
- Step 6: Open Google Chrome and go to [http://localhost:4200](http://localhost:4200) and login with sieunhantanbao@gmail.com/Admin123!@#. You may need to run Google Chrome in [disabled security mode ](https://stackoverflow.com/questions/24290149/creating-google-chrome-shortcut-with-disable-web-security) (due to CORS issue).
 
***By Visual Studio Code***
- Step 1: At the root folder type  `dotnet build`  to build the `SD2411.KPI2019.sln` solution.
- Step 2:  Install `Entity Framework Core Tools` by run the command below
> `dotnet tool install --global dotnet-ef --version 3.0.0`
- Step 3:  Go to the `src\SD2411.KPI2019.HostStandard` open the `appsettings.json` file, update the connection string, then type  `dotnet ef database update`  to run migration. Then type  `dotnet run`  to launch the back-end API.
- Step 4: Update the **baseUrl** to match with the back-end API URL that you see at step 3 in the **environment.prod.ts** file
> `\client\src\environments\environment.prod.ts`
- Step 5: Navigate to folder `client` then run bellow commands
> `npm install`

> `npm run start-dev`
- Step 6: Open Google Chrome and go to [http://localhost:4200](http://localhost:4200) and login with sieunhantanbao@gmail.com/Admin123!@#. You may need to run Google Chrome in [disabled security mode ](https://stackoverflow.com/questions/24290149/creating-google-chrome-shortcut-with-disable-web-security) (due to CORS issue).
### Technologies and frameworks used
- ASP.NET Core 3.1
- Entity Framework Core 3.1
- Angular 8.2.2
