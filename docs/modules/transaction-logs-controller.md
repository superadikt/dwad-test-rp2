# TransactionLogsController

> MVC controller serving the transactional logs page with dummy data.

## Location

`Controllers/TransactionLogsController.cs`

## Namespace

`DwadTestRp.Controllers`

## Base Class

`Controller` (Microsoft.AspNetCore.Mvc)

## Actions

| Action  | HTTP Method | Route                  | Returns                           | Notes                              |
|---------|-------------|------------------------|-----------------------------------|------------------------------------|
| `Index` | GET         | `/TransactionLogs`     | `View(List<TransactionLog>)`      | Displays a table of dummy log entries |

## Views

- `Views/TransactionLogs/Index.cshtml` — Table with color-coded action badges (Bootstrap)

## Dependencies

- `DwadTestRp.Models.TransactionLog`

## Notes

- No persistence layer; returns hardcoded dummy data for demonstration.
- Navigation link added to the shared layout (`Views/Shared/_Layout.cshtml`).
