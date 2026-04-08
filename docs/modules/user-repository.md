# IUserRepository / UserRepository

> Repository pattern implementation for User entity data access.

## Location

- Interface: `Data/IUserRepository.cs`
- Implementation: `Data/UserRepository.cs`

## Namespace

`DwadTestRp.Data`

## Base Class

`UserRepository` implements `IUserRepository`

## Constructor

Uses primary constructor syntax (C# 13).

| Parameter  | Type                    | Purpose                |
|------------|-------------------------|------------------------|
| `context`  | `ApplicationDbContext`  | EF Core database context |

## Interface Methods

| Method        | Return Type        | Parameters  | Description                              |
|---------------|--------------------|-------------|------------------------------------------|
| `GetAllAsync` | `Task<List<User>>` | -           | Returns all users ordered by CreatedAt descending |
| `GetByIdAsync`| `Task<User?>`      | `int id`    | Finds a user by primary key              |
| `AddAsync`    | `Task`             | `User user` | Sets CreatedAt to UTC now and saves      |
| `UpdateAsync` | `Task`             | `User user` | Sets UpdatedAt to UTC now and saves      |
| `DeleteAsync` | `Task`             | `int id`    | Removes user by ID if found              |

## Registration

Registered in `Program.cs` as a scoped service:

```csharp
builder.Services.AddScoped<IUserRepository, UserRepository>();
```

## Dependencies

- `Microsoft.EntityFrameworkCore`
- `DwadTestRp.Models.User`
- `DwadTestRp.Data.ApplicationDbContext`

## Notes

- `DeleteAsync` silently no-ops if the user ID is not found.
- `AddAsync` automatically sets `CreatedAt`; `UpdateAsync` automatically sets `UpdatedAt`.
