
# BookManager

## Pré-requisitos
- Docker
- Docker Compose
- Visual Studio

Certifique-se de ter o Docker e o Docker Compose instalados em seu sistema antes de prosseguir.

## Configuração do Docker Compose

O arquivo `docker-compose.yml` já está configurado para criar dois serviços: o serviço `webapi` para o aplicativo e o serviço `mssql-server` para o banco de dados SQL Server. Certifique-se de ajustar as configurações conforme necessário.

```yaml

version: '3.4'
services:
  mssql-server:
    image: mcr.microsoft.com/mssql/server:2017-latest-ubuntu
    environment:
      ACCEPT_EULA: "Y"
      SA_PASSWORD: "test@2024"
      MSSQL_PID: Express
    ports:
      - "1433:1433"
    
  webapi:
    env_file:
      - src/WebApi/dev.env
    build:
        dockerfile: src/WebApi/Dockerfile
    environment:
      DbServer: "mssql-server"
      DbPort: "1433"
      DbUser: "SA"
      Password: "test@2024"
      Database: "bookManager"
    ports: 
      - "8090:80"
