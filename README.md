# BloodBank

API para gerenciar doações de sangue, desenvolvida com uma arquitetura de microsserviços. Este projeto tem como objetivo principal simplificar o processo de doação, desde o cadastro do doador até o registro das doações, com foco em escalabilidade e manutenção.

## Funcionalidades

As funcionalidades atuais e futuras incluem:

- **Cadastro e Autenticação de Usuários**: Permite que doadores se registrem no sistema.
- **Registro de Doações (Donations)**: A principal funcionalidade, permitindo o registro de doações de sangue.
- **Consulta de Doações**: Futuramente, doadores poderão visualizar seu histórico de doações, e administradores terão acesso a relatórios completos.
- **Gerenciamento de Estoque de Sangue**: Funcionalidade planejada para ser implementada em breve.

## Tecnologias e Arquitetura

Este projeto foi construído com as seguintes tecnologias e padrões de arquitetura:

- **.NET 8**: Framework principal para o desenvolvimento da API.
- **MongoDB**: Banco de dados NoSQL utilizado para persistência de dados.
- **RabbitMQ**: Gerenciador de filas de mensagens, utilizado para comunicação entre os microsserviços.
- **Docker**: Utilizado para conteinerização dos microsserviços, RabbitMQ e MongoDB, facilitando a configuração e o deploy.
- **CQRS (Command Query Responsibility Segregation) & MediatR**: Padrões de arquitetura aplicados para separar as responsabilidades de leitura e escrita.
- **Arquitetura Limpa (Clean Architecture)**: Cada microsserviço foi estruturado seguindo os princípios da Arquitetura Limpa, garantindo um código desacoplado e testável.
- **Ocelot API Gateway**: Utilizado para centralizar a autenticação e gerenciar o roteamento das requisições para os microsserviços.

## Entidades Principais

As principais entidades que compõem o sistema são:

- **User**: Representa os usuários do sistema.
- **Donor**: Representa os doadores de sangue.
- **Donation**: Representa as doações de sangue registradas.

## Como Rodar o Projeto Localmente

Para configurar e rodar o projeto em sua máquina, siga os passos abaixo:

### 1. Clone o repositório:

```bash
git clone https://github.com/rafaelmarzoratti02/BloodBank
cd BloodBank
```

### 2. Configurações:
Configure o arquivo `appsettings.json` de cada microsserviço com as suas configurações locais, especialmente as strings de conexão e as chaves de acesso.

### 3. Docker:
Certifique-se de que o Docker esteja instalado e rodando. O projeto utiliza o Docker para gerenciar o MongoDB, RabbitMQ e as imagens dos microsserviços.

### 4. Inicie o projeto:
Utilize o Docker para iniciar a aplicação, executando os comandos necessários para subir os contêineres e expor as portas configuradas.

---

Espero que este README seja útil para você! Se precisar de ajustes ou mais detalhes, é só me dizer.
