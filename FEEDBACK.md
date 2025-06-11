# Feedback - Avaliação Geral

## Front End

### Navegação
  * Pontos positivos:
    - Projeto MVC funcional com rotas para autenticação, produtos e categorias.
    - Views bem estruturadas e operação fluida das funcionalidades básicas.

  * Pontos negativos:
    - Nenhum.

### Design
  - Interface administrativa clara, adequada ao contexto de gerenciamento de dados de uma loja virtual.

### Funcionalidade
  * Pontos positivos:
    - CRUD de produtos e categorias operacionais tanto na API quanto no MVC.
    - Identity configurado nas duas camadas, com autenticação funcional.
    - Criação do vendedor associada ao usuário do Identity com ID compartilhado.
    - SQLite, migrations automáticas e seed de dados presentes.

  * Pontos negativos:
    - Produto não é atribuído ao vendedor autenticado (usuário interativo) durante os CRUDs.
    - Lógica de segurança de domínio ausente ao permitir que qualquer vendedor edite produtos de outro.
    - Implementação redundante do `DbMigrationHelpers` na API e MVC.
    - Algumas verificações de ambiente/configuração no controller relacionadas ao SQLite, o que é desnecessário.

## Back End

### Arquitetura
  * Pontos positivos:
    - Três camadas bem definidas (API, MVC, Core/Data).
    - Configurações modulares e bem distribuídas.

  * Pontos negativos:
    - `JwtSettings` está misturado com modelos, deveria estar exclusivamente no projeto da API.
    - Falta de abstrações como repositórios, o que resultou em código repetitivo e menor coesão entre camadas.

### Funcionalidade
  * Pontos positivos:
    - Estrutura de autenticação e operações básicas bem implementadas.
    - Fluxo de autenticação com criação de vendedor vinculado no cadastro do usuário (Identity).

  * Pontos negativos:
    - Falta de segurança no vínculo entre produto e vendedor durante edição/exclusão.

### Modelagem
  * Pontos positivos:
    - Entidades bem desenhadas e com relacionamentos consistentes.
    - Separação de modelos e viewmodels clara.

  * Pontos negativos:
    - Nenhum.

## Projeto

### Organização
  * Pontos positivos:
    - Estrutura de pastas organizada, uso correto de solution `.sln` e presença de `README.md` e `FEEDBACK.md`.

  * Pontos negativos:
    - Arquivo do banco SQLite versionado desnecessariamente.
    - Seed duplicado em múltiplas camadas.

### Documentação
  * Pontos positivos:
    - Documentação presente, bem formatada e útil.
    - Swagger configurado para testes da API.

  * Pontos negativos:
    - Nenhum.

### Instalação
  * Pontos positivos:
    - SQLite configurado com migrations automáticas e seed funcional.

  * Pontos negativos:
    - Duplicidade de implementação do seed.

---

# 📊 Matriz de Avaliação de Projetos

| **Critério**                   | **Peso** | **Nota** | **Resultado Ponderado**                  |
|-------------------------------|----------|----------|------------------------------------------|
| **Funcionalidade**            | 30%      | 8        | 2,4                                      |
| **Qualidade do Código**       | 20%      | 8        | 1,6                                      |
| **Eficiência e Desempenho**   | 20%      | 9        | 1,8                                      |
| **Inovação e Diferenciais**   | 10%      | 9        | 0,9                                      |
| **Documentação e Organização**| 10%      | 9        | 0,9                                      |
| **Resolução de Feedbacks**    | 10%      | 9        | 0,9                                      |
| **Total**                     | 100%     | -        | **8,5**                                  |

## 🎯 **Nota Final: 8,5 / 10**
