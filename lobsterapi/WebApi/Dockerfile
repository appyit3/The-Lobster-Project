#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["WebApi/Lobster.API.csproj", "WebApi/"]
RUN dotnet restore "WebApi/Lobster.API.csproj"
COPY . .
WORKDIR "/src/WebApi"
RUN dotnet build "Lobster.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Lobster.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Lobster.API.dll"]