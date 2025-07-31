## BlogLuzaGroup
Projeto simples de blog usando .NET, Entity Framework Core e PostgreSQL.
  Algumas coisas não estão 100%, pois o projeto tem como base mostrar um pouco do conhecimento sobre .net, pontos que podem ser melhorados: estou expondo as chaves JWT no appsetting, não tem uma validação segura no login, não grava a hash da senha no banco, grava a senha da forma que veio.
  Essa parte de autenticação pode melhorar, na parte das Claims poderá ser acrescentado o tempo para o token expirar, trazer mais dados com a informação do usuário, entre outros.

## Descrição

Este projeto implementa um sistema básico de blog com entidades `Post` e `User`. Utiliza PostgreSQL como banco de dados, webSocket para notificações em tempo real e Entity Framework Core para ORM.


## Instalação

1. Clone o repositório:
  `git clone https://github.com/MarcosItSolution/BlogLuzaGroup.git`

2. Baixe a versão mais atualizada do PostGresSQL
  `https://www.postgresql.org/download/`

3. Baixe uma ferramenta de gerenciamento de banco de dados para PostGresSQL (pode utilizar o DBeaver ou algum de sua preferência)
  `https://dbeaver.io/download/`

4. Crie um banco de dados PostGresSQL local (ou utilize um existente)

5. Em seguida, configure o banco que irá utilizar, no appsettings.json
  Exemplo: 
  ```json
  "ConnectionStrings": {
    "PostgreConnection": "Host=localhost;Port=5432;Database=postgres;Username=teste;Password=teste"
  },
  ```

6. Execute os comandos a seguir para criar as tabelas que iremos utilizar para realizar o CRUD das postagens e usuários 
  ```SQL
  DROP TABLE IF EXISTS public.post;
  DROP TABLE IF EXISTS public.users;


  CREATE TABLE public.post (
      "Id" SERIAL PRIMARY KEY,
      "Title" VARCHAR(255) NULL,
      "Content" TEXT NULL,
      "UserId" INTEGER NULL,

      "Active" BOOLEAN NULL DEFAULT TRUE,

      "CreatedUser" INTEGER NULL,
      "UpdatedUser" INTEGER NULL,
      "DeletedUser" INTEGER NULL,

      "CreatedDate" TIMESTAMPTZ NULL,
      "UpdatedDate" TIMESTAMPTZ NULL,
      "DeletedDate" TIMESTAMPTZ NULL,

      "Deleted" BOOLEAN NULL DEFAULT FALSE
  );


  CREATE TABLE public.users (
      "Id" SERIAL PRIMARY KEY,                 
      "Username" VARCHAR(255) NULL,             -- Pode ser nulo (mas idealmente NOT NULL)
      "Password" VARCHAR(255) NULL,             -- Pode ser nulo (mas idealmente NOT NULL e hash da senha)

      "Active" BOOLEAN NULL DEFAULT TRUE,

      "CreatedUser" INTEGER NULL,
      "UpdatedUser" INTEGER NULL,
      "DeletedUser" INTEGER NULL,

      "CreatedDate" TIMESTAMPTZ NULL,
      "UpdatedDate" TIMESTAMPTZ NULL,
      "DeletedDate" TIMESTAMPTZ NULL,

      "Deleted" BOOLEAN NULL DEFAULT FALSE
  )
  ```

O sistema seguirá uma arquitetura em camadas para organizar as responsabilidades:
  * Presentation: Controllers e WebSocket Handlers.
  * Application: Implementação de Regras de negócio, DTOs e serviços.
  * Domain: Entidades e interfaces.
  * Infrastructure: Repositórios e configuração do Entity Framework.


### Contato

Linkedin: https://www.linkedin.com/in/marcos-castro-423206124/

Ao rodar o projeto, irá renderizar como default o swagger da aplicação, onde também constará meus dados para contato.