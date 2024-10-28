# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar os arquivos de solução e de projeto
COPY *.sln ./
COPY ActionsManager.API/*.csproj ActionsManager.API/
COPY ActionsManager.Application/*.csproj ActionsManager.Application/
COPY ActionsManager.Core/*.csproj ActionsManager.Core/
COPY ActionsManager.Infrastructure/*.csproj ActionsManager.Infrastructure/

# Restaurar as dependências
RUN dotnet restore

# Copiar todo o código-fonte e compilar a aplicação
COPY . .
WORKDIR /src/ActionsManager.API
RUN dotnet publish -c Release -o /app/publish

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

# Expor a porta que a aplicação usa (ajuste se necessário)
EXPOSE 80

# Definir o entrypoint
ENTRYPOINT ["dotnet", "ActionsManager.API.dll"]
