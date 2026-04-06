# Program.cs

> Entry point and application configuration.

## Location

`Program.cs` (project root)

## Purpose

Configures the dependency injection container, registers middleware, and starts the web application using the minimal hosting model (top-level statements).

## Service Registration

| Service                    | Purpose                                      |
|----------------------------|----------------------------------------------|
| `AddDbContext<ApplicationDbContext>` | Registers EF Core DbContext with SQL Server |
| `AddControllersWithViews`  | Registers MVC controllers and Razor views    |
| `AddEndpointsApiExplorer`  | Enables endpoint metadata for Swagger        |
| `AddSwaggerGen`            | Configures OpenAPI/Swagger document generation |

### Database Configuration

```csharp
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
```

- **Provider**: SQL Server
- **Connection String**: Read from `appsettings.json` under `ConnectionStrings:DefaultConnection`
- **Database**: `DwadTestRpDb`

## Middleware Pipeline (in order)

1. **DbContext** - ApplicationDbContext registered for dependency injection
2. **Swagger** (Development only) - Serves `/swagger` UI and `/swagger/v1/swagger.json`
3. **ExceptionHandler** (Production only) - Redirects to `/Home/Error`
4. **Routing** - Matches incoming requests to endpoints
5. **Authorization** - Enforces authorization policies
6. **Static Assets** - Serves files from `wwwroot/`
7. **MVC Routing** - Maps `{controller=Home}/{action=Index}/{id?}` convention

## Swagger Configuration

- **Document**: v1
- **Title**: DwadTestRp API
- **Endpoint**: `/swagger/v1/swagger.json`

## Dependencies

- `Microsoft.EntityFrameworkCore`
- `DwadTestRp.Data.ApplicationDbContext`
- `Microsoft.OpenApi` (for `OpenApiInfo`)
- `Swashbuckle.AspNetCore` (for Swagger middleware)
