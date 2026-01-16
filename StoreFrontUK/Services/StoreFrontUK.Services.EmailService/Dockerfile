# Use the official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /src

# Copy only solution and project files first (for better caching)
COPY ./StoreFrontUK.sln ./
COPY ./Services/StoreFrontUK.Services.EmailService/EmailService.csproj ./Services/StoreFrontUK.Services.EmailService/

RUN dotnet restore ./Services/StoreFrontUK.Services.EmailService/EmailService.csproj

# Now copy the rest of the source code
COPY . ./

RUN dotnet publish ./Services/StoreFrontUK.Services.EmailService/EmailService.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Expose the port your app listens on (usually 80)
EXPOSE 80

ENTRYPOINT ["dotnet", "EmailService.dll"]