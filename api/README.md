# IA Agente - API

## Tecnologias Utilizadas

- **C#** e **.NET 9**: Plataforma principal para desenvolvimento da API.
- **FastEndpoints**: Framework para construção de APIs rápidas e minimalistas.
- **Entity Framework Core (InMemory)**: ORM utilizado para persistência de dados em memória (ideal para testes e desenvolvimento).
- **Docker**: Containerização da aplicação para facilitar o deploy e execução em diferentes ambientes.

O projeto está dividido em múltiplas camadas:

- **Agent.Api**: Camada de apresentação (API).
- **Agent.Application**: Camada de aplicação (regras de negócio e serviços).
- **Agent.Domain**: Camada de domínio (entidades e interfaces de domínio).
- **Agent.Infra**: Camada de infraestrutura (persistência de dados, repositórios).

## Como rodar o projeto

### Pré-requisitos

- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- [Docker](https://www.docker.com/) (opcional, para rodar via container)

### Executando localmente

1. Clone o repositório e navegue até a pasta `Agent.Api`.
2. Restaure as dependências:
   ```bash
   dotnet restore
   ```
3. Execute a aplicação:
   ```bash
   dotnet run
   ```
4. Acesse a documentação Swagger em: [https://localhost:5001/swagger](https://localhost:5001/swagger) (ou conforme porta configurada)

### Executando via Docker

1. Certifique-se de que o Docker está instalado e em execução.
2. Na raiz do projeto `Agent.Api`, construa a imagem Docker:
   ```bash
   docker build -t agent-api .
   ```
3. Rode o container:
   ```bash
   docker run -p 8080:8080 agent-api
   ```
4. Acesse a API em: [http://localhost:8080](http://localhost:8080)
