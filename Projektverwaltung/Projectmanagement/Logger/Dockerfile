FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Logger/Logger.csproj", "Logger/"]
RUN dotnet restore "Logger/Logger.csproj"
COPY . .
WORKDIR "/src/Logger"
RUN dotnet build "Logger.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Logger.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Logger.dll"]
