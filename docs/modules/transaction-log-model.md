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

| `Module` | `string` | `string.Empty` | Logical module name (e.g. "User Creation Approval") |

## Example

```text
Timestamp: 2026-04-08T12:00:00Z
Module: User Creation Approval
Action: Approved User Creation Request
Entity: UserCreationRequest
EntityId: 9f8b6c2a-3d7e-4e2a-b8c1-5a0b4d1f6a2c
PerformedBy: admin
Details: FullName=Jane Doe;Email=jane@example.com;Role=Manager;RequestId=9f8b6c2a-3d7e-4e2a-b8c1-5a0b4d1f6a2c
```

## Dependencies

- None
