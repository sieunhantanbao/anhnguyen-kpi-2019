@echo off
rem openssl req -x509 -newkey rsa:4096 -keyout localhost.key -out localhost.crt -days 365 -nodes -subj "/C=GB/ST=Oxfordshire/L=Oxford/O=Achilles Information/OU=Development & Deployment/CN=localhost"
rem openssl req -x509 -newkey rsa:4096 -keyout tyklocal.key -out tyklocal.crt -days 365 -nodes -subj "/C=GB/ST=Oxfordshire/L=Oxford/O=Achilles Information/OU=Development & Deployment/CN=local-tyk.com"
certutil -addstore "Root" "rootca.crt"