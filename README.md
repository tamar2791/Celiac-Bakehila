# Celiac Community Management System

This is a desktop application built with C# WinForms for managing the activities of a non-profit organization supporting the celiac community. The system handles customer records, gluten-free products, volunteers, suppliers, and sales. The application supports multiple user roles, each with a customized dashboard and capabilities.

---

## 🌟 Features

- 🔐 Role-based login: Admin, Branch Manager, Customer  
- 🛒 Product management and sales of gluten-free items  
- 📍 Multi-branch structure with per-branch control  
- 📦 Order management (create orders, view history, checkout)  
- 🧑‍🤝‍🧑 Customer registration, profile updates, and purchase history  
- 🧾 Printable order details for branch managers  
- 🧮 Real-time sales and order tracking  
- 🧠 Simple and intuitive user interface for all roles  

---

## 👥 User Roles

### 🛠 Admin Dashboard
- Manage branches, suppliers, and products
- Create and manage new sales
- Assign products to each sale

### 🧍 Customer Dashboard
- Register/login via phone number
- Update personal information
- View information about the organization
- Place orders during active sales (add to cart, checkout, view past orders)

### 🏢 Branch Manager Dashboard
- View customers linked to their branch
- View and print order details

---

## 🖥 Technologies Used

- C# WinForms (.NET Framework)  
- Local database (e.g., SQL Server Express)  
- Visual Studio  
- Layered architecture (UI, Business Logic, Data Access)  

---

## 🚀 Getting Started

### Prerequisites:
- Windows OS  
- Visual Studio 2019 or newer  
- .NET Framework installed (version as used in project)  
- SQL Server or SQL Server Express  

### Run the Application:

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/celiac-management.git
   ```

2. Open the solution (`.sln`) file in Visual Studio.

3. Build the project using:
   ```
   Build > Build Solution (Ctrl+Shift+B)
   ```

4. Configure your database connection if needed.

5. Run the application:
   ```
   Debug > Start Debugging (F5)
   ```

---

## 📂 Project Structure

```
/CeliacApp
│
├── Forms/                  # UI Windows Forms
├── DataAccess/             # Database handling (CRUD)
├── BusinessLogic/          # Core logic and calculations
├── Models/                 # Data models (Customer, Product, etc.)
├── Program.cs              # Main entry point
├── App.config              # Configuration file
├── README.md               # Project description
└── .gitignore              # Git ignore rules
```

---

## 🔒 Login Simulation (Optional)

- Admin: `admin@example.com` / `admin123`
- Customer: login with phone number
- Branch Manager: predefined credentials in DB

> (These credentials are only for development/testing purposes)

---

## 📌 Future Improvements

- [ ] Add reports and analytics  
- [ ] Multi-language support  
- [ ] Email/SMS notifications  
- [ ] Move to web-based UI (ASP.NET or React)  

---

## 📃 License

This project is for educational/non-commercial use.
