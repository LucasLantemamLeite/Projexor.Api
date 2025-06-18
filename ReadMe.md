# Projexor - API

Um projeto para portfólio que tem como ideia a criação e gerenciamento de projetos, utilizando **ASP.NET** como tecnologia para o backend.

---

## 🚀 Tecnologias

- **ASP.NET Core**
- **Entity Framework Core**
- **SQLite** (banco de dados local para testes)
- **JWT Bearer** (autenticação via token)
- **Argon2** (hash seguro de senhas)

---

## 📌 Models

### `UserAccount`

Representa as informações da conta do usuário na aplicação:

| Campo         | Descrição                                   |
| ------------- | ------------------------------------------- |
| `Id`          | Identificador único (GUID)                  |
| `Name`        | Nome do usuário                             |
| `Email`       | E-mail utilizado no login                   |
| `Password`    | Senha (armazenada como hash Argon2)         |
| `PhoneNumber` | Número de telefone do usuário               |
| `BirthDate`   | Data de nascimento                          |
| `CreateAt`    | Data de criação da conta                    |
| `Active`      | Indica se a conta está ativa (`true/false`) |
| `Role`        | Papel do usuário (ex: admin, padrão - 1)    |

---

## 🛢 Banco de Dados

Atualmente usando **SQLite** (arquivo local `ProjexorDb`) para testes locais sem precisar configurar Docker ou ambientes externos.

👉 Planejado para migração futura para **SQL Server**, **MySQL** ou outro banco de produção.

---

## 🔐 Token

- **JWT Bearer** para geração de token de autenticação dos usuários.
- Claims no token incluem dados como: Id, Nome, Telefone, Data de Nascimento, Role e Active.

---

## 🔑 Hash

Senhas dos usuários são armazenadas com hash gerado via **Argon2id** para maior segurança.

---

## 📦 DTOs

Uso de **Data Transfer Objects (DTOs)** para validação das informações recebidas nas requisições (ex: cadastro de usuário).

---

## 🌐 Rotas

| Método | Rota       | Descrição                                 |
| ------ | ---------- | ----------------------------------------- |
| POST   | `/v1/user` | Criação e validação de contas de usuários |

> Exemplo: [http://localhost:5094/v1/user](http://localhost:5094/v1/user)

---

## 📝 Roadmap (futuro)

- [ ] Adicionar outras entidades (projetos, tarefas, etc)
- [ ] Migração do banco para SQL Server / MySQL
- [ ] Refatoração em camadas (Services, Repository, etc)
- [ ] Melhorias na autenticação (refresh token)

---

## 💡 Observações

> Este projeto está em desenvolvimento para portfólio e prática. O foco inicial está no backend e autenticação.
