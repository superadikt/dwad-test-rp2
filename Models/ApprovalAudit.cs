namespace DwadTestRp.Models;

public class ApprovalAudit
{
    public int Id { get; set; }
    public required Guid RequestId { get; set; }
    public required string Action { get; set; }
    public string? PerformedBy { get; set; }
    public DateTime PerformedAt { get; set; } = DateTime.UtcNow;
    public string? Notes { get; set; }
}
