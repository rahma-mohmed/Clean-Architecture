# School System - Clean Architecture Implementation

This repository contains a Clean Architecture implementation for a **School System** project. The project is structured into multiple layers, including the **API**, **Core**, **Infrastructure**, and **Service** layers, following Clean Architecture principles to ensure separation of concerns and maintainable code.

## Main Features

- **Clean Architecture**: The project implements Clean Architecture for organizing the code and ensuring separation of concerns across various layers.
- **Modular Layers**: The project is divided into the following layers:
  - **API**: Handles the interaction with the client (e.g., HTTP requests).
  - **Core**: Contains business logic, entities, interfaces, and use cases.
  - **Infrastructure**: Contains the implementation of services like database access and external integrations.
  - **Service**: Contains services used by the API and interacts with the Core layer.
- **Maintainability**: Follows Clean Architecture principles to ensure that the system is scalable and maintainable.

## Technology Stack

- **C#**: Programming language used for backend development.
- **.NET**: Framework for building and running the application.
- **Entity Framework Core**: ORM used for database operations.
- **SQL Server**: Database used for storing data.

## Project Structure

The project follows a layered architecture:

- **API Layer**: Exposes RESTful API endpoints to the client.
- **Core Layer**: Contains the domain entities and business logic of the application.
- **Infrastructure Layer**: Contains implementations for database interactions and other external services.
- **Service Layer**: Provides services used by the API layer to interact with the core business logic.

## Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/school-system.git](https://github.com/rahma-mohmed/Clean-Architecture)
