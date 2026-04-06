# ErrorViewModel

> View model used by the error page to display request tracking information.

## Location

`Models/ErrorViewModel.cs`

## Namespace

`DwadTestRp.Models`

## Properties

| Property       | Type      | Description                                                  |
|----------------|-----------|--------------------------------------------------------------|
| `RequestId`    | `string?` | The current activity ID or HTTP trace identifier             |
| `ShowRequestId`| `bool`    | Computed property; `true` when `RequestId` is not null/empty |

## Usage

Instantiated in `HomeController.Error()` and passed to `Views/Shared/Error.cshtml`. The `RequestId` helps correlate error reports with server logs.
