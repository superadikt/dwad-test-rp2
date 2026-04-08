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

