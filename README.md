# Contador de Produtos - Aplicativo MAUI

Aplicativo desenvolvido com **.NET MAUI** para auxiliar na contagem e conferência de produtos, ideal para processos de inventário, entrada de mercadorias e verificação de divergências no estoque.

## 🧾 Funcionalidades

- Coleta de dados do produto (nome, quantidade e preço) diretamente pelo telefone.
- Armazenamento temporário das informações em memória até o envio ao sistema do cliente.
- Integração com o sistema do cliente via **API REST**.
- Recebimento e conferência de arquivos **CSV** enviados pelo cliente.
- Validação dos produtos com base na base de dados fornecida (quantidade e preço).
- Geração de arquivos CSV com as informações atualizadas e marcações de divergência.
- Exclusão automática dos dados da memória após envio bem-sucedido.

## 📦 Como Funciona

1. O cliente envia uma lista de produtos em formato CSV.
2. O aplicativo carrega os dados e exibe os produtos para conferência.
3. O usuário atualiza quantidades e visualiza alertas de divergência de preço.
4. Ao finalizar, um novo arquivo CSV é gerado e enviado à API do cliente.
5. Os dados armazenados em memória são apagados automaticamente.

## 📲 Requisitos

- Android 7.0 (Nougat) ou superior
- Conexão com a internet para envio de dados via API

## 🛠️ Tecnologias Utilizadas

- [.NET MAUI](https://learn.microsoft.com/pt-br/dotnet/maui/)
- **SQLite** para armazenamento local temporário
- **Material Design** para experiência visual moderna e intuitiva
- **Docker** (ambiente de backend ou testes)

## 🔐 Segurança e Acesso

- Todos os dados são armazenados somente em memória durante a execução.
- O controle de acesso à API é responsabilidade do contratante, por isso, **não é possível disponibilizá-la para demonstração pública.**
- Porém o código está aí  para ser analisado.

---

Desenvolvido para simplificar a rotina de conferência e contagem de estoque com praticidade e confiabilidade.
