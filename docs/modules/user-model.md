# User Model

Entity representing a user in the system.

## Location

`Models/User.cs`

## Namespace

`DwadTestRp.Models`

## Properties

| Property | Type | Description | Constraints |
|----------|------|-------------|-------------|
| Id | int | Primary key, auto-generated | Identity |
| FirstName | string | User's first name | Required, Max 100 chars |
| LastName | string | User's last name | Required, Max 100 chars |
| Email | string | User's email address | Required, Max 255 chars, Unique |
| CreatedAt | DateTime | Timestamp when user was created | Required, defaults to UTC now |
| UpdatedAt | DateTime? | Timestamp when user was last updated | Nullable |

## Database Mapping

- Table: `Users`
- Primary Key: `Id` (IDENTITY)
- Unique Index: `IX_Users_Email` on Email column

## Dependencies

- None (POCO entity)

## Notes

- Uses C# 13 `required` modifier for mandatory string properties
- `CreatedAt` defaults to `DateTime.UtcNow` when entity is instantiated
- Email uniqueness is enforced at the database level via unique index
