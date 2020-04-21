FROM node:10.20.1-alpine3.11

WORKDIR /usr/src/Storage

COPY package*.json ./

RUN npm install

COPY . .

EXPOSE 8080

CMD [ "node", "server.js" ]