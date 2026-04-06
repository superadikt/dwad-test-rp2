# SampleApiController

> REST API controller providing CRUD operations for demo purposes.

## Location

`Controllers/Api/SampleApiController.cs`

## Namespace

`DwadTestRp.Controllers.Api`

## Base Class

`ControllerBase` (Microsoft.AspNetCore.Mvc)

## Attributes

- `[ApiController]` - Enables automatic model validation, binding source inference, and problem details responses
- `[Route("api/[controller]")]` - Resolves to `/api/SampleApi`

## Endpoints

| Action    | HTTP Method | Route                  | Parameters                         | Response                    |
|-----------|-------------|------------------------|------------------------------------|-----------------------------|
| `GetAll`  | GET         | `/api/SampleApi`       | -                                  | `200 OK` with `string[]`    |
| `GetById` | GET         | `/api/SampleApi/{id}`  | `id: int` (route)                  | `200 OK` with `{ Id, Name }`|
| `Create`  | POST        | `/api/SampleApi`       | `SampleRequest` (body)             | `201 Created` with location |
| `Update`  | PUT         | `/api/SampleApi/{id}`  | `id: int` (route), `SampleRequest` (body) | `200 OK` with `{ Id, Name }`|
| `Delete`  | DELETE      | `/api/SampleApi/{id}`  | `id: int` (route)                  | `204 No Content`            |

## Request Model

```csharp
public record SampleRequest(string Name);
```

A positional record with a single `Name` property. Immutable by default.

## Notes

- Route constraints (`{id:int}`) ensure only integer IDs are accepted.
- `Create` returns a `CreatedAtAction` response pointing to `GetById` for proper REST semantics.
- No persistence layer; returns hardcoded/inline data for demonstration.
