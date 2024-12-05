🚀 ActionManager
ActionManager é um sistema poderoso para a gestão de ações, projetos, departamentos e usuários, projetado para facilitar o gerenciamento de tarefas, progressos e responsabilidades em organizações de qualquer porte.

🌟 Funcionalidades
Ações
📝 Cadastrar Ações: Registre novas ações no sistema.
📋 Listar Ações: Visualize todas as ações registradas.
🔍 Consultar Ação: Obtenha detalhes de uma ação específica.
✏️ Atualizar Ação: Edite informações de ações existentes.
🚀 Iniciar Ação: Marque uma ação como "iniciada".
✅ Concluir Ação: Finalize ações e registre suas conclusões.
🗑️ Excluir Ação: Remova ações descontinuadas.
🔄 Atualizar Conclusão: Altere os detalhes da conclusão de uma ação.
Departamentos
🏢 Cadastrar Departamentos: Adicione novos departamentos.
📋 Listar Departamentos: Consulte todos os departamentos registrados.
🔍 Consultar Departamento: Obtenha informações detalhadas de um departamento.
✏️ Atualizar Departamento: Edite dados de departamentos existentes.
Projetos
📝 Cadastrar Projetos: Registre novos projetos.
📋 Listar Projetos: Visualize todos os projetos.
🔍 Consultar Projeto: Obtenha informações detalhadas de um projeto.
✏️ Atualizar Projeto: Modifique os dados de um projeto existente.
🚀 Iniciar Projeto: Alterne o status de um projeto para "iniciado".
✅ Concluir Projeto: Finalize e registre a conclusão de um projeto.
🗑️ Excluir Projeto: Remova projetos descontinuados.
🔗 Associar Ações: Vincule ações a projetos específicos.
👤 Listar Projetos por Usuário: Filtre projetos atribuídos a um usuário.
🏢 Listar Projetos por Departamento: Visualize projetos relacionados a um departamento.
Usuários
👤 Cadastrar Usuários: Adicione novos usuários ao sistema.
📋 Listar Usuários: Consulte todos os usuários cadastrados.
🔍 Consultar Usuário: Obtenha informações de um usuário específico.
✏️ Atualizar Usuário: Edite os dados de usuários existentes.
🗑️ Excluir Usuário: Remova usuários desativados.
🔐 Login de Usuário: Autentique usuários no sistema.
🛠️ Tecnologias Utilizadas
ASP.NET Core: Framework para construção da API.
Entity Framework Core: ORM para o gerenciamento de dados.
SQL Server: Sistema de banco de dados relacional.
Swagger/OpenAPI: Documentação interativa para explorar a API.
Padrões de Projeto: Implementação de CQRS para modularidade e escalabilidade.
📂 Estrutura do Projeto
Controllers: Gerenciam as requisições HTTP para cada recurso.
Application: Contém a lógica de negócios, comandos e consultas.
Core: Define as entidades e contratos do domínio.
Persistence: Gerencia o banco de dados e configura o Entity Framework.
