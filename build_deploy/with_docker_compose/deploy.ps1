# VARIABLES
$tykGatewaySecret = "HkGtmaCEJxkBxvxihLwwFNlE4RYMjnwV"

#Deploy Application
write-host -ForegroundColor Yellow "----Deploying the application-----"
write-host ""
try
{
    docker-compose -f ".\docker-compose.yml" down
    docker-compose -f ".\docker-compose.yml" up -d 
}
catch 
{
    Write-Error "Error when deploying the application. File .\with_docker_compose\docker-compose.yml"
    write-host ""
    read-host -Prompt "Please press Enter to close this window"
    exit 1
}

#Deploy and Setup Tyk
write-host -ForegroundColor Yellow "----Deploying the Tyk Gateway-----"
write-host ""
try
{
    docker-compose -f ".\docker-compose.tyk.yml" down
    docker-compose -f ".\docker-compose.tyk.yml" up -d 
}
catch 
{
    Write-Error "Error when deploying the Tyk Gateway. File .\with_docker_compose\docker-compose.tyk.yml"
    write-host ""
    read-host -Prompt "Please press Enter to close this window"
    exit 2
}

write-host -ForegroundColor Yellow "----Setting up the Tyk Gateway-----"
write-host ""

try
{
    # Convert window path to Linux (bash) path
    $linuxTykPath = wsl wslpath "..\\tyk\\"
    $linuxSetupPath = wsl wslpath "..\\tyk\\setup_account.sh"
    $linuxPythonPath = wsl wslpath "..\\tyk\\setup.py"
    # Run the bash
    bash $linuxSetupPath $linuxPythonPath $linuxTykPath
}
catch
{
    write-error "Error when setting up TYK"
    write-host ""
    read-host -Prompt "Please press Enter to close this window"
    exit 3
}

write-host -ForegroundColor Yellow "----Importing the Tyk Gateway APIs definitions-----"
write-host ""

try
{
    cd "..\tyk"
    $userAuth = Get-Content -Path ./userAuth.txt
    .\API_Upload.ps1  -apiPath ".\definition" -tykAuthorizationKey $userAuth -tykgatewaySecret $tykGatewaySecret
    Remove-Item -Path .\userAuth.txt -force | out-null
}
catch
{
    Remove-Item -Path .\userAuth.txt -force | out-null
    write-error "Error when importing the TYK APIs definitions"
    write-host ""
    read-host -Prompt "Please press Enter to close this window"
    exit 4
}

echo "Client URL: http://localhost:82"
echo "Client sample login: sieunhantanbao@gmail.com/Admin123!@#"
# Remove all dangling images
docker rmi -f (docker images -f "dangling=true" -q)
read-host -Prompt "Please press Enter to close this window"