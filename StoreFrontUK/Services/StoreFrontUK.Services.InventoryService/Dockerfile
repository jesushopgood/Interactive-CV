# Use the .NET SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /src

COPY ./StoreFrontUK.sln ./
COPY ./Services/StoreFrontUK.Services.InventoryService/InventoryService.csproj ./Services/StoreFrontUK.Services.InventoryService/

RUN dotnet restore ./Services/StoreFrontUK.Services.InventoryService/InventoryService.csproj

COPY . ./

RUN dotnet publish ./Services/StoreFrontUK.Services.InventoryService/InventoryService.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 80

ENTRYPOINT ["dotnet", "InventoryService.dll"]