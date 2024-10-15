FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy csproj and restore dependencies
COPY *.csproj ./
RUN dotnet clean
RUN dotnet restore

# Copy remaining files and build the app
COPY . ./
RUN dotnet publish -c Release -o out bci-server-app.csproj

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

EXPOSE 5094
EXPOSE 7258

ENTRYPOINT ["dotnet", "bci-server-app.dll"]