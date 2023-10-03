#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV ASPNETCORE_ENVIRONMENT Development

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ScsMarketplace.V2/ScsMarketplace.V2.csproj", "ScsMarketplace.V2/"]
RUN dotnet restore "ScsMarketplace.V2/ScsMarketplace.V2.csproj"
COPY . .
WORKDIR "/src/ScsMarketplace.V2"
RUN dotnet build "ScsMarketplace.V2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ScsMarketplace.V2.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ScsMarketplace.V2.dll"]
