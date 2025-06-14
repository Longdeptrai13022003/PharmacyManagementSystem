# PharmacyManagementSystem

**PharmacyManagementSystem** is a pharmacy management software developed using **C# .NET**, with **SQL Server** as the database, following the **MVC (Model - View - Controller)** architecture. It helps pharmacies efficiently manage their inventory, users, and sales operations.

## 🌟 Key Features

### 1. Medicine Management
- Add, edit, delete medicine records.
- Search by name, code, or category.
- Store detailed information: ingredients, unit, price, expiry date.

### 2. Inventory Management
- Manage medicine stock: import/export entries.
- Track current stock levels.
- Get alerts for low-stock items or medicines nearing expiry.

### 3. User Management
- Role-based access control (e.g., admin, sales staff, inventory staff).
- Create and manage user accounts.
- Reset passwords, activate/deactivate users.

### 4. Sales Management
- Create and process sales invoices.
- Automatically calculate total, discounts, and taxes (VAT).
- Store transaction history.
- Print retail receipts.

## 🛠️ Technologies Used

- **Language:** C# (.NET Framework / .NET Core)
- **Interface:** Windows Forms MVC
- **Database:** Microsoft SQL Server
- **Architecture:** MVC (Model - View - Controller)
- **Tools:** Visual Studio, SQL Server Management Studio (SSMS)

## 🗂️ Project Structure

```bash
PharmacyManagementSystem/
│
├── DAO/
│   └── AccountDAO.cs
│
├── DTO/
│   └── AccountDTO.cs
│
├── GUI/
│   ├── Login.cs
│   ├── MedicinesInfor.cs
│   └── Payment.cs
│
├── DatabaseDemo.sql/
│
├── App.config
├── PharmacyManagementSystem.sln
└── README.md

