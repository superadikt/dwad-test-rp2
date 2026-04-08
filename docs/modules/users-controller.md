# UsersController

> MVC controller providing full CRUD operations for managing users.

## Location

`Controllers/UsersController.cs`

## Namespace

`DwadTestRp.Controllers`

## Base Class

`Controller` (Microsoft.AspNetCore.Mvc)

## Constructor

Uses primary constructor syntax (C# 13).

| Parameter         | Type              | Purpose                    |
|-------------------|-------------------|----------------------------|
| `userRepository`  | `IUserRepository` | Data access for User entities |

## Actions

| Action           | HTTP Method | Route              | Returns                    | Notes                              |
|------------------|-------------|---------------------|----------------------------|------------------------------------|
| `Index`          | GET         | `/Users`            | `View(List<User>)`         | Lists all users ordered by CreatedAt descending |
| `Create`         | GET         | `/Users/Create`     | `View()`                   | Displays empty create form         |
| `Create`         | POST        | `/Users/Create`     | `RedirectToAction` or `View(User)` | Creates user; re-displays form on validation failure |
| `Edit`           | GET         | `/Users/Edit/{id}`  | `View(User)` or `NotFound` | Displays edit form for existing user |
| `Edit`           | POST        | `/Users/Edit/{id}`  | `RedirectToAction` or `View(User)` | Updates user; re-displays form on validation failure |
| `Details`        | GET         | `/Users/Details/{id}` | `View(User)` or `NotFound` | Read-only view of a single user    |
| `Delete`         | GET         | `/Users/Delete/{id}` | `View(User)` or `NotFound` | Displays delete confirmation       |
| `DeleteConfirmed`| POST        | `/Users/Delete/{id}` | `RedirectToAction`         | Deletes user and redirects to Index |

## Views

- `Views/Users/Index.cshtml`
- `Views/Users/Create.cshtml`
- `Views/Users/Edit.cshtml`
- `Views/Users/Details.cshtml`
- `Views/Users/Delete.cshtml`

## Dependencies

- `DwadTestRp.Data.IUserRepository`
- `DwadTestRp.Models.User`

## Notes

- All POST actions use `[ValidateAntiForgeryToken]` for CSRF protection.
- Null checks on `id` parameters return `NotFound()` for missing or invalid IDs.
- Navigation link in shared layout (`Views/Shared/_Layout.cshtml`).
