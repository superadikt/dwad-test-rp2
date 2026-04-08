# Project Architecture

> **Auto-maintained document.** Updated whenever project files are added or modified.

## Overview

DwadTestRp is an ASP.NET Core MVC web application built on .NET 9, featuring both server-rendered views and a REST API documented with Swagger (Swashbuckle). This project uses Entity Framework Core with SQL Server for data persistence.

## Tech Stack

| Component         | Technology                  | Version  |
|-------------------|-----------------------------|----------|
| Framework         | ASP.NET Core MVC            | .NET 9.0 |
| Language          | C#                          | 13       |
| Database          | SQL Server (LocalDB)        | -        |
| ORM               | Entity Framework Core       | 9.0.0    |
| API Documentation | Swashbuckle.AspNetCore      | 10.1.7   |
| Frontend          | Razor Views + Bootstrap     | 5.x      |
| Client Scripting  | jQuery, jQuery Validation    | -        |

## Project Structure

```
DwadTestRp/
|-- Program.cs                          # Application entry point & middleware pipeline
|-- DwadTestRp.csproj                   # Project file (target: net9.0)
|-- DwadTestRp.sln                      # Solution file
|
|-- Controllers/
|   |-- HomeController.cs               # MVC controller (Index, Privacy, Error)
|   |-- Api/
|       |-- SampleApiController.cs      # REST API controller (CRUD endpoints)
|
|-- Models/
|   |-- ErrorViewModel.cs               # Error page view model
|   |-- User.cs                         # User entity model
|
|-- Data/
|   |-- ApplicationDbContext.cs         # EF Core database context
|
|-- Migrations/                         # EF Core migration files
|   |-- 20260406082452_InitialCreateUsersTable.cs
|   |-- 20260406082452_InitialCreateUsersTable.Designer.cs
|   |-- ApplicationDbContextModelSnapshot.cs
|
|-- Views/
|   |-- _ViewImports.cshtml             # Global Razor imports & tag helpers
|   |-- _ViewStart.cshtml               # Default layout assignment
|   |-- Home/
|   |   |-- Index.cshtml                # Home page view
|   |   |-- Privacy.cshtml              # Privacy page view
|   |-- Shared/
|       |-- _Layout.cshtml              # Master layout template
|       |-- _Layout.cshtml.css          # Layout-scoped CSS
|       |-- _ValidationScriptsPartial.cshtml  # Client-side validation scripts
|       |-- Error.cshtml                # Error page view
|
|-- Properties/
|   |-- launchSettings.json             # Launch profiles (HTTP, IIS Express)
|
|-- wwwroot/                            # Static assets (served at root)
|   |-- css/site.css                    # Custom site styles
|   |-- js/site.js                      # Custom site scripts
|   |-- favicon.ico                     # Site favicon
|   |-- lib/                            # Third-party client libraries
|       |-- bootstrap/                  # Bootstrap CSS & JS
|       |-- jquery/                     # jQuery
|       |-- jquery-validation/          # jQuery Validation
|       |-- jquery-validation-unobtrusive/  # Unobtrusive validation
|
|-- appsettings.json                    # Base configuration
|-- appsettings.Development.json        # Development overrides
|-- docs/                               # Project documentation
    |-- ARCHITECTURE.md                 # This file
    |-- modules/                        # Per-module documentation
```

## Application Pipeline

Configured in `Program.cs`, the middleware pipeline executes in this order:

```
Request
  |-> DbContext (ApplicationDbContext registered)
  |-> [Development] Swagger / SwaggerUI
  |-> [Production]  ExceptionHandler (/Home/Error)
  |-> Routing
  |-> Authorization
  |-> Static Assets (wwwroot/)
  |-> MVC Controller Routing ({controller=Home}/{action=Index}/{id?})
Response
```

## Module Index

| Module | Documentation | Description |
|--------|---------------|-------------|
| Program.cs | [program.md](modules/program.md) | Entry point, service registration, middleware pipeline |
| ApplicationDbContext | [application-db-context.md](modules/application-db-context.md) | EF Core database context |
| User | [user-model.md](modules/user-model.md) | User entity model |
| UserCreationRequest | [user-creation-request.md](modules/user-creation-request.md) | Workflow for approving new user creation requests |
| HomeController | [home-controller.md](modules/home-controller.md) | MVC controller serving Razor views |
| SampleApiController | [sample-api-controller.md](modules/sample-api-controller.md) | REST API with CRUD operations |
| ErrorViewModel | [error-view-model.md](modules/error-view-model.md) | View model for error page rendering |

## Database Schema

### Users Table

| Column | Type | Constraints |
|--------|------|-------------|
| Id | int | Primary Key, Identity |
| FirstName | nvarchar(100) | NOT NULL |
| LastName | nvarchar(100) | NOT NULL |
| Email | nvarchar(255) | NOT NULL, Unique Index |
| CreatedAt | datetime2 | NOT NULL |
| UpdatedAt | datetime2 | NULL |

**Indexes:**
- `PK_Users` - Primary key on Id
- `IX_Users_Email` - Unique index on Email

## API Endpoints

All API endpoints are under the `/api/SampleApi` base route.

| Method | Route                 | Action    | Request Body    | Response             |
|--------|-----------------------|-----------|-----------------|----------------------|
| GET    | /api/SampleApi        | GetAll    | -               | `string[]`           |
| GET    | /api/SampleApi/{id}   | GetById   | -               | `{ Id, Name }`       |
| POST   | /api/SampleApi        | Create    | `SampleRequest` | `{ Id, Name }` (201) |
| PUT    | /api/SampleApi/{id}   | Update    | `SampleRequest` | `{ Id, Name }`       |
| DELETE | /api/SampleApi/{id}   | Delete    | -               | 204 No Content       |

**Request Model:**
```csharp
public record SampleRequest(string Name);
```

## Configuration

### Launch Profiles (`Properties/launchSettings.json`)

| Profile     | URL                          | Environment |
|-------------|------------------------------|-------------|
| http        | http://localhost:5069         | Development |
| IIS Express | http://localhost:63850        | Development |

### App Settings (`appsettings.json`)

- **ConnectionStrings**:
  - DefaultConnection: `Server=(localdb)\mssqllocaldb;Database=DwadTestRpDb;Trusted_Connection=True;MultipleActiveResultSets=true`
- **Logging**: Default = `Information`, ASP.NET Core = `Warning`
- **AllowedHosts**: `*` (all hosts)

## Key Design Decisions

1. **Swagger in Development only** - SwaggerUI is conditionally enabled via `app.Environment.IsDevelopment()` to avoid exposing API docs in production.
2. **Separate API namespace** - API controllers live under `Controllers/Api/` and inherit from `ControllerBase`, keeping them distinct from MVC controllers that inherit from `Controller`.
3. **Record types for request models** - `SampleRequest` uses C# record syntax for concise, immutable DTOs.
4. **Entity Framework Core** - Uses code-first approach with migrations for database schema management.
5. **Primary constructors** - ApplicationDbContext uses C# 13 primary constructor syntax.
6. **No HTTPS in template** - Project was scaffolded with `--no-https` for simpler local demo setup.
