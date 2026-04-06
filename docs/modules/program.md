# Program.cs

> Entry point and application configuration.

## Location

`Program.cs` (project root)

## Purpose

Configures the dependency injection container, registers middleware, and starts the web application using the minimal hosting model (top-level statements).

## Service Registration

| Service                    | Purpose                                      |
|----------------------------|----------------------------------------------|
| `AddControllersWithViews`  | Registers MVC controllers and Razor views    |
| `AddEndpointsApiExplorer`  | Enables endpoint metadata for Swagger        |
| `AddSwaggerGen`            | Configures OpenAPI/Swagger document generation |

## Middleware Pipeline (in order)

1. **Swagger** (Development only) - Serves `/swagger` UI and `/swagger/v1/swagger.json`
2. **ExceptionHandler** (Production only) - Redirects to `/Home/Error`
3. **Routing** - Matches incoming requests to endpoints
4. **Authorization** - Enforces authorization policies
5. **Static Assets** - Serves files from `wwwroot/`
6. **MVC Routing** - Maps `{controller=Home}/{action=Index}/{id?}` convention

## Swagger Configuration

- **Document**: v1
- **Title**: DwadTestRp API
- **Endpoint**: `/swagger/v1/swagger.json`

## Dependencies

- `Microsoft.OpenApi` (for `OpenApiInfo`)
- `Swashbuckle.AspNetCore` (for Swagger middleware)
