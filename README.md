```markdown
# LiveStockTracker

**LiveStockTracker** é um projeto que permite o rastreamento de preços de ações em tempo real, utilizando **Redis** como cache para melhorar a performance de leitura dos preços das ações.

## Tecnologias Utilizadas

- **ASP.NET Core**: Framework para construir APIs.
- **Redis**: Usado como cache distribuído para armazenar e recuperar rapidamente os preços das ações.
- **Swagger**: Usado para documentar e testar a API de maneira interativa.
- **StackExchange.Redis**: Cliente de Redis utilizado para conectar o .NET com o Redis.
- **Docker**: Utilizado para rodar o Redis em containers.

## Funcionalidades

- **Rastreamento de preços de ações**: Simula o rastreamento de preços de ações utilizando o nome do símbolo.
- **Cache com Redis**: Armazena os preços das ações no Redis por um período de 10 segundos, melhorando a performance.
- **Swagger UI**: Interface interativa para testar a API e visualizar os endpoints disponíveis.

## Como Rodar o Projeto

### Pré-requisitos

- [Docker](https://www.docker.com/products/docker-desktop) instalado e configurado.
- [Redis](https://redis.io/download) ou Docker para rodar o Redis.
- [.NET SDK](https://dotnet.microsoft.com/download) instalado.

### Passos para Executar

1. **Iniciar o Redis (via Docker)**:
   Abra o terminal e execute o comando para rodar o Redis no Docker:

   ```bash
   docker run --name redis -d -p 6379:6379 redis
   ```

   Esse comando cria um container Docker rodando Redis na porta `6379`.

2. **Restaurar Dependências**:
   Navegue até o diretório do projeto e execute:

   ```bash
   dotnet restore
   ```

3. **Executar o Projeto**:
   Para rodar o projeto, execute o comando:

   ```bash
   dotnet run
   ```

   O projeto estará rodando em `http://localhost:5078` e você pode acessá-lo diretamente pelo Swagger.

### Acessando a Swagger UI

Após o projeto rodar, você pode acessar a documentação da API pelo Swagger em:

```
http://localhost:5078/swagger
```

Nessa página, você poderá visualizar todos os endpoints disponíveis, incluindo o endpoint para rastrear o preço das ações.

## Endpoints

### Obter preço de uma ação

- **URL**: `/api/Stock/{simbolo}`
- **Método**: `GET`
- **Descrição**: Retorna o preço simulado de uma ação baseada no símbolo.
- **Parâmetros**:
  - `simbolo` (path): O símbolo da ação (ex. `AAPL`, `MSFT`).
  
#### Exemplo de resposta:

```json
{
  "preco": 339.14
}
```

## Como Contribuir

1. Faça um fork deste repositório.
2. Crie uma branch para a sua feature (`git checkout -b feature/MinhaFeature`).
3. Faça commit das suas alterações (`git commit -am 'Adicionando nova feature'`).
4. Envie para o repositório remoto (`git push origin feature/MinhaFeature`).
5. Abra um Pull Request.

## Licença

Distribuído sob a licença MIT. Veja [LICENSE](LICENSE) para mais informações.

## Autor

Feito com 💙 por [NVanitas](https://github.com/NVanitas)
