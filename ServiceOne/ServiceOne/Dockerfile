#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 8094

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ServiceOne/ServiceOne/ServiceOne.csproj", "ServiceOne/"]
COPY ["ServiceOne/Application/Application.csproj", "Application/"]
COPY ["ServiceOne/Infrastructure/Infrastructure.csproj", "Infrastructure/"]
COPY ["ServiceOne/Infrastructure.Contract/Infrastructure.Contract.csproj", "Infrastructure.Contract/"]

RUN dotnet restore "ServiceOne/ServiceOne.csproj"
COPY . .

WORKDIR "/src/ServiceOne"

RUN dotnet build "ServiceOne.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ServiceOne.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS http://*:8094
ENTRYPOINT ["dotnet", "daprserviceone.dll"]