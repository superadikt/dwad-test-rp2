using System.ComponentModel.DataAnnotations;

namespace DwadTestRp.Models;

public enum RequestStatus
{
    Pending,
    Approved,
    Rejected
}

public class UserCreationRequest
{
    [Key]
    public Guid RequestId { get; set; } = Guid.NewGuid();

    [Required]
    public required string RequestedBy { get; set; }

    [Required]
    public required string FullName { get; set; }

    [Required]
    [EmailAddress]
    public required string Email { get; set; }

    public string? Role { get; set; }
    public string? OfficeId { get; set; }

    [Required]
    public string Status { get; set; } = RequestStatus.Pending.ToString();

    public DateTime DateRequested { get; set; } = DateTime.UtcNow;
    public DateTime? DateApproved { get; set; }
    public string? ApprovedBy { get; set; }
}
