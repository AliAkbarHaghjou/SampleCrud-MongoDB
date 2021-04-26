#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["SimpleCrud.WebApi/SimpleCrud.WebApi.csproj", "SimpleCrud.WebApi/"]
COPY ["SimpleCrud.Application/SimpleCrud.Application.csproj", "SimpleCrud.Application/"]
COPY ["SimpleCrud.Domain/SimpleCrud.Domain.csproj", "SimpleCrud.Domain/"]
COPY ["SimpleCrud.Persistence/SimpleCrud.Persistence.csproj", "SimpleCrud.Persistence/"]
COPY ["SimpleCrud.Service/SimpleCrud.Service.csproj", "SimpleCrud.Service/"]
RUN dotnet restore "SimpleCrud.WebApi/SimpleCrud.WebApi.csproj"
COPY . .
WORKDIR "/src/SimpleCrud.WebApi"
RUN dotnet build "SimpleCrud.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SimpleCrud.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SimpleCrud.WebApi.dll"]
