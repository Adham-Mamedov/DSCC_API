# Build Stage
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-focal AS build
WORKDIR /source
COPY . .
RUN dotnet restore "./API_9534/API_9534.csproj" --disable-parallel
RUN dotnet publish "./API_9534/API_9534.csproj" -c release -o /app --no-restore


# Stage Stage
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-focal
WORKDIR /app
COPY --from=build /app ./

EXPOSE 5000

ENTRYPOINT ["dotnet", "API_9534.dll"]
