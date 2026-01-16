# Use the .NET SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /src

COPY ./StoreFrontUK.sln ./
COPY ./Services/StoreFrontUK.Services.OrderService/OrderService.csproj ./Services/StoreFrontUK.Services.OrderService/

RUN dotnet restore ./Services/StoreFrontUK.Services.OrderService/OrderService.csproj

COPY . ./

RUN dotnet publish ./Services/StoreFrontUK.Services.OrderService/OrderService.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 80

ENTRYPOINT ["dotnet", "OrderService.dll"]