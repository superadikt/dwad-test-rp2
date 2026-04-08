# UserCreationRequest

> Approval workflow for create new user requests.

## Location

`Models/UserCreationRequest.cs`

## Namespace

`DwadTestRp.Models`

## Description

Provides a persistent model for requesting new user accounts. Includes status, auditing fields and metadata used by the approval workflow.

## Public members

| Property | Type | Notes |
|--|--|--|
| `RequestId` | `Guid` | Primary key |
| `RequestedBy` | `string` | User who requested |
| `FullName` | `string` | Full name for new user |
| `Email` | `string` | Email address (unique check on approval) |
| `Role` | `string?` | Optional role assignment |
| `OfficeId` | `string?` | Office identifier |
| `Status` | `string` | One of `Pending`, `Approved`, `Rejected` |
| `DateRequested` | `DateTime` | When requested |
| `DateApproved` | `DateTime?` | When approved/rejected |
| `ApprovedBy` | `string?` | Approver identity |

## Related components

- `Controllers/UserCreationRequestController.cs` - MVC controller for submitting and approving requests.
- `Data/UserCreationRequestRepository.cs` - Persistence and approval/rejection implementation.
- `Services/IEmailSender.cs` - Sends email notifications upon approval/rejection.
- `Views/UserCreationRequest/` - Razor views for creating requests and listing pending requests with modal preview.
 - `Data/TransactionLogRepository.cs` - Records transaction logs for actions like approve/reject.

## Transaction Logging

All approve/reject actions create a `TransactionLog` entry with Module: `User Creation Approval` (Module name is exactly `User Creation Approval`), action and details (FullName, Email, Role, RequestId) after successful database commit. The `Action` field will be either `Approved User Creation Request` or `Rejected User Creation Request`.

