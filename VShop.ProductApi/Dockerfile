#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Nuget.Config", "."]
COPY ["VShop.ProductApi/VApp.ClientesApi.csproj", "VShop.ProductApi/"]
RUN dotnet restore "VShop.ProductApi/VApp.ClientesApi.csproj"
COPY . .
WORKDIR "/src/VShop.ProductApi"
RUN dotnet build "VApp.ClientesApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VApp.ClientesApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VApp.ClientesApi.dll"]