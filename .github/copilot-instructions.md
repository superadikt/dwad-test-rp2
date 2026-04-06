# Copilot Instructions

## Project Overview

DwadTestRp is an ASP.NET Core MVC web application (.NET 9) with Swagger (Swashbuckle) for API documentation. This project is for demo and knowledge sharing only.

## Tech Stack

- .NET 9 / C# 13
- ASP.NET Core MVC
- Swashbuckle.AspNetCore 10.1.7 (Swagger)
- Bootstrap 5, jQuery

## Project Conventions

- **Nullable reference types** are enabled project-wide.
- **File-scoped namespaces** are used in all C# files.
- **Record types** are used for request/response DTOs (e.g., `SampleRequest`).
- **API controllers** live under `Controllers/Api/` and inherit from `ControllerBase`.
- **MVC controllers** live directly under `Controllers/` and inherit from `Controller`.
- Swagger is only enabled in the Development environment.

## Documentation Maintenance (IMPORTANT)

This project maintains living documentation under `docs/`. **Whenever you create or modify a source code file** (`.cs`, `.csproj`, `.cshtml`), you must also update the documentation:

1. **New file** - Create a corresponding doc in `docs/modules/` following the format of existing module docs. Then add it to the Module Index in `docs/ARCHITECTURE.md`.
2. **Modified file** - Update the corresponding doc in `docs/modules/` to reflect the changes.
3. **Structural changes** - Update `docs/ARCHITECTURE.md` to reflect any changes to:
   - The project structure tree
   - The API endpoints table
   - The Module Index table
   - The middleware pipeline (if `Program.cs` changed)

Do **not** update docs for non-source file changes (config JSON, CSS, JS, `.gitignore`, docs themselves).

### Documentation format reference

Each module doc should include:
- **Title** and one-line description
- **Location** (file path)
- **Namespace**
- **Base class** (if applicable)
- **Constructor parameters** (if applicable)
- **Public members / actions / endpoints** in a table
- **Dependencies**

See `docs/modules/sample-api-controller.md` as the reference template.

## Code Style

- Use primary constructors where appropriate.
- Use pattern matching and expression-bodied members for concise code.
- Use `[ApiController]` and `[Route("api/[controller]")]` attributes on API controllers.
- Use route constraints (e.g., `{id:int}`) for type safety.
- Return appropriate HTTP status codes (`Ok`, `CreatedAtAction`, `NoContent`, etc.).
