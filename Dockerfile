# Build stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

COPY *.sln .
COPY MiLockProsBackend/*.csproj ./MiLockProsBackend/
RUN dotnet restore

COPY . .
WORKDIR /app/MiLockProsBackend
RUN dotnet publish -c Release -o out

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/MiLockProsBackend/out .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "MiLockProsBackend.dll"]
