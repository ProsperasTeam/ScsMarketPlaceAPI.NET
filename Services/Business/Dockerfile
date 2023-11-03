FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
COPY ./config /root/config

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Business/Business.csproj", "Services/Business/"]
RUN dotnet restore "Services/Business/Business.csproj"

COPY . /src
WORKDIR "/src/Services/Business"
RUN dotnet build "Business.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Business.csproj" -c Release -o /app/publish /p:UseAppHost=false

# FROM base AS development
# WORKDIR /app
# COPY --from=publish /app/publish .
# ENV ASPNETCORE_ENVIRONMENT Development

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=build /src/Services/Business/Properties/launchSettings.json ./Properties/
ENV ASPNETCORE_ENVIRONMENT Docker


# Specify the entry point without the "--launch-profile" argument
ENTRYPOINT ["dotnet", "Business.dll"]

