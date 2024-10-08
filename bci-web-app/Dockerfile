# Stage 1: Build the Angular application
FROM node:18.19.0 AS build

# Set the working directory
WORKDIR /usr/src/app

# Copy package.json and package-lock.json (if available)
COPY package*.json ./

# Install dependencies
RUN npm install

# Copy the rest of the application code
COPY . ./

# Build the Angular application
RUN npm run build

# Stage 2: Serve the application using Angular CLI
FROM node:18.19.0

# Set the working directory
WORKDIR /usr/src/app

# Copy built files from the previous stage
COPY --from=build /usr/src/app/dist/bci-web-app /usr/src/app

# Install Angular CLI globally
RUN npm install -g @angular/cli

# Expose the port the app runs on
EXPOSE 4200

# Start the Angular application
CMD ["ng", "serve", "--host", "0.0.0.0"]