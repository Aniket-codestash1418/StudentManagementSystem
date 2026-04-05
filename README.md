# 📚 Student Management System API

---

## 🚀 Overview

A **Student Management System** built using **ASP.NET Core Web API** following a **Layered Architecture**.
It provides secure CRUD operations with **JWT Authentication**, **EF Core**, and **SQL Server**.

---

## 🏗️ Architecture

```
StudentManagementSystem.API          → Controllers, Middleware, Logs
StudentManagementSystem.Application  → Services, DTOs, Interfaces
StudentManagementSystem.Domain       → Entities
StudentManagementSystem.Infrastructure → DbContext, Repositories, MIgrations
```

---

## ⚙️ Tech Stack

* ASP.NET Core Web API
* Entity Framework Core (Code First)
* SQL Server
* JWT Authentication
* Serilog Logging
* Swagger

---

# 🛠️ SETUP GUIDE (STEP-BY-STEP)

---

## 🔹 STEP 1: Clone Repository

```bash
git clone https://github.com/Aniket-codestash1418/StudentManagementSystem.git
cd StudentManagementSystem
```

---

## 🔹 STEP 2: Open in Visual Studio

* Open `.sln` file
* Set **StudentManagementSystem.API** as Startup Project

---

## 🔹 STEP 3: Configure Database

Update connection string in:

📁 `appsettings.json`

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=StudentDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

> ⚠️ Replace `YOUR_SERVER` with your SQL Server instance

---

## 🔹 STEP 4: Apply Migrations

Open **Package Manager Console** and run:

```powershell
Add-Migration InitialCreate
Update-Database 
```

---

## 🔹 STEP 5: Run Application

* Press **F5** or click Run
* Swagger UI will open automatically

```
https://localhost:<port>/swagger
```

---

# 🔐 AUTHENTICATION FLOW

---

## 🔹 STEP 6: Login

```http
POST /api/LoginAuth/Login
```

```json
{
  "username": "admin",
  "password": "password"
}
```

---

## 🔹 STEP 7: Copy JWT Token

Response:

```json
{
  "token": "your_jwt_token_here"
}
```

---

## 🔹 STEP 8: Authorize in Swagger

* Click 🔒 **Authorize**
* Enter:

```
your_jwt_token_here
```

---

# 📊 API ENDPOINTS

| Method | Endpoint                        | Description       |
| ------ | ------------------------------- | ----------------- |
| GET    | /api/Student/getallstudentdata  | Get all students  |
| POST   | /api/Student/addstudent         | Add student       |
| PUT    | /api/Student/updatestudentdata  | Update student    |
| DELETE | /api/Student/deletestudent      | Delete student    |
| POST   | /api/LoginAuth/Login            | Login             |

---

# 📦 SAMPLE REQUEST

## ➤ Add Student

```json
POST /api/students

{
  "name": "Ram",
  "email": "ram@gmail.com",
  "age": 22,
  "course": "CS"
}
```

---

# 📦 SAMPLE RESPONSE

## ✅ Success

```json
{
  "StatusCode": 200,
  "Message": "Record added successfully",
  "data": null
}
```

---

---

# ⚠️ ERROR HANDLING

* Global Exception Middleware
* Standard API Response format
* Proper HTTP Status Codes (200, 201, 404, 400, 204)

---
---

# 📌 NOTES

* `CreatedDate` is set only during creation
* DTOs used to avoid exposing entities

---

# 👨‍💻 AUTHOR

Developed as part of assignment submission.

---
