Fruit Shop Pricing System

Overview

This solution demonstrates a small, extensible fruit pricing system built using C# and .NET 10.

The application calculates the total cost of fruit orders while supporting multiple pricing models and promotional pricing rules. 
The design follows SOLID principles, Clean Architecture concepts, and common enterprise development practices.

Solution Structure

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


Design Patterns Used

Strategy Pattern

The Strategy Pattern is used to encapsulate pricing algorithms.

IPricingStrategy

Each pricing rule becomes an independent implementation.

Benefits:

Open/Closed Principle
Easy testing
Easy extension
Clear separation of responsibilities

Factory Pattern

The Factory Pattern is used to create fruit instances and pricing strategies.

FruitFactory

Responsible for creating Fruit domain objects.

PricingStrategyFactory

Responsible for creating pricing strategies from fruit configuration.

Benefits:

Centralized object creation
Reduced coupling
Easier maintenance
Better testability

Dependency Injection

Dependency Injection is used throughout the application.

Benefits:

Loose coupling
Easier unit testing
Better maintainability
Adherence to SOLID principles

Pricing Strategy Resolution

The system avoids large switch statements by using resolver registration.

Example:

PricingType.PerKg
      ↓
PerKgPricingResolver
      ↓
PerKgPricingStrategy

Adding a new pricing strategy requires creating:

NewPricingStrategy
NewPricingResolver

and registering it in Dependency Injection.

Existing code remains unchanged.

Configuration

Fruit definitions are stored in:

fruits.json

Example:

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

Fruit names and property names are processed case-insensitively.

Extending the System

Add a new entry to:

fruits.json

Example:

{
  "name": "Orange",
  "basePrice": 3.00,
  "pricingType": "PerKg"
}

No code changes required.


Add a New Pricing Model

Create a new strategy:

public sealed class BuyOneGetOnePricingStrategy: IPricingStrategy
{
}

Create a resolver:

public sealed class BuyOneGetOnePricingResolver: IPricingStrategyResolver
{
}

Register it in Dependency Injection.

No existing code must be modified.


Unit Testing Approach


The solution uses:

xUnit
Moq

Tests follow the Arrange / Act / Assert pattern.

Example:


