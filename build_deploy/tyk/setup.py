import requests 
import sys

DOCKER_IP = '127.0.0.1'
TYK_USERNAME = 'tyk.local@mycompany.com'
TYK_PASSWORD = 'MyCompany@2020'

# CREATE ORGANISATION
url = 'http://' + DOCKER_IP + ':3000/admin/organisations'
headers = {'admin-auth' : '12345', 'Content-Type' : 'application/json'}
payload = "{\"owner_name\": \"AnhNguyen\",\"cname\": \"mytyk-local.com\",\"cname_enabled\": true}"
result = requests.post(url, data = payload, headers = headers) 

# CREATE ADMIN USER
orgId = result.json()['Meta']

url = 'http://' + DOCKER_IP + ':3000/admin/users/'
payload = "{\"first_name\": \"Anh\",\"last_name\": \"Nguyen\",\"email_address\": \"" + TYK_USERNAME + "\",\"active\": true,\"org_id\": \"" + orgId + "\"}"
headers = {
  'admin-auth': '12345',
  'Content-Type': 'application/json'
}
result = requests.post(url, data = payload, headers=headers)

# SETUP PASSWORD
userId = result.json()['Meta']['id']
accessKey = result.json()['Meta']['access_key']

url = 'http://' + DOCKER_IP + ':3000/api/users/' + userId + '/actions/reset'
payload = "{\"new_password\": \"" + TYK_PASSWORD + "\"}"
headers = {
  "admin-auth": "12345",
  "Content-Type": "application/json",
  "Authorization": accessKey
}
result = requests.post(url, data = payload, headers=headers)

# SETUP PORTAL
url = 'http://' + DOCKER_IP + ':3000/api/portal/catalogue'
payload = "{\"org_id\": \"" + orgId + "\"}"
headers = {
  "admin-auth": "12345",
  "Content-Type": "application/json",
  "Authorization": accessKey
}
result = requests.post(url, data = payload, headers=headers)

# SETUP PORTAL HOMEPAGE
url = 'http://' + DOCKER_IP + ':3000/api/portal/pages'
payload = "{\"is_homepage\": true,\"template_name\": \"\",\"title\": \"Tyk Developer Portal\",\"slug\": \"home\",\"fields\": {\"JumboCTATitle\": \"Tyk Developer Portal\",\"SubHeading\": \"Sub Header\",\"JumboCTALink\": \"#cta\",\"JumboCTALinkTitle\": \"Your awesome APIs, hosted with Tyk!\",\"PanelOneContent\": \"Panel 1 content.\",\"PanelOneLink\": \"#panel1\",\"PanelOneLinkTitle\": \"Panel 1 Button\",\"PanelOneTitle\": \"Panel 1 Title\",\"PanelThereeContent\": \"\",\"PanelThreeContent\": \"Panel 3 content.\",\"PanelThreeLink\": \"#panel3\",\"PanelThreeLinkTitle\": \"Panel 3 Button\",\"PanelThreeTitle\": \"Panel 3 Title\",\"PanelTwoContent\": \"Panel 2 content.\",\"PanelTwoLink\": \"#panel2\",\"PanelTwoLinkTitle\": \"Panel 2 Button\",\"PanelTwoTitle\": \"Panel 2 Title\"}}"
headers = {
  "admin-auth": "12345",
  "Content-Type": "application/json",
  "Authorization": accessKey
}
result = requests.post(url, data = payload, headers=headers)

# FIX PORTAL URL
url = 'http://' + DOCKER_IP + ':3000/api/portal/configuration'
payload = "{}"
headers = {
  "admin-auth": "12345",
  "Content-Type": "application/json",
  "Authorization": accessKey
}
result = requests.post(url, data = payload, headers=headers)

# WRITE THE accessKey for later use
fileName = sys.argv[1] + "/userAuth.txt"
f = open(fileName, "w")
f.write(accessKey)
f.close()

print("Tyk dashboard URL: http://localhost:3000")
print("Tyk Username: " + TYK_USERNAME)
print("Tyk Password: " + TYK_PASSWORD)