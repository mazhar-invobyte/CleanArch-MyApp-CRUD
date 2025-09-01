# CleanArch-MyApp-CRUD

 This repository provides a demonstration of a simple CRUD (Create, Read, Update, Delete) application built with ASP.NET Core Web API, following the principles of Clean Architecture. It uses Entity Framework Core for data access against a SQL Server database and MediatR to implement the CQRS pattern.

## Table of Contents

- [Features](#features)
- [Architecture](#architecture)
- [Getting Started](#getting-started)
- [Project Structure](#project-structure)
- [API Endpoints](#api-endpoints)
- [Contributing](#contributing)
- [License](#license)

## Features

- **Clean Architecture**: Separation of concerns between application layers.
- **CRUD Operations**: Create, Read, Update, Delete for entities.
- **.NET Core Web API**: Modern API framework with dependency injection.
- **Unit Testing**: Easily testable business logic.
- **Scalable & Maintainable**: Built for extensibility.

## Architecture

This project follows [Clean Architecture](https://github.com/jasontaylordev/CleanArchitecture) principles:

- **Presentation Layer**: API controllers, request/response models.
- **Application Layer**: Business logic, use cases, service interfaces.
- **Domain Layer**: Core entities, domain logic.
- **Infrastructure Layer**: Data access, external service integrations.

## Getting Started

### Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Visual Studio](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/) (optional)

### Setup and Configuration

1. **Clone the repository:**
   ```bash
   git clone https://github.com/mazhar-invobyte/CleanArch-MyApp-CRUD.git
   cd CleanArch-MyApp-CRUD
   ```

2. **Configure the database connection:**
   Open the `MyApp.Api/appsettings.Development.json` file and update the MyAppDb connection string:
   ```json
   {
     "ConnectionStrings": {
       "MyAppDb": "Server=YOUR_SQL_SERVER;Database=MyAppDb;Trusted_Connection=True;TrustServerCertificate=True;"
     }
   }
   ```

3. **Apply database migrations:**
   Run the following command from the root directory to create the database and the Employees table:
   ```bash
   dotnet ef database update --project MyApp.Infrastructure
   ```

4. **Run the application:**
   ```bash
   dotnet run --project MyApp.Api
   ```

5. **Access the API:**
   - The API will be running on http://localhost:5176
   - Access the Swagger UI to explore and test the API endpoints at http://localhost:5176/swagger

## Project Structure

```
src/
  ├── Domain/           # Domain entities and interfaces
  ├── Application/      # Use cases, business logic
  ├── Infrastructure/   # Data access, external integrations
  └── WebApi/           # API controllers and startup
```

## API Endpoints

Typical CRUD endpoints (example):

| Method | Endpoint           | Description                 |
|--------|--------------------|-----------------------------|
| GET    | /api/entities      | Get all entities            |
| GET    | /api/entities/{id} | Get entity by id            |
| POST   | /api/entities      | Create new entity           |
| PUT    | /api/entities/{id} | Update existing entity      |
| DELETE | /api/entities/{id} | Delete entity               |

> See Swagger/OpenAPI documentation at `/swagger` when running the API.

## Contributing

Contributions, issues, and feature requests are welcome!  
Feel free to check [issues page](https://github.com/mazhar-invobyte/CleanArch-MyApp-CRUD/issues).

## License

This project is licensed under the MIT License.

---

**Author**: [mazhar-invobyte](https://github.com/mazhar-invobyte)  
**Last Updated**: 2025-09-01 11:42:21 UTC