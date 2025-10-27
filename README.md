# SchoolSync API

API REST para gerenciamento de sistema escolar desenvolvida em .NET 8, seguindo os princípios de Clean Architecture.

## Sobre o Projeto

O SchoolSync API é um sistema completo de gestão escolar que permite gerenciar alunos, turmas, matrículas e notas de forma eficiente e organizada.

## Arquitetura

O projeto segue os princípios de **Clean Architecture**, DDD e está organizado em 4 camadas:

- **SchoolSyncAPI.Domain**: Entidades de domínio e regras de negócio
- **SchoolSyncAPI.Application**: Casos de uso e lógica de aplicação
- **SchoolSyncAPI.Infrastructure**: Acesso a dados e serviços externos
- **SchoolSyncAPI**: API REST e controllers

## Tecnologias

- .NET 8
- C# 12.0
- Entity Framework Core
- SQL Server / SQLite
- ASP.NET Core Web API

## Funcionalidades

### Gestão de Matrículas
- Criação e gerenciamento de matrículas
- Controle de situação (Ativa, Trancada, Cancelada, Concluída)
- Operações de trancar, cancelar, concluir e reativar matrículas
- Validação de dados obrigatórios

### Gestão de Alunos
- Cadastro e gerenciamento de alunos
- Controle de informações pessoais

### Gestão de Turmas
- Organização de turmas
- Associação com matrículas

### Gestão de Notas
- Registro e acompanhamento de notas
- Vinculação com matrículas

## Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- SQL Server ou SQLite
- Visual Studio 2022 ou Visual Studio Code

## Instalação

1. Clone o repositório
```bash
git clone https://github.com/seu-usuario/SchoolSyncAPI.git
cd SchoolSyncAPI
```

2. Restaure as dependências
```bash
dotnet restore
```

3. Configure a string de conexão no arquivo `appsettings.json`

4. Execute as migrations
```bash
dotnet ef database update --project SchoolSyncAPI.Infrastructure --startup-project SchoolSyncAPI
```

5. Execute o projeto
```bash
dotnet run --project SchoolSyncAPI
```

## Endpoints da API

A API estará disponível em `https://localhost:5001` (HTTPS) ou `http://localhost:5000` (HTTP).

Acesse a documentação Swagger em: `https://localhost:5001/swagger`

## Estrutura do Projeto

```
SchoolSyncAPI/
SchoolSyncAPI/                   # API Layer
Controllers/                     # API Controllers
SchoolSyncAPI.Application/       # Application Layer
UseCases/                        # Use Cases
SchoolSyncAPI.Domain/            # Domain Layer
Models/                          # Domain Entities
SchoolSyncAPI.Infrastructure/    # Infrastructure Layer
Data/                            # Database Context
Mappings/                        # Entity Configurations
```
## 📚 DOCUMENTAÇÃO COMPLETA

Consulte o arquivo **DOCUMENTACAO_SCHOOLSYNC.md** para:
- Arquitetura detalhada
- Diagramas de sequência
- Fluxos DDD
- Exemplos de uso completos
- Descrição de todas as camadas

## Licença

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

## Autor

Desenvolvido com Daiane Barbosa para facilitar a gestão escolar.

---

Se este projeto foi útil para você, considere dar uma estrela!
