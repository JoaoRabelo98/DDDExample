
FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build-env
WORKDIR /src

# Copiar csproj e restaurar dependencias

COPY Arsenal.Application/Arsenal.Application.csproj Arsenal.Application/
COPY Arsenal.Domain/Arsenal.Domain.csproj Arsenal.Domain/
COPY Arsenal.Infrastructure/Arsenal.Infrastructure.csproj Arsenal.Infrastructure/
COPY Arsenal.Test/Arsenal.Test.csproj Arsenal.Test/

RUN dotnet restore Arsenal.Application/Arsenal.Application.csproj 


# Build da aplicacao
COPY . ./
WORKDIR /src/Arsenal.Application
RUN dotnet publish Arsenal.Application.csproj -c Release -o /app

# Build da imagem
FROM mcr.microsoft.com/dotnet/core/aspnet:3.0
WORKDIR /app
COPY --from=build-env /app .
EXPOSE 80
ENTRYPOINT ["dotnet", "Arsenal.Application.dll"]