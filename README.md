## Visão Geral
Este é um desafio com duas etapas de avaliação, uma teórica e outra prática. Cuja finalidade é avaliar os niveis conhecimentos teóricos e práticos de cada participante.

### Etapa Teórica
1. Orientação a Objecto
  * Herança múltipla ocorre quando uma classe pode herdar de mais de uma classe base. O C# permite essa implementação atraves de interfaces, uma vez que não da suporte directo.
  * Polimorfismo permite que um objeto seja tratado como uma instância de sua classe base, promovendo extensibilidade e reutilização do código. Em C#, isso é implementado através de métodos virtuais/override e interfaces.
     Exemplo:
    ```csharp
    abstract class Animal
    {
        public virtual void Speak() => Console.WriteLine("O animal faz um som");
    }
    
    sealed class Dog : Animal
    {
        public override void Speak() => Console.WriteLine("O cão ladra");
    }
    
    sealed class Cat : Animal
    {
        public override void Speak() => Console.WriteLine("O gato mia");
    }
    
    static void Main()
    {
        Animal animal = new Dog();
        animal.Speak(); // Saída: O cão ladra
    
        animal = new Cat();
        animal.Speak(); // Saída: O gato mia
    }
    ```
    
2. SOLID
   * O Principo de Responsabilidade Unica (SRP) diz que uma classe deve ter apenas um motivo para mudar. Exemplo: separar a lógica de negócio (PostService) da lógica de persistência (PostRepository).
   * O Principio da Inversão de Dependencia(DIP) diz que devemos depender da abstração e não da implementação, permitindo a redução de acoplamentos. Benefícia a manutenção permitindo a escrita de testes, reutilização do codigo e a clareza.
     
3. Entity Framework
   * O gerenciamento é feito atraves de Mapeamento Objeto-Relacional (ORM). O EF converte classes C# em tabelas do banco de dados e propriedades em colunas. Isso é feito usando mapeamento de entidades, seja via convenção ou configuração explícita usando Data Annotations ou a Fluent API.
   * Para otimização de consultas no  EF, podemos usar alguns metodos tais como AsNoTracking,Include,ThenInclude e também paginação. Lembrando de manter desativado o carregamento lento na implementação do DbContext.
   
6. WebSockets
   * A comunicação via websockets é bidirecional já a HTTP é unidirecional.
   * As principais considerações de segurança são:
     * Autorização e Autenticação
     * Controle no limites de acesso
     * Uso de criptografia e certificados
     
8. Arquitetura
   * Monolítica centraliza todas as funcionalidades em uma única aplicação. Já os microsserviços dividem a aplicação em componentes menores e independentes. Quanto a escolha arquitetural dependente sempre da complexidade do negócio.
   * Para alta escalabilidade, microsserviços são mais adequados, mas exigem mais gerenciamento. O tempo de responsta inicial do negócio é vital, caso seja urgente sugiro começar com Monólito e oportunamente transformar em microserviços, no contrário, o ideal é iniciar com microserviços.

### Etapa Pratica
O projeto será desenvolvido com ASP.NET Core (versão compatível com .NET 8), utilizando Entity Framework Core para manipulação de dados, e implementará WebSockets para notificações em tempo real. O design será orientado a objetos, seguindo os princípios SOLID, para garantir manutenibilidade e escalabilidade.

### Requisitos Funcionais
#### Autenticação
  * Registrar usuario
  * Fazer login
    
#### CRUD de Postagens:
  * Listar todas as postagens.
  * Criar novas postagens.
  * Editar postagens existentes.
  * Excluir postagens.
    
#### Notificações em Tempo Real:
  Quando uma nova postagem for criada, os usuários conectados recebem uma notificação via WebSockets.

#### Persistência de Dados:
  Utilizar Entity Framework Core e um banco de dados PostgreSQL.

### Estrutura do Projeto

O sistema seguirá uma arquitetura em camadas para organizar as responsabilidades:

* Presentation: Controllers e WebSocket Handlers.
* Application: Implementação de Regras de negócio, DTOs e serviços.
* Domain: Entidades e interfaces.
* Infrastructure: Repositórios e configuração do Entity Framework.
