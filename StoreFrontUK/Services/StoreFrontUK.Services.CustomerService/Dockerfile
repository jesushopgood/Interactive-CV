# Use the .NET SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /src

# Copy only solution and project files first (for better caching)
COPY ./StoreFrontUK.sln ./
COPY ./Services/StoreFrontUK.Services.CustomerService/CustomerService.csproj ./Services/StoreFrontUK.Services.CustomerService/

# Restore dependencies (this layer will be cached if csproj files don't change)
# RUN dotnet restore ./StoreFrontUK.sln
RUN dotnet restore ./Services/StoreFrontUK.Services.CustomerService/CustomerService.csproj

# Now copy the rest of the source code
COPY . ./

# Build and publish the app
RUN dotnet publish ./Services/StoreFrontUK.Services.CustomerService/CustomerService.csproj -c Release -o /app/publish

# Use the ASP.NET runtime image to run the app
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Expose the port your app listens on
EXPOSE 80

# Start the app
ENTRYPOINT ["dotnet", "CustomerService.dll"]