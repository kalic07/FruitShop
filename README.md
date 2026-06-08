# Fruit Shop Pricing System

## Overview

This solution demonstrates a small, extensible fruit pricing system built using C# and .NET 10.

The application calculates the total cost of fruit orders while supporting multiple pricing models and promotional pricing rules. The design follows SOLID principles, Clean Architecture concepts, and common enterprise development practices.

---

## Requirements Implemented

### Fruit Definition

Each fruit contains:

* Name
* Base Price
* Pricing Strategy

Example:

| Fruit  | Base Price | Pricing Method                     |
| ------ | ---------- | ---------------------------------- |
| Apple  | $2.00      | Per Kg                             |
| Banana | $0.30      | Per Item                           |
| Cherry | $5.00      | Per Kg with 10% discount above 2kg |

---

## Features

### Supported Pricing Models

#### Per Kilogram

Example:

```text
Apple
1.5kg × $2.00
= $3.00
```

#### Per Item

Example:

```text
Banana
6 × $0.30
= $1.80
```

#### Discounted Weight Pricing

Example:

```text
Cherry
3kg × $5.00
= $15.00

10% Discount

= $13.50
```

### Order Pricing

The system supports orders containing multiple fruit types and calculates a single total price.

Example:

```text
Apple  1.5kg
Banana 6 items
Cherry 3kg

Total = $18.30
```

---

# Solution Structure

```text
FruitShop.sln
│
├── FruitShop.Domain
│
├── FruitShop.Application
│
├── FruitShop.Infrastructure
│
├── FruitShop.Console
│
└── FruitShop.Tests
```

---

## Project Responsibilities

### FruitShop.Domain

Contains business rules and core domain models.

#### Entities

```text
Fruit
Order
OrderLine
```

#### Pricing

```text
IPricingStrategy
PerKgPricingStrategy
PerItemPricingStrategy
DiscountedKgPricingStrategy
```

The Domain layer contains no infrastructure concerns and no dependency injection.

---

### FruitShop.Application

Contains application orchestration logic.

#### Factories

```text
IFruitFactory
FruitFactory

IPricingStrategyFactory
PricingStrategyFactory
```

#### Strategy Resolvers

```text
IPricingStrategyResolver

PerKgPricingResolver
PerItemPricingResolver
DiscountedKgPricingResolver
```

#### Services

```text
IOrderPricingService
PricingEngine
```

The Application layer coordinates the domain model and business workflows.

---

### FruitShop.Infrastructure

Contains external concerns.

#### Implementations

```text
JsonFruitCatalog
```

#### Configuration

```text
fruits.json
```

Infrastructure is responsible for loading fruit definitions from configuration.

---

### FruitShop.Console

Application entry point.

Responsibilities:

* Configure dependency injection
* Build the application host
* Execute the pricing use case

No business logic exists in this layer.

---

### FruitShop.Tests

Contains unit tests for:

```text
Pricing Strategies
Pricing Strategy Resolvers
Pricing Strategy Factory
Fruit Factory
Pricing Engine
```

---

# Design Patterns Used

## Strategy Pattern

The Strategy Pattern is used to encapsulate pricing algorithms.

### Why?

Different fruits may use completely different pricing rules.

Without Strategy:

```csharp
if (fruit == "Apple")
{
}
else if (fruit == "Banana")
{
}
```

This quickly becomes difficult to maintain.

With Strategy:

```csharp
IPricingStrategy
```

Each pricing rule becomes an independent implementation.

Benefits:

* Open/Closed Principle
* Easy testing
* Easy extension
* Clear separation of responsibilities

---

## Factory Pattern

The Factory Pattern is used to create fruit instances and pricing strategies.

### FruitFactory

Responsible for creating Fruit domain objects.

### PricingStrategyFactory

Responsible for creating pricing strategies from fruit configuration.

Benefits:

* Centralized object creation
* Reduced coupling
* Easier maintenance
* Better testability

---

## Dependency Injection

Dependency Injection is used throughout the application.

Benefits:

* Loose coupling
* Easier unit testing
* Better maintainability
* Adherence to SOLID principles

---

# Pricing Strategy Resolution

The system avoids large switch statements by using resolver registration.

Example:

```text
PricingType.PerKg
      ↓
PerKgPricingResolver
      ↓
PerKgPricingStrategy
```

Adding a new pricing strategy requires creating:

```text
NewPricingStrategy
NewPricingResolver
```

and registering it in Dependency Injection.

Existing code remains unchanged.

---

# Configuration

Fruit definitions are stored in:

```text
fruits.json
```

Example:

```json
[
  {
    "name": "Apple",
    "basePrice": 2.00,
    "pricingType": "PerKg"
  },
  {
    "name": "Banana",
    "basePrice": 0.30,
    "pricingType": "PerItem"
  },
  {
    "name": "Cherry",
    "basePrice": 5.00,
    "pricingType": "DiscountedKg",
    "discountThreshold": 2,
    "discountPercentage": 0.10
  }
]
```

Fruit names and property names are processed case-insensitively.

---

# Running the Application

## Prerequisites

* .NET 10 SDK or later

Verify installation:

```bash
dotnet --version
```

---

## Build

```bash
dotnet build
```

---

## Run

```bash
dotnet run --project FruitShop.Console
```

Expected output:

```text
Fruit Shop
----------
Apple - Qty: 1.5
Banana - Qty: 6
Cherry - Qty: 3

Total: $18.30
```

---

# Running Tests

Run all tests:

```bash
dotnet test
```

---

# Unit Testing Approach

The solution uses:

* xUnit
* Moq
* FluentAssertions

Tests follow the Arrange / Act / Assert pattern.

Example:

```csharp
[Fact]
public void CalculatePrice_ShouldReturnCorrectPrice()
{
    // Arrange
    var strategy = new PerKgPricingStrategy();

    // Act
    var result = strategy.CalculatePrice(2m, 5m);

    // Assert
    result.Should().Be(10m);
}
```

---

# Extending the System

## Add a New Fruit

Add a new entry to:

```text
fruits.json
```

Example:

```json
{
  "name": "Orange",
  "basePrice": 3.00,
  "pricingType": "PerKg"
}
```

No code changes required.

---

## Add a New Pricing Model

Create a new strategy:

```csharp
public sealed class BuyOneGetOnePricingStrategy
    : IPricingStrategy
{
}
```

Create a resolver:

```csharp
public sealed class BuyOneGetOnePricingResolver
    : IPricingStrategyResolver
{
}
```

Register it in Dependency Injection.

No existing code must be modified.

---

## Add Seasonal Discounts

Create:

```text
SeasonalDiscountPricingStrategy
SeasonalDiscountPricingResolver
```

and configure discount rules through JSON or a future database-backed catalog.

---

# Future Enhancements

For a production-grade implementation, the following improvements could be added:

### Domain

* Money Value Object
* Currency support
* Rich domain validation

### Infrastructure

* Database-backed fruit catalog
* Distributed caching
* External pricing service integration

### Observability

* Structured logging with Serilog
* OpenTelemetry tracing
* Metrics collection

### Testing

* Integration tests
* Contract tests
* Mutation testing

### Performance

* BenchmarkDotNet benchmarks
* Catalog caching
* Parallel order processing

---

# Key Design Principles

The solution was built around the following principles:

* Single Responsibility Principle
* Open/Closed Principle
* Dependency Inversion Principle
* Separation of Concerns
* Clean Architecture
* Testability
* Extensibility

The resulting design allows new fruits, pricing models, and discount strategies to be added with minimal changes to existing code while maintaining a high level of test coverage and maintainability.
