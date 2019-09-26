#Stage 1
FROM node:10.16.3-alpine AS builder

WORKDIR /app

COPY . ./

RUN sed -i 's/baseUrl: ".*"/baseUrl: "http:\/\/localhost:81\/api"/' src/environments/environment.prod.ts 

RUN npm install

RUN npm install typescript@3.5.3

RUN npm run build --prod

# Stage 2
FROM nginx:1.17.4-alpine

COPY --from=builder /app/dist/client /usr/share/nginx/html

CMD ["nginx", "-g", "daemon off;"]	