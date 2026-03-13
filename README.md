---

# 📚 Library Management System (LMS) – Minimal API

A **Library Management System backend API** built using **ASP.NET Core Minimal API** and **Entity Framework Core**.
This project provides RESTful endpoints to manage **books, categories, members, and book issuing operations** in a library.

> ⚡ This is a **backend-only project** (No frontend included).

---

# 📑 Table of Contents

* 🚀 Tech Stack
* 🗂 Project Modules
* 🔗 API Endpoints
* ▶️ How to Run the Project
* ⭐ Features
* 👨‍💻 Author

---

# 🚀 Tech Stack

* **.NET 8**
* **ASP.NET Core Minimal API**
* **Entity Framework Core**
* **SQL Server**
* **RESTful API Architecture**

---

# 🗂 Project Modules

The system contains the following main modules:

📚 **Books**
Manage library books including adding, updating, retrieving, and deleting.

🏷 **Categories**
Manage book categories such as Fiction, Non-Fiction, Science, etc.

👤 **Members**
Manage library members who borrow books.

📖 **BookIssue**
Handle book issuing, searching issued books, and renewing books.

---

# 🔗 API Endpoints

## 📚 Books

| Method | Endpoint          | Description    |
| ------ | ----------------- | -------------- |
| GET    | `/api/books`      | Get all books  |
| GET    | `/api/books/{id}` | Get book by ID |
| POST   | `/api/books`      | Add a new book |
| PUT    | `/api/books/{id}` | Update book    |
| DELETE | `/api/books/{id}` | Delete book    |

---

## 👤 Members

| Method | Endpoint      | Description     |
| ------ | ------------- | --------------- |
| GET    | `/api/member` | Get all members |
| POST   | `/api/member` | Add new member  |

---

## 🏷 Categories

| Method | Endpoint          | Description        |
| ------ | ----------------- | ------------------ |
| GET    | `/api/categories` | Get all categories |
| POST   | `/api/categories` | Add category       |

---

## 📖 Book Issue

| Method | Endpoint                         | Description                   |
| ------ | -------------------------------- | ----------------------------- |
| GET    | `/api/bookissue`                 | Get issued books              |
| GET    | `/api/bookissue/search/{member}` | Search issued books by member |
| POST   | `/api/bookissue`                 | Issue a book                  |
| PUT    | `/api/bookissue/renew/{id}`      | Renew issued book             |

---

# ▶️ How to Run the Project

## 1️⃣ Clone the Repository

```bash
git clone https://github.com/D-pex/MInimal-API-LMS.git
cd MInimal-API-LMS
```

---

## 2️⃣ Configure Database

Update the **appsettings.json** file:

```json
"ConnectionStrings": {
  "MyDbContext": "Server=YOUR_SERVER;Database=LibraryProject;Trusted_Connection=True;TrustServerCertificate=True"
}
```

Replace `YOUR_SERVER` with your **SQL Server instance**.

---

## 3️⃣ Apply Database Migration

Run the following command:

```bash
dotnet ef database update
```

This will create the database and required tables.

---

## 4️⃣ Run the Application

```bash
dotnet run
```

The API will start at:

```
https://localhost:5000
```

---

# ⭐ Features

✔ Clean **Minimal API architecture**   
✔ **Entity Framework Core** for database operations  
✔ **SQL Server** integration   
✔ Modular and scalable endpoint structure   
✔ RESTful API design    
✔ Easy to extend for frontend integration  

---

# 👨‍💻 Author

**D-pex**

GitHub:
[https://github.com/D-pex](https://github.com/D-pex)

---
