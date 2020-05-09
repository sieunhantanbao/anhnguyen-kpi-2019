Param
    (
        [Parameter(Mandatory=$true)]$apiPath,
        [Parameter(Mandatory=$true)]$tykAuthorizationKey,
        [Parameter(Mandatory=$true)]$tykgatewaySecret
    )
	$tykDashboardHost = "localhost:3000"
	$srcFileList = Get-ChildItem -Path "$apiPath" -Filter "*.json"
	$srcFilecount = ($srcFileList| measure).Count
        if($srcFilecount -eq 0){
        echo "File count is $srcFilecount .So exiting script."
        exit 2
        }
    $headers = @{
        host = $tykDashboardHost
		authorization = $tykAuthorizationKey
	}
	foreach($srcFile in $srcFileList){
		echo "Updating from file: $srcFile"
		$body = Get-Content "$apiPath\$srcFile"
		$body = "{`"api_model`":{},`"api_definition`": $body ,`"hook_references`":[],`"is_site`":false,`"sort_by`":0}"
		try{
			$result = Invoke-RestMethod -Method 'POST' -Uri "http://$tykDashboardHost/api/apis" -Headers $headers -ContentType "application/json" -Body $body
		}catch{
			echo $_.Exception.Message
			echo $_.Exception.ItemName
		}
	}
exit 0