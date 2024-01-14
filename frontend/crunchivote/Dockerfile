FROM node:alpine as build

#
COPY package.json package-lock.json ./

RUN npm install && mkdir /crunchivote && mv ./node_modules ./crunchivote

WORKDIR /crunchivote

COPY . .

RUN npm run build

RUN chmod -R 777 /crunchivote

FROM nginx:alpine

RUN rm -rf /usr/share/nginx/html/*

COPY --from=build /crunchivote/ /usr/share/nginx/html
COPY default.conf /etc/nginx/conf.d/default.conf

RUN chmod -R 777 /usr/share/nginx/html

EXPOSE 8080
