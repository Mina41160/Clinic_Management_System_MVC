# Clinic Management System 🏥

A web-based Clinic Management System built with **ASP.NET Core MVC**, **Entity Framework Core**, **SQL Server**, and **ASP.NET Core Identity**.

The system provides an authenticated internal dashboard for managing clinic departments, doctors, patients, and appointments through a clean and responsive interface.

## 🚀 Features

* 🔐 User Registration, Login, and Logout using ASP.NET Core Identity
* 🏢 Department Management
* 👨‍⚕️ Doctor Management
* 🧑‍🤝‍🧑 Patient Management
* 📅 Appointment Management
* 🔗 Department–Doctor relationships
* 🔄 Dependent Doctor dropdown based on selected Department
* ✅ Server-side model validation
* 📊 Dashboard with system statistics
* 🎨 Responsive UI using Bootstrap and custom CSS
* 🗄️ EF Core Code First with SQL Server

## 🛠️ Technologies

* C#
* ASP.NET Core MVC
* Entity Framework Core
* SQL Server
* ASP.NET Core Identity
* Razor Views
* HTML
* CSS
* Bootstrap
* LINQ

## 🏗️ Project Structure

```text
Clinic_Management_System_MVC
│
├── Controllers
├── Data
├── Models
├── ViewModels
├── Views
├── wwwroot
├── Program.cs
└── appsettings.json
```

## 📌 Main Modules

### Departments

Create, view, edit, and delete clinic departments.

### Doctors

Manage doctors and assign each doctor to a department.

### Patients

Manage patient information and contact details.

### Appointments

Create and manage appointments by selecting a department, doctor, patient, date, and time.

## 🔐 Authentication

The project uses **ASP.NET Core Identity** to provide user registration, login, and logout functionality.

The application is designed as an authenticated internal clinic management portal.

## 🗃️ Database

The project uses **Entity Framework Core Code First** with **SQL Server**.

The database schema is generated and updated using EF Core migrations.

## ▶️ How to Run

1. Clone the repository.
2. Open the solution in Visual Studio.
3. Update the SQL Server connection string in `appsettings.json` if necessary.
4. Apply the Entity Framework Core migrations.
5. Run the application.
6. Register a new account and log in.

## 📷 Screenshots

Screenshots of the dashboard and main management pages will be added here.

## 📚 What I Practiced

This project helped me practice:

* ASP.NET Core MVC architecture
* Controllers, Views, and Models
* Razor syntax
* Entity Framework Core
* CRUD operations
* Relationships between entities
* ViewModels and model binding
* Validation
* LINQ
* ASP.NET Core Identity
* SQL Server
* Bootstrap UI development

## 👨‍💻 Author

**Mina Shenouda**

Junior .NET Backend & Full-Stack Developer
Cairo, Egypt
