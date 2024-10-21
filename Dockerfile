# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar os arquivos de solução e de projeto
COPY *.sln ./
COPY 5W2H.Api/*.csproj 5W2H.Api/
COPY 5W2H.Application/*.csproj 5W2H.Application/
COPY 5W2H.Core/*.csproj 5W2H.Core/
COPY 5W2H.Infrastructure/*.csproj 5W2H.Infrastructure/

# Restaurar as dependências
RUN dotnet restore

# Copiar todo o código-fonte e compilar a aplicação
COPY . .
WORKDIR /src/5W2H.Api
RUN dotnet publish -c Release -o /app/publish

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

# Expor a porta que a aplicação usa (ajuste se necessário)
EXPOSE 80

# Definir o entrypoint
ENTRYPOINT ["dotnet", "5W2H.Api.dll"]
