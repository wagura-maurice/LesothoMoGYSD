# 📊 MISSA & NISSA System

**MISSA (Multi-Indicator Survey System Application)** and **NISSA (National Information System for Social Assistance)** is a modern, robust web application designed to manage survey data, targeting, and reporting for social protection programs.

---

## 🚀 Technology Stack

- **.NET 9**: Modern and performant framework used across backend and frontend
- **Blazor Server**: Chosen for its real-time UI capability and server-side processing
- **MudBlazor**: Provides a rich set of Material Design components
- **Bootstrap 5**: Used for responsive layout and classic styling flexibility
- **Visual Studio**: Main IDE for development (2022/2025)

---

## 🧠 Why Blazor Server?

Blazor Server was selected because of:

- ✅ Real-time interactivity via SignalR without full page reloads
- ✅ All logic stays on the server, enhancing security
- ✅ Smaller client footprint, ideal for low-bandwidth scenarios
- ✅ One language (C#) for full-stack development
- ✅ Strong integration with .NET ecosystem (EF Core, Identity, DI, etc.)

---

## 🗂️ Project Structure

### Solution Projects

#### 1. MoGYSD.Business
- **Core Purpose**: Contains the business logic and domain models
- **Key Responsibilities**:
  - Business rules and validations
  - Domain entities and models
  - Business workflows and processes
  - Interfaces for services
  - Data access abstractions

#### 2. MoGYSD.Services
- **Core Purpose**: Implements application services and infrastructure
- **Key Responsibilities**:
  - Service layer implementations
  - Cross-cutting concerns (logging, caching, etc.)
  - External service integrations
  - Email services
  - File handling (PDF/Excel exports)
  - Repository pattern implementation

#### 3. MoGYSD.ViewModels
- **Core Purpose**: Data transfer objects between UI and business logic
- **Key Responsibilities**:
  - View-specific data models
  - Data validation attributes
  - Data transformation (mapping to/from domain models)
  - API request/response models
  - Organized by feature/module

#### 4. MoGYSD.Web
- **Core Purpose**: User interface and API layer
- **Key Responsibilities**:
  - Blazor Server UI components
  - API controllers
  - Authentication/authorization
  - Request/response handling
  - Dependency injection configuration
  - Client-side validation
  - UI state management

### How They Work Together:
1. **Web** receives HTTP requests
2. **ViewModels** validate and structure the incoming data
3. **Business** processes the request using business rules
4. **Services** handle data access and external integrations
5. The response flows back through the layers to the UI

---

### Directory Structure

```plaintext
📦 MISSA-NISSA
├── 📁 MoGYSD.Business     # Business logic and domain models
├── 📁 MoGYSD.Services     # Application services and infrastructure
├── 📁 MoGYSD.ViewModels   # Data transfer objects and validation
└── 📁 MoGYSD.Web          # Web UI and API layer
```

---

### 🔸 Business  
Responsible for core entities and data persistence

- **Entities**: Represent database tables grouped by modules (e.g., Beneficiaries, Districts)  
- **Persistence**:  
  - EF Core `DbContext` and migrations  
  - `OnModelCreating` configures relationships, constraints, keys, and properties  
- **Views Folder**: Contains SQL view models for read-only and reporting purposes  

---

### 🔸 Services  
Contains shared utilities and helper services

- Email service (SMTP-based)  
- PDF & Excel export utilities  
- Generic Repository Pattern implementation:  
  - Centralizes data access logic  
  - Promotes cleaner, testable code  
  - Example interfaces: `IRepository<T>` and `GenericRepository<T>`  

---

### 🔸 ViewModels  
Bridges the gap between Entities and the UI

- All user-facing models for data binding, display, and validation  
- Organized per module (e.g., `DistrictViewModel`, `HouseholdViewModel`)  
- Includes AutoMapper profiles for mapping between entities and view models  

---

### 🔸 Web (UI)  
Blazor Server-based user interface

- Razor pages and components organized per module  
- Global DI setup, routing, and `appsettings.json` configuration  
- Integrated with MudBlazor and Bootstrap for rich, responsive UI  
- Features forms, dashboards, permission checks, and role-based navigation  

---

## 📋 Key Features

- 🔐 Role & Permission management  
- 🏘️ Household & Population Targeting modules  
- 📊 Real-time data validation and feedback  
- 📤 Export to PDF and Excel  
- 🧮 SQL View support for reporting  
- 📱 Responsive UI with Bootstrap and MudBlazor  
- ⚙️ Dynamic configuration through `appsettings.json`  

---

## 🧪 Run the Project Locally

1️⃣ **Clone the Repository**

```bash

