#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 8095

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ServiceTwo/ServiceTwo/ServiceTwo.csproj", "ServiceTwo/"]
COPY ["ServiceTwo/Application/Application.csproj", "Application/"]
COPY ["ServiceTwo/Infrastructure/Infrastructure.csproj", "Infrastructure/"]
COPY ["ServiceTwo/Infrastructure.Contracts/Infrastructure.Contracts.csproj", "Infrastructure.Contracts/"]

RUN dotnet restore "ServiceTwo/ServiceTwo.csproj"
COPY . .

WORKDIR "/src/ServiceTwo"

RUN dotnet build "ServiceTwo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ServiceTwo.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS http://*:8095
ENTRYPOINT ["dotnet", "daprservicetwo.dll"]