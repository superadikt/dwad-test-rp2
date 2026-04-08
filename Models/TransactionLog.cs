namespace DwadTestRp.Models;

public class TransactionLog
{
    public int Id { get; set; }
    // Date/time when the action was performed
    public DateTime Timestamp { get; set; }

    // Friendly module name (e.g. "User Creation Approval")
    public string Module { get; set; } = string.Empty;

    // Action description (e.g. "Approved User Creation Request")
    public string Action { get; set; } = string.Empty;

    // Entity type affected (e.g. "UserCreationRequest")
    public string Entity { get; set; } = string.Empty;

    // ID of the affected entity (stringified)
    public string EntityId { get; set; } = string.Empty;

    // Who performed the action
    public string PerformedBy { get; set; } = string.Empty;

    // Human-readable details (FullName, Email, Role, RequestId)
    public string Details { get; set; } = string.Empty;
}
