# Restaurant Reservation System

A .NET Core project designed to manage restaurant reservations, menu items, orders, and employees. This system is implemented using Entity Framework Core (EF Core) as the ORM, enabling CRUD operations, views, database functions, and stored procedures.

## Table of Contents

- [Project Overview](#project-overview)
- [Features](#features)
- [Setup and Installation](#setup-and-installation)
- [Database Schema](#database-schema)
- [Project Structure](#project-structure)
- [Usage](#usage)
- [Contributing](#contributing)

## Project Overview

The **Restaurant Reservation System** project is a console application developed in .NET Core 5.0+ using Entity Framework Core to interact with a SQL Server database. It follows an organized architecture with data models, repository classes, and asynchronous LINQ queries. The project is hosted on GitHub, with each phase committed following Git best practices.

## Features

1. **CRUD Operations**: Provides create, update, and delete methods for each entity.
2. **Repository Pattern**: Each entity has a repository for separation of concerns.
3. **Asynchronous Operations**: LINQ operations are asynchronous, improving performance.
4. **Database Views**: Retrieves reservation and employee data from pre-defined views.
5. **Database Functions**: Calculates total revenue by restaurant.
6. **Stored Procedures**: Identifies customers with reservations over a specified party size.
7. **Data Seeding**: Populates tables with initial records for testing.

## Setup and Installation

### Prerequisites

- [.NET Core SDK 5.0 or later](https://dotnet.microsoft.com/download/dotnet/5.0)
- [SQL Server Management Studio (SSMS)](https://docs.microsoft.com/sql/ssms/download-sql-server-management-studio-ssms) for creating the database
- [Git](https://git-scm.com/) for version control

### Step 1: Clone the Repository

```bash
git clone https://github.com/username/RestaurantReservation.git
cd RestaurantReservation
