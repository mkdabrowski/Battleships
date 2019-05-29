FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY Battleships/*.csproj ./Battleships/
WORKDIR /app/Battleships
RUN dotnet restore

# copy and publish app and libraries
WORKDIR /app
COPY Battleships/. ./Battleships/
WORKDIR /app/Battleships
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/runtime:2.2 AS runtime
WORKDIR /app
COPY --from=build /app/Battleships/out ./
ENTRYPOINT ["dotnet", "Battleships.dll"]