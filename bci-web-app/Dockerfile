FROM node:18 AS build
WORKDIR /app

# Copy package.json and package-lock.json
COPY package*.json ./

# Install dependencies
RUN npm install

# Copy remaining files and build the app
COPY . ./
RUN npm run build

# Build runtime image
FROM nginx:1.21
COPY --from=build /app/dist/bci-web-app /usr/share/nginx/html