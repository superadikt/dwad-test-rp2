# Agent Instructions

> Shared instructions for all AI coding agents (GitHub Copilot, Claude Code, and others).

## Project Context

- **Project**: DwadTestRp - ASP.NET Core MVC (.NET 9) with Swagger
- **Purpose**: Demo and knowledge sharing only
- **Solution**: `DwadTestRp.sln`

## Mandatory: Documentation Updates

When you create or modify any source code file (`.cs`, `.csproj`, `.cshtml`), you **must** update the project documentation accordingly:

### For new source files:
1. Create a module doc at `docs/modules/<kebab-case-name>.md`
2. Add an entry to the **Module Index** table in `docs/ARCHITECTURE.md`
3. Add the file to the **Project Structure** tree in `docs/ARCHITECTURE.md`
4. If it's an API controller, add its endpoints to the **API Endpoints** table

### For modified source files:
1. Update the corresponding module doc in `docs/modules/` to reflect current state
2. If endpoints changed, update the **API Endpoints** table in `docs/ARCHITECTURE.md`
3. If the middleware pipeline changed (`Program.cs`), update the **Application Pipeline** section

### What NOT to document:
- Changes to `docs/` files themselves (avoid infinite loops)
- Config files (`appsettings.json`, `launchSettings.json`)
- Static assets (`wwwroot/css`, `wwwroot/js`)
- `.gitignore`, `README.md`

### Module doc template:
Use `docs/modules/sample-api-controller.md` as the reference format. Each doc includes: title, location, namespace, base class, public API table, and dependencies.

## Code Conventions

- Nullable reference types: **enabled**
- Namespace style: **file-scoped**
- DTOs: **record types** (e.g., `public record SampleRequest(string Name)`)
- API controllers: `Controllers/Api/`, inherit `ControllerBase`, use `[ApiController]`
- MVC controllers: `Controllers/`, inherit `Controller`
- Route constraints: use typed constraints (e.g., `{id:int}`)
- HTTP responses: use appropriate status codes (`Ok`, `CreatedAtAction`, `NoContent`)

## Build & Run

```bash
dotnet build
dotnet run
```

- App: http://localhost:5069
- Swagger UI: http://localhost:5069/swagger (Development only)
