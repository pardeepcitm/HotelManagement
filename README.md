# 🏨 Hotel Management System

## ✨ Overview

This repository contains a full-stack hotel management application designed to handle room booking and checkout. The project follows a monorepo structure, separating the application logic into two main components: a powerful backend API and a modern frontend single-page application.

| **Component** | **Technology Stack** | 
| :--- | :--- |
| **Backend** | .NET 10 (C#), REST API |
| **Frontend** | React, TypeScript, Vite |

---

## 🚀 Getting Started

Follow these instructions to clone the repository and get both the backend and frontend up and running on your local machine.

### Prerequisites

* **Git:** Installed and configured.
* **Node.js & npm:** Node.js LTS version (18+) and npm.
* **.NET SDK:** Version 10.

### Installation & Cloning

1.  **Clone** the repository to your local machine:
    ```bash
    git clone https://github.com/pardeepcitm/HotelManagement.git
    cd hotelmanagement
    ```

---

### 1. Backend Setup (API)

The backend code is located in the **`backend/`** directory. It is responsible for data persistence and business logic.

1.  **Navigate** to the backend solution folder:
    ```bash
    cd backend/HotelManagementBackend
    ```
2.  **Restore** the necessary NuGet dependencies:
    ```bash
    dotnet restore
    ```
3.  **Build** the entire solution:
    ```bash
    dotnet build
    ```
4.  **Run** the API project (ensure the project name matches your solution structure, e.g., `RoomBooking.API`):
    ```bash
    dotnet run --project RoomBooking.API
    ```
    The API should start running, typically accessible at **`http://localhost:5000`**. If this endpoint changes, ensure you update the `VITE_API_BASE_URL` variable in the frontend's `.env & .envdevelopment` file (e.g., `VITE_API_BASE_URL=http://new-port/api`).

---

### 2. Frontend Setup (UI)

The frontend code is located in the **`frontend/`** directory. It consumes data from the backend API.

1.  **Navigate** to the frontend project folder:
    ```bash
    cd ../frontend/hotelmanagementfrontend
    ```
2.  **Install** the Node.js dependencies:
    ```bash
    yarn install
    ```
3.  **Start** the development server:
    ```bash
    yarn dev
    ```
    The React application will usually open in your browser at `http://localhost:3000`. **Ensure your backend API is already running** for the application to load data correctly.

## 🧩 Architecture Overview Backend

### **API Layer (`RoomBooking.API`)**
**Role:** Entry point for all external requests. Handles routing, request/response processing, Global exceptions and forwards calls to the Application Layer.

**Contains:**
- Controllers for Room Booking and Checkout
- Global exception handling

---

### **Application Layer (`RoomBooking.Application`)**
**Role:** Coordinates business workflows and enforces application rules. Defines all use cases of the system.

**Contains:**
- Booking Service (availability checks, pricing logic, status transitions)
- DTOs and mappers
- Factory Pattern for domain object creation
- Business logic related exceptions

---

### **Domain Layer (`RoomBooking.Domain`)**
**Role:** The core of the system — independent of all external layers. Defines constraints.

**Contains:**
- Entities 
- Pricing strategy

---

### **Infrastructure Layer (`RoomBooking.Infrastructure`)**
**Role:** In memory database setup.

**Contains:**
- Repository implementations (currently in-memory)
- Data persistence logic

---

## 🧪 Testing

- **Integration Tests** validate end-to-end booking workflows.
- **Unit Tests** ensure correctness across Application and Infrastructure layers.

---

## 🤝 Contributing

We welcome contributions! Please follow these steps:

1.  Fork the repository.
2.  Create your feature branch (`git checkout -b feature/new-booking-flow`).
3.  Commit your changes (`git commit -m 'feat: Implemented new guest checkout process'`).
4.  Push to the branch (`git push origin feature/new-booking-flow`).
5.  Open a Pull Request.

## 📄 License

Distributed under the **MIT License**.