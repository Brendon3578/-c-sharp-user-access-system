# User Access Watcher System

Este projeto em C# foi desenvolvido para monitorar e organizar os acessos de usuários a uma página web. O sistema processa um arquivo JSON contendo registros de acessos e exibe os acessos distintos e agrupados por data.

## 💻 Descrição

O `User Access Watcher System` lê um arquivo JSON com informações de usuários e suas respectivas datas de acesso a uma página. Ele permite exibir usuários que acessaram em dias específicos e organiza essas informações em uma estrutura que destaca acessos únicos por dia. O sistema também gera relatórios detalhados de acessos distintos e por data, utilizando funcionalidades de manipulação de coleções em C#.

## 🔮 Funcionalidades

- **Leitura de Arquivo JSON**: O sistema lê e desserializa um arquivo JSON contendo acessos de usuários, armazenando os dados em uma lista de objetos.
- **Acessos Únicos**: Utiliza um `HashSet` para garantir que apenas acessos únicos sejam contabilizados e exibidos.
- **Organização por Data**: Os acessos são agrupados e exibidos por data, usando um dicionário (`Dictionary`) que mapeia a data para os usuários que acessaram nesse dia.
- **Exibição Detalhada**: O sistema exibe tanto os acessos únicos como o agrupamento de acessos por dia no console.

## 🛠️ Estrutura do Código

- **Classe `UserAccess`**: Representa um acesso de usuário, contendo as propriedades `username` (nome do usuário) e `access_date` (data do acesso).
- **Classe `Program`**: Classe principal que contém a lógica de leitura do arquivo JSON, processamento dos dados, e exibição de informações.
- **Manipulação de Coleções**: O projeto usa `HashSet` para eliminar duplicatas e `Dictionary` para mapear os acessos por data, facilitando a organização e visualização.


## Pilares de POO Utilizados

 📁 Estrutura do JSON

O arquivo `user-access.json` deve seguir este formato:

```json
{
  "data": [
    {
      "username": "brendon_gomes",
      "access_date": "2024-09-29T14:30:00Z"
    },
    {
      "username": "john_doe",
      "access_date": "2024-09-29T16:00:00Z"
    }
  ]
}
```


## 🎈 Exemplo de Uso

Ao rodar o sistema, o programa processa o arquivo JSON e exibe:

1. A lista de usuários que acessaram em dias distintos, sem duplicatas.
2. O número total de acessos únicos.
3. Um relatório detalhado dos acessos por data, com os nomes de usuários que acessaram em cada dia.

Exemplo de saída no console:

```
────── Users accessed on day (distinct):
brendon_gomes
john_doe

Total users access in days (distinct): 2

────── Access Dates
┌──── Access in 29/09/2024 ───
├─ brendon_gomes
├─ john_doe
└─────────────────────────────
```

## 🔧 Tecnologias Utilizadas

- **C#**
- **.NET 8.0**
- **System.Text.Json** para desserialização de JSON

---

<h3 align="center">
    Feito com ☕ por <a href="https://github.com/Brendon3578"> Brendon Gomes</a>
</h3>
