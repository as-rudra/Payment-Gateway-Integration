# Payment Gateway Integration

A backend payment gateway integration project built with **ASP.NET Core Web API** using **3-Tier Architecture**, **Entity Framework Core**, and **SQL Server**.

The project demonstrates how an application can create orders, initiate payments through an external payment gateway, and handle payment-related responses.

## Features

* Order creation and management
* Payment creation for existing orders
* External payment gateway integration
* Payment request generation
* Transaction ID generation
* Success, failure, and cancellation URL handling
* HTTP communication using `HttpClient`
* Dependency Injection
* Asynchronous programming
* Configuration management using `appsettings.json`
* Entity Framework Core Database-First approach
* Swagger API documentation
* 3-Tier Architecture

## Technologies Used

* **C#**
* **ASP.NET Core Web API**
* **Entity Framework Core**
* **SQL Server**
* **Swagger / OpenAPI**
* **HttpClient**
* **Dependency Injection**
* **SSLCommerz Sandbox API**

## Architecture

The project follows a simple 3-tier architecture:

```text
PaymentGatewayDemo
│
├── AppAPI
│   ├── Controllers
│   └── API Endpoints
│
├── BLL
│   ├── Services
│   └── DTOs
│
└── DAL
    └── EF
        ├── PaymentDbContext
        └── Tables
```

### AppAPI

Handles HTTP requests and responses through API controllers.

### BLL

Contains the business logic, DTOs, payment services, and communication with the payment gateway service.

### DAL

Handles database communication using Entity Framework Core and SQL Server.

## Database

The project uses a SQL Server database named:

```text
PaymentDB
```

### Orders

Stores customer order information.

```text
Id
CustomerName
TotalAmount
Status
```

### Payments

Stores payment transaction information.

```text
Id
OrderId
Amount
TransactionId
Status
```

The `Payments` table has a foreign key relationship with the `Orders` table.

## Payment Flow

```text
Client
  │
  ▼
PaymentController
  │
  ▼
PaymentService
  │
  ├── Get Order
  │
  ├── Generate Transaction ID
  │
  └── Create Gateway Request
          │
          ▼
   PaymentGatewayService
          │
          ▼
    SSLCommerz API
          │
          ▼
    Payment Gateway Response
```

## API Endpoints

### Create Order

```http
POST /api/Order
```

Example request:

```json
{
  "customerName": "Test Customer",
  "totalAmount": 100,
  "status": "Pending"
}
```

### Get All Orders

```http
GET /api/Order
```

### Get Order by ID

```http
GET /api/Order/{id}
```

### Create Payment

```http
POST /api/Payment/create
```

Example request:

```json
{
  "orderId": 1
}
```

The API retrieves the order, generates a transaction ID, prepares the payment request, and sends it to the configured payment gateway.

## Configuration

Payment gateway credentials and connection strings are stored in `appsettings.json`.

Example:

```json
{
  "ConnectionStrings": {
    "PaymentDB": "Server=YOUR_SERVER;Database=PaymentDB;Trusted_Connection=True;TrustServerCertificate=True;"
  },

  "PaymentGateway": {
    "StoreId": "YOUR_STORE_ID",
    "StorePassword": "YOUR_STORE_PASSWORD",
    "BaseUrl": "YOUR_GATEWAY_URL"
  }
}
```

**Do not upload real payment gateway credentials to GitHub.**

For a real project, use environment variables, User Secrets, or another secure configuration mechanism.

## How to Run

### 1. Clone the repository

```bash
git clone YOUR_REPOSITORY_URL
```

### 2. Open the solution

Open:

```text
PaymentGatewayDemo.sln
```

in Visual Studio.

### 3. Configure SQL Server

Create the `PaymentDB` database and the required `Orders` and `Payments` tables.

### 4. Configure the connection string

Update the `PaymentDB` connection string in:

```text
AppAPI/appsettings.json
```

### 5. Configure payment gateway credentials

Add your sandbox payment gateway credentials to the `PaymentGateway` section.

### 6. Run the project

Run the ASP.NET Core Web API project.

### 7. Open Swagger

Swagger can be used to test the API endpoints.

```text
https://localhost:<port>/swagger
```

## Learning Objectives

This project was developed to understand:

* How payment gateway integration works
* How an ASP.NET Core Web API communicates with an external API
* How `HttpClient` is used for external HTTP requests
* How Dependency Injection works
* How to structure a backend using 3-tier architecture
* How Database-First Entity Framework Core works
* How DTOs separate API requests from database entities
* How asynchronous operations work in .NET
* How configuration values are managed in ASP.NET Core
* How payment transaction data can be handled in a backend system

## Future Improvements

* Implement payment validation after successful payment
* Store payment transactions in the database
* Add IPN handling
* Add authentication and authorization
* Add centralized exception handling
* Add structured logging
* Add payment status tracking
* Add automated tests

## Author

**Anik Sarker Rudra**

BSc in Computer Science & Engineering
American International University-Bangladesh (AIUB)
