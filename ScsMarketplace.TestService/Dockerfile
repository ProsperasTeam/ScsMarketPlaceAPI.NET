#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ScsMarketplace.TestService/ScsMarketplace.TestService.csproj", "ScsMarketplace.TestService/"]
RUN dotnet restore "ScsMarketplace.TestService/ScsMarketplace.TestService.csproj"
COPY . .
WORKDIR "/src/ScsMarketplace.TestService"
RUN dotnet build "ScsMarketplace.TestService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ScsMarketplace.TestService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ScsMarketplace.TestService.dll"]
