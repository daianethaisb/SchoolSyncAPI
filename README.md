# SchoolSync API

API REST para gerenciamento de sistema escolar desenvolvida em .NET 8, seguindo os princ�pios de Clean Architecture.

## ?? Sobre o Projeto

O SchoolSync API � um sistema completo de gest�o escolar que permite gerenciar alunos, turmas, matr�culas e notas de forma eficiente e organizada.

## ??? Arquitetura

O projeto segue os princ�pios de **Clean Architecture** e est� organizado em 4 camadas:

- **SchoolSyncAPI.Domain**: Entidades de dom�nio e regras de neg�cio
- **SchoolSyncAPI.Application**: Casos de uso e l�gica de aplica��o
- **SchoolSyncAPI.Infrastructure**: Acesso a dados e servi�os externos
- **SchoolSyncAPI**: API REST e controllers

## ?? Tecnologias

- .NET 8
- C# 12.0
- Entity Framework Core
- SQL Server / SQLite
- ASP.NET Core Web API

## ?? Funcionalidades

### Gest�o de Matr�culas
- Cria��o e gerenciamento de matr�culas
- Controle de situa��o (Ativa, Trancada, Cancelada, Conclu�da)
- Opera��es de trancar, cancelar, concluir e reativar matr�culas
- Valida��o de dados obrigat�rios

### Gest�o de Alunos
- Cadastro e gerenciamento de alunos
- Controle de informa��es pessoais

### Gest�o de Turmas
- Organiza��o de turmas
- Associa��o com matr�culas

### Gest�o de Notas
- Registro e acompanhamento de notas
- Vincula��o com matr�culas

## ?? Pr�-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- SQL Server ou SQLite
- Visual Studio 2022 ou Visual Studio Code

## ?? Instala��o

1. Clone o reposit�rio
```bash
git clone https://github.com/seu-usuario/SchoolSyncAPI.git
cd SchoolSyncAPI
```

2. Restaure as depend�ncias
```bash
dotnet restore
```

3. Configure a string de conex�o no arquivo `appsettings.json`

4. Execute as migrations
```bash
dotnet ef database update --project SchoolSyncAPI.Infrastructure --startup-project SchoolSyncAPI
```

5. Execute o projeto
```bash
dotnet run --project SchoolSyncAPI
```

## ?? Endpoints da API

A API estar� dispon�vel em `https://localhost:5001` (HTTPS) ou `http://localhost:5000` (HTTP).

Acesse a documenta��o Swagger em: `https://localhost:5001/swagger`

## ?? Estrutura do Projeto

```
SchoolSyncAPI/
??? SchoolSyncAPI/           # API Layer
?   ??? Controllers/  # API Controllers
??? SchoolSyncAPI.Application/          # Application Layer
? ??? UseCases/            # Use Cases
??? SchoolSyncAPI.Domain/      # Domain Layer
?   ??? Models/               # Domain Entities
??? SchoolSyncAPI.Infrastructure/# Infrastructure Layer
    ??? Data/    # Database Context
  ??? Mappings/               # Entity Configurations
```

## ?? Contribuindo

Contribui��es s�o bem-vindas! Sinta-se � vontade para abrir issues ou enviar pull requests.

1. Fa�a um Fork do projeto
2. Crie uma branch para sua feature (`git checkout -b feature/MinhaFeature`)
3. Commit suas mudan�as (`git commit -m 'Adiciona nova feature'`)
4. Push para a branch (`git push origin feature/MinhaFeature`)
5. Abra um Pull Request

## ?? Licen�a

Este projeto est� sob a licen�a MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

## ? Autor

Desenvolvido com ?? para facilitar a gest�o escolar.

---

? Se este projeto foi �til para voc�, considere dar uma estrela!
