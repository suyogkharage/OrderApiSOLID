# 📦 Order Management API (ASP.NET Core)

## 🔹 Overview
This project is a **.NET Core Web API** that demonstrates:

- ✅ Implementation of **SOLID principles**
- ✅ **Factory Pattern** for runtime selection of:
  - Payment processors (`CreditCard`, `PayPal`)
  - Order repositories (`SQL`, `MongoDB`)
- ✅ Clean architecture with Controllers, Services, Repositories, Validators, and Notifications
- ✅ Extensibility, maintainability, and testability

---

## 🔹 Features
- **Order Placement Workflow**
  1. Validate order
  2. Process payment (`CreditCard` / `PayPal`)
  3. Save order (`SQL` / `MongoDB`)
  4. Send notification (`Email` / `SMS`)

- **Factory Pattern**
  - `PaymentProcessorFactory` → choose `CreditCard` or `PayPal` at runtime
  - `OrderRepositoryFactory` → choose `SQL` or `MongoDB` at runtime

- **Extensibility**
  - Add new payment methods, repositories, or notification channels without modifying core business logic

---

## 🔹 Where SOLID Principles Are Used

### **S – Single Responsibility Principle**
- `OrderService` → only coordinates order placement (does not validate, send emails, or save directly)  
- `BasicOrderValidator` → only responsible for validation  
- `SqlOrderRepository` / `MongoOrderRepository` → only handle persistence  
- `EmailNotification` / `SmsNotification` → only handle notifications  

---

### **O – Open/Closed Principle**
- Adding new payment processors (e.g., `UPIProcessor`) requires **no modification** to existing code  
- Adding new repositories (e.g., `CosmosOrderRepository`) only requires extending the factory  

---

### **L – Liskov Substitution Principle**
- Any `IPaymentProcessor` (CreditCard, PayPal) can replace another without breaking `OrderService`  
- Any `INotification` (Email, SMS) can replace another safely  

---

### **I – Interface Segregation Principle**
- `IOrderRepository` defines only what’s needed (`Save`, `GetById`)  
- No “fat” interfaces forcing implementations to include unused methods  

---

### **D – Dependency Inversion Principle**
- `OrderService` depends on abstractions (`IOrderRepositoryFactory`, `IPaymentProcessorFactory`, `INotification`) instead of concrete implementations  
- Factories use DI to resolve the correct implementation  

---

## 🔹 Extending the API

### **Add new Payment Processor**
- Implement `IPaymentProcessor` (e.g., `StripeProcessor`)  
- Register it in DI  
- Update `PaymentProcessorFactory`  

### **Add new Repository**
- Implement `IOrderRepository` (e.g., `CosmosOrderRepository`)  
- Register it in DI  
- Update `OrderRepositoryFactory`  

### **Add new Notification Channel**
- Implement `INotification` (e.g., `PushNotification`)  
- Register it in DI  

---

## 🔹 Architecture Diagram

```mermaid
classDiagram
    class OrderService {
        +PlaceOrder()
    }

    %% Payment
    class IPaymentProcessor {
        <<interface>>
        +ProcessPayment()
    }
    class CreditCardProcessor {
        +ProcessPayment()
    }
    class PayPalProcessor {
        +ProcessPayment()
    }
    class PaymentProcessorFactory {
        +GetProcessor(type)
    }

    %% Repository
    class IOrderRepository {
        <<interface>>
        +Save()
        +GetById()
    }
    class SqlOrderRepository {
        +Save()
        +GetById()
    }
    class MongoOrderRepository {
        +Save()
        +GetById()
    }
    class OrderRepositoryFactory {
        +GetRepository(type)
    }

    %% Notification
    class INotification {
        <<interface>>
        +Send()
    }
    class EmailNotification {
        +Send()
    }
    class SmsNotification {
        +Send()
    }

    %% Relationships
    OrderService --> IPaymentProcessor
    OrderService --> IOrderRepository
    OrderService --> INotification
    PaymentProcessorFactory --> IPaymentProcessor
    OrderRepositoryFactory --> IOrderRepository

    IPaymentProcessor <|.. CreditCardProcessor
    IPaymentProcessor <|.. PayPalProcessor
    IOrderRepository <|.. SqlOrderRepository
    IOrderRepository <|.. MongoOrderRepository
    INotification <|.. EmailNotification
    INotification <|.. SmsNotification

