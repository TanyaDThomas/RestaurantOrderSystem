# 🍽️ Restaurant Order System

## 📌 Overview

This is a full-stack ASP.NET Core MVC web application for managing restaurant orders. It uses **Entity Framework Core**, **SQL Server**, and **ASP.NET Core Identity** for authentication and user management.

The system allows users to browse a menu, add items to a cart, place orders, and generate printable receipts.

---

## 🚀 Features

- 🔐 User authentication & registration (ASP.NET Core Identity)  
- 🍔 Menu browsing (items with pricing and descriptions)  
- 🛒 Shopping cart functionality  
- 👤 Customer profile management  
- 📦 Order creation and tracking  
- 🧾 Receipt generation and printing  
- 💳 Payment method & status tracking (simulated)  
- 🗂️ Relational database design using EF Core  

---

## 🧱 Tech Stack

- ASP.NET Core MVC  
- Entity Framework Core  
- SQL Server  
- ASP.NET Core Identity  
- C#  
- Razor Views  

---

## 🗄️ Database Design

The system includes:

- Customers  
- Items (Menu)  
- Orders  
- OrderItems  

### Relationships:

- Customer → Orders (1-to-many)  
- Order → OrderItems (1-to-many)  
- Item → OrderItems (1-to-many)  

---

## 🔐 Authentication

ASP.NET Core Identity is used for:

- User registration  
- Login/logout  
- Secure user sessions  

Each user is linked to a customer profile for order processing.

---

## 🧾 Key Workflow

1. User registers/logs in  
2. Browses menu items  
3. Adds items to cart  
4. Proceeds to checkout  
5. System validates customer profile  
6. Order is created and stored  
7. Receipt is generated for printing  

---

## 📸 Future Improvements

- Admin dashboard for managing menu items  
- Order status real-time updates  
- Email receipt generation  
- Payment gateway integration (Stripe/PayPal)  
- Role-based access (Admin / Customer / Staff)  

---

## 🎯 Purpose of Project

This project was built to practice:

- ASP.NET Core MVC architecture  
- Entity Framework Core relationships  
- Identity authentication  
- Real-world CRUD + order processing workflows  
