# 📚 Library Management System (LMS) – Minimal API

A **Library Management System backend API** built using **.NET Minimal API and Entity Framework Core**.
This project manages books, users, categories, and book issuing operations.

> ⚡ Backend-only project (No frontend included)

---

# 📑 Table of Contents

* 🚀 Tech Stack
* 🗂 Project Modules
* 🔗 API Endpoints
* ▶️ How to Run the Project
* ⭐ Features

---

# 🚀 Tech Stack

* **.NET 6 / .NET 7 / .NET 8**
* **ASP.NET Core Minimal API**
* **Entity Framework Core**
* **SQL Server**
* **RESTful API Architecture**

---

# 🗂 Project Modules

The system contains the following main modules:

* 📚 **Books** – Manage library books
* 🏷 **Categories** – Book categories (Fiction, Non-Fiction, etc.)
* 👤 **Memebrs** – Library members
* 📖  **BookIssue** – Issue and return books

---

# 🔗 API Endpoints

## 📚 Books

| Method | Endpoint          | Description    |
| ------ | ----------------- | -------------- |
| GET    | `/api/Books`      | Get all books  |
| GET    | `/api/Books/{id}` | Get book by ID |
| POST   | `/api/Books`      | Add new book   |
| PUT    | `/api/Books/{id}` | Update book    |
| DELETE | `/api/Books/{id}` | Delete book    |

---

## 👤 Users

| Method | Endpoint     |
| ------ | ------------ |
| GET    | `/api/Member` |
| POST   | `/api/Member` |

---

## 🏷 Categories

| Method | Endpoint          |
| ------ | ----------------- |
| GET    | `/api/Categories` |
| POST   | `/api/Categories` |

---

## 📖 Books Issued

| Method | Endpoint                         | Description         |
| ------ | -------------------------------- | ------------------- |
| GET    | `/api/BookIssue`                 | Get Issued books    |
| GET    | `/api/BookIssue/search/{member}` | Search Issued books |
| POST   | `/api/BookIssue`                 | Issue a book        |
| PUT    | `/api/BookIssue/renew/{id}`      | Renew Issued book   |

---

# ▶️ How to Run the Project

### 1️⃣ Clone the Repository

```bash
https://github.com/D-pex/Project-LIBRARY.git
```

---

### 2️⃣ Configure Database

Update **appsettings.json**

```json
"ConnectionStrings": {
 "MyDbContext": "Server=YOUR_SERVER;Database=Library Project;Trusted_Connection=True;TrustServerCertificate=True"
}
```

---

### 3️⃣ Apply Database Migration

```bash
dotnet ef database update
```

---

### 4️⃣ Run the Application

```bash
dotnet run
```

The API will start at:

```
https://localhost:5XXX
```

---

# ⭐ Features

✔ Clean **Minimal API Architecture**,
✔ **Entity Framework Core** integration,
✔ Modular endpoint structure,
✔ RESTful API design,
✔ SQL Server database.

---

# 👨‍💻 Author

**D-pex**

GitHub:
https://github.com/D-pex
