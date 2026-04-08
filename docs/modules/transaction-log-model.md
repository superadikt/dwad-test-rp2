# TransactionLog

> Entity model representing a transactional log entry.

## Location

`Models/TransactionLog.cs`

## Namespace

`DwadTestRp.Models`

## Properties

| Property    | Type       | Default          | Description                         |
|-------------|------------|------------------|-------------------------------------|
| `Id`        | `int`      | -                | Unique log entry identifier         |
| `Timestamp` | `DateTime` | -                | When the action occurred            |
| `Action`    | `string`   | `string.Empty`   | Type of action (Create, Update, Delete, etc.) |
| `Entity`    | `string`   | `string.Empty`   | Entity type affected                |
| `EntityId`  | `string`   | `string.Empty`   | ID of the affected entity           |
| `PerformedBy` | `string` | `string.Empty`   | User or system that performed the action |
| `Details`   | `string`   | `string.Empty`   | Human-readable description          |

## Dependencies

- None
