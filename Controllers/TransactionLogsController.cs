using Microsoft.AspNetCore.Mvc;
using DwadTestRp.Models;

namespace DwadTestRp.Controllers;

public class TransactionLogsController : Controller
{
    public IActionResult Index()
    {
        // Dummy data for display purposes
        var logs = new List<TransactionLog>
        {
            new() { Id = 1, Timestamp = DateTime.Now.AddHours(-3), Action = "Create", Entity = "User", EntityId = "101", PerformedBy = "admin", Details = "Created user account" },
            new() { Id = 2, Timestamp = DateTime.Now.AddHours(-2), Action = "Update", Entity = "User", EntityId = "101", PerformedBy = "admin", Details = "Updated email address" },
            new() { Id = 3, Timestamp = DateTime.Now.AddHours(-1), Action = "Delete", Entity = "User", EntityId = "42", PerformedBy = "system", Details = "Removed inactive account" },
            new() { Id = 4, Timestamp = DateTime.Now.AddMinutes(-30), Action = "Login", Entity = "Session", EntityId = "5001", PerformedBy = "jdoe", Details = "User logged in" },
            new() { Id = 5, Timestamp = DateTime.Now.AddMinutes(-10), Action = "Export", Entity = "Report", EntityId = "77", PerformedBy = "admin", Details = "Exported monthly report" },
        };

        return View(logs);
    }
}
