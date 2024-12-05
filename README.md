# 🚀 ActionManager

**ActionManager** é um sistema poderoso para a **gestão de ações, projetos, departamentos e usuários**, projetado para facilitar o gerenciamento de tarefas, progressos e responsabilidades em organizações de qualquer porte.

---

## 🌟 Funcionalidades

### Ações
- 📝 **Cadastrar Ações**: Registre novas ações no sistema.  
- 📋 **Listar Ações**: Visualize todas as ações registradas.  
- 🔍 **Consultar Ação**: Obtenha detalhes de uma ação específica.  
- ✏️ **Atualizar Ação**: Edite informações de ações existentes.  
- 🚀 **Iniciar Ação**: Marque uma ação como "iniciada".  
- ✅ **Concluir Ação**: Finalize ações e registre suas conclusões.  
- 🗑️ **Excluir Ação**: Remova ações descontinuadas.  
- 🔄 **Atualizar Conclusão**: Altere os detalhes da conclusão de uma ação.  

### Departamentos
- 🏢 **Cadastrar Departamentos**: Adicione novos departamentos.  
- 📋 **Listar Departamentos**: Consulte todos os departamentos registrados.  
- 🔍 **Consultar Departamento**: Obtenha informações detalhadas de um departamento.  
- ✏️ **Atualizar Departamento**: Edite dados de departamentos existentes.  

### Projetos
- 📝 **Cadastrar Projetos**: Registre novos projetos.  
- 📋 **Listar Projetos**: Visualize todos os projetos.  
- 🔍 **Consultar Projeto**: Obtenha informações detalhadas de um projeto.  
- ✏️ **Atualizar Projeto**: Modifique os dados de um projeto existente.  
- 🚀 **Iniciar Projeto**: Alterne o status de um projeto para "iniciado".  
- ✅ **Concluir Projeto**: Finalize e registre a conclusão de um projeto.  
- 🗑️ **Excluir Projeto**: Remova projetos descontinuados.  
- 🔗 **Associar Ações**: Vincule ações a projetos específicos.  
- 👤 **Listar Projetos por Usuário**: Filtre projetos atribuídos a um usuário.  
- 🏢 **Listar Projetos por Departamento**: Visualize projetos relacionados a um departamento.  

### Usuários
- 👤 **Cadastrar Usuários**: Adicione novos usuários ao sistema.  
- 📋 **Listar Usuários**: Consulte todos os usuários cadastrados.  
- 🔍 **Consultar Usuário**: Obtenha informações de um usuário específico.  
- ✏️ **Atualizar Usuário**: Edite os dados de usuários existentes.  
- 🗑️ **Excluir Usuário**: Remova usuários desativados.  
- 🔐 **Login de Usuário**: Autentique usuários no sistema.  

---

## 🛠️ Tecnologias Utilizadas

- **ASP.NET Core**: Framework para construção da API.  
- **Entity Framework Core**: ORM para o gerenciamento de dados.  
- **SQL Server**: Sistema de banco de dados relacional.  
- **Swagger/OpenAPI**: Documentação interativa para explorar a API.  
- **Padrões de Projeto**: Implementação de CQRS para modularidade e escalabilidade.  

---

## 📂 Estrutura do Projeto

- **Controllers**: Gerenciam as requisições HTTP para cada recurso.  
- **Application**: Contém a lógica de negócios, comandos e consultas.  
- **Core**: Define as entidades e contratos do domínio.  
- **Persistence**: Gerencia o banco de dados e configura o Entity Framework.  

---

## 📖 Documentação

Explore os endpoints interativamente usando o Swagger:  
`/swagger/v1/swagger.json`

### Endpoints Principais

#### Ações
- **GET** `/api/actions`
- **POST** `/api/actions`
- **GET** `/api/actions/{id}`
- **PUT** `/api/actions/{id}`
- **PUT** `/api/actions/{id}/start`
- **PUT** `/api/actions/{id}/complete`
- **DELETE** `/api/actions/{id}/delete`
- **PATCH** `/api/actions/{id}/conclusion`

#### Departamentos
- **GET** `/api/departments`
- **POST** `/api/departments`
- **GET** `/api/departments/{id}`
- **PUT** `/api/departments/{id}`

#### Projetos
- **GET** `/api/projects`
- **POST** `/api/projects`
- **GET** `/api/projects/{id}`
- **PUT** `/api/projects/{id}`
- **PUT** `/api/projects/{id}/start`
- **PUT** `/api/projects/{id}/complete`
- **DELETE** `/api/projects/{id}/delete`
- **POST** `/api/projects/{projectId}/actions`
- **PATCH** `/api/projects/{id}/conclusion`
- **GET** `/api/projects/self/{userId}`
- **GET** `/api/projects/departments/{departmentId}`

#### Usuários
- **GET** `/api/users`
- **POST** `/api/users`
- **GET** `/api/users/{id}`
- **PUT** `/api/users/{id}`
- **DELETE** `/api/users/{id}`
- **PUT** `/api/users/login`

---

## 🚀 Como Contribuir

1. Faça um fork do repositório.  
2. Crie uma nova branch: `git checkout -b feature/nova-funcionalidade`.  
3. Faça as alterações desejadas.  
4. Envie suas alterações: `git push origin feature/nova-funcionalidade`.  
5. Crie um Pull Request e descreva suas alterações.  

---

Aproveite o **ActionManager** para organizar e otimizar processos na sua empresa!
