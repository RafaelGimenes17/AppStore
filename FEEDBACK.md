# Feedback - Avaliação Geral

## Front End
### Navegação

  * Pontos negativos:
    - Apenas setup básico do template, sem implementação real das funcionalidades necessárias.
    - Faltam views e rotas específicas para os casos de uso do projeto.

### Design
    - Será avaliado na entrega final

### Funcionalidade

  * Pontos negativos:
    - Não há implementação concreta dos casos de uso especificados.
    - Faltam funcionalidades essenciais como gestão de produtos e categorias.
    - Apenas estrutura base do template sem desenvolvimento real.

## Back End
### Arquitetura
  * Pontos positivos:
    - Divisão em camadas MVC, API e camadas de suporte.
    - Não há excesso de camadas, mantendo uma estrutura relativamente simples.

  * Pontos negativos:
    - As camadas de business e data poderiam ser unificadas em uma única camada Core para simplificar ainda mais.
    - Implementação muito básica, apenas com o setup inicial dos templates.

### Funcionalidade
  * Pontos positivos:
    - Setup básico do Entity Framework.
    - Estrutura inicial para API e MVC presentes.

  * Pontos negativos:
    - Não há implementação dos casos de uso de negócio.
    - Ausência da criação do registro de vendedor no Identity.
    - Falta implementação do SQLite.
    - Sem migrations ou seed de dados.

### Modelagem
  * Pontos positivos:
    - Presença de mapeamentos básicos de entidades na camada de Business.

  * Pontos negativos:
    - Faltam implementações necessárias de acordo com a especificação.
    - O projeto está muito aquém do propósito especificado.

## Projeto
### Organização
  * Pontos positivos:
    - Uso da pasta `src` na raiz.
    - Arquivo de solução (`.sln`) presente na raiz.
    - Estrutura básica de projetos estabelecida.

  * Pontos negativos:
    - Apesar da estrutura estar correta, falta conteúdo real nas implementações.
    - Projetos praticamente vazios, apenas com setup inicial.

### Documentação

  * Pontos negativos:
    - Ausência de README.md.
    - Ausência de FEEDBACK.md.
    - Falta documentação da API via Swagger.
    - Sem instruções de execução ou configuração do projeto.

### Instalação

  * Pontos negativos:
    - Não há implementação do SQLite.
    - Ausência de migrations automáticas.
    - Falta seed de dados.
    - Sem instruções ou automação para setup inicial do projeto.