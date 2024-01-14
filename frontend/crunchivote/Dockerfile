FROM node:alpine as build

WORKDIR /app

COPY package.json package-lock.json ./

RUN npm install --production

COPY . .

RUN npm run build && \
    rm -rf node_modules && \
    npm install --production && \
    npm prune --production && \
    chmod -R 777 /app

FROM nginx:alpine

WORKDIR /usr/share/nginx/html

RUN rm -rf ./*

COPY --from=build /app/build/ .

COPY default.conf /etc/nginx/conf.d/default.conf

RUN chmod -R 777 .

EXPOSE 8080
