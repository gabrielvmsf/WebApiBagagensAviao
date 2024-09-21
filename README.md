# WebApplicationBagagens

## Descrição
Este projeto foi desenvolvido como parte da disciplina de **Sistemas Distribuídos**. O objetivo principal da aplicação é gerenciar o controle de bagagens em aeroportos, incluindo o cadastro, consulta, atualização e exclusão de bagagens, bem como o acompanhamento do histórico de movimentação das mesmas. Cada aluno foi responsável por implementar uma parte específica da aplicação.

A API é composta por dois principais recursos: **Bagagem** e **Histórico de Movimentação**. Abaixo estão os endpoints disponíveis para cada um desses recursos, juntamente com uma breve descrição de suas funcionalidades.

## Requisitos
- .NET 8.0
- Swagger configurado para testes e visualização dos endpoints
- Banco de dados SQL Server

## Endpoints da API

### **Bagagem**
Este recurso lida com todas as operações relacionadas ao gerenciamento das bagagens.

- **POST /api/Bagagem/cadastrar-bagagem**
  - Cadastra uma nova bagagem no sistema.
  
- **GET /api/Bagagem/listar-bagagens-voo/{vooID}**
  - Lista todas as bagagens associadas a um voo específico.

- **GET /api/Bagagem/listar-todas-bagagens**
  - Retorna uma lista com todas as bagagens cadastradas no sistema.

- **GET /api/Bagagem/consultar-bagagem/{idBagagem}**
  - Consulta os detalhes de uma bagagem específica com base no seu ID.

- **PUT /api/Bagagem/atualizar-bagagem**
  - Atualiza os dados de uma bagagem existente.

- **PUT /api/Bagagem/atualizar-status-bagagem/{idBagagem}/{status}**
  - Atualiza o status de uma bagagem específica.

- **DELETE /api/Bagagem/deletar-bagagem/{idBagagem}**
  - Exclui uma bagagem do sistema.

### **Histórico de Movimentação**
Este recurso gerencia o histórico de movimentações das bagagens, permitindo rastrear alterações e movimentações em diferentes etapas.

- **POST /api/HistoricoMovimentacao/cadastrar-historico**
  - Registra uma nova movimentação no histórico de uma bagagem.
  
- **GET /api/HistoricoMovimentacao/listar-historico**
  - Retorna uma lista completa de todos os históricos de movimentações registrados.

- **GET /api/HistoricoMovimentacao/listar-historico-bagagem/{bagagemID}**
  - Lista o histórico de movimentações de uma bagagem específica.

- **GET /api/HistoricoMovimentacao/consultar-historico/{id}**
  - Consulta um histórico de movimentação específico com base no ID.

- **PUT /api/HistoricoMovimentacao/atualizar-historico**
  - Atualiza as informações de um histórico de movimentação já registrado.

- **DELETE /api/HistoricoMovimentacao/deletar-historico/{id}**
  - Exclui um histórico de movimentação do sistema.
