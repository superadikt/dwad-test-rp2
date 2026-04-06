# HomeController

> Default MVC controller serving the main site pages.

## Location

`Controllers/HomeController.cs`

## Namespace

`DwadTestRp.Controllers`

## Base Class

`Controller` (Microsoft.AspNetCore.Mvc)

## Constructor

| Parameter                   | Purpose              |
|-----------------------------|----------------------|
| `ILogger<HomeController>`   | Structured logging   |

## Actions

| Action    | HTTP Method | Route          | Returns              | Notes                        |
|-----------|-------------|----------------|----------------------|------------------------------|
| `Index`   | GET         | `/`            | `View()`             | Home page                    |
| `Privacy` | GET         | `/Home/Privacy`| `View()`             | Privacy policy page          |
| `Error`   | GET         | `/Home/Error`  | `View(ErrorViewModel)` | Cached disabled, uses `Activity.Current?.Id` or `TraceIdentifier` |

## Views

- `Views/Home/Index.cshtml`
- `Views/Home/Privacy.cshtml`
- `Views/Shared/Error.cshtml` (shared)

## Dependencies

- `DwadTestRp.Models.ErrorViewModel`
- `System.Diagnostics.Activity`
