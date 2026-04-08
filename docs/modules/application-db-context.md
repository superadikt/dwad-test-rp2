# ApplicationDbContext

Entity Framework Core database context for the application.

## Location

`Data/ApplicationDbContext.cs`

## Namespace

`DwadTestRp.Data`

## Base Class

`DbContext`

## Constructor Parameters

| Parameter | Type | Description |
|-----------|------|-------------|
| options | DbContextOptions<ApplicationDbContext> | Configuration options for the context |

## DbSets

| Property | Type | Description |
|----------|------|-------------|
| Users | DbSet<User> | Collection of User entities |
| UserCreationRequests | DbSet<UserCreationRequest> | Collection of user creation request entities |
| ApprovalAudits | DbSet<ApprovalAudit> | Audit entries for approvals/rejections |
| TransactionLogs | DbSet<TransactionLog> | Global transaction log entries |

## OnModelCreating Configuration

Configures entity mappings and constraints:

### User Entity Configuration

- **Primary Key**: `Id` property
- **FirstName**: Required, max length 100 characters
- **LastName**: Required, max length 100 characters
- **Email**: Required, max length 255 characters, unique index
- **CreatedAt**: Required timestamp

## Dependencies

- Microsoft.EntityFrameworkCore
- DwadTestRp.Models.User

## Registration

Registered in `Program.cs` with SQL Server provider:

```csharp
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
```

## Connection String

Configured in `appsettings.json`:
- Database: `DwadTestRpDb`
- Server: `(localdb)\mssqllocaldb`
- Authentication: Trusted Connection

## Migrations

| Migration | Description | Date |
|-----------|-------------|------|
| InitialCreateUsersTable | Creates Users table with constraints | 2026-04-06 |

## Notes

- Uses primary constructor syntax (C# 13)
- Follows EF Core Fluent API configuration pattern
- Email uniqueness enforced via database unique index
