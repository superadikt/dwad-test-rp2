using Microsoft.AspNetCore.Mvc;
using DwadTestRp.Data;
using DwadTestRp.Models;
using DwadTestRp.Services;

namespace DwadTestRp.Controllers;

public class UserCreationRequestController : Controller
{
    private readonly IUserCreationRequestRepository _repo;
    private readonly IEmailSender _emailSender;

    public UserCreationRequestController(IUserCreationRequestRepository repo, IEmailSender emailSender)
    {
        _repo = repo;
        _emailSender = emailSender;
    }

    [HttpGet]
    public IActionResult Create()
    {
        // provide an empty instance to satisfy required members
        return View(new UserCreationRequest { RequestedBy = string.Empty, FullName = string.Empty, Email = string.Empty });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SubmitRequest(UserCreationRequest request)
    {
        if (!ModelState.IsValid)
            return View("Create", request);

        await _repo.SubmitAsync(request);
        return RedirectToAction(nameof(Pending));
    }

    [HttpGet]
    public async Task<IActionResult> Pending()
    {
        var list = await _repo.GetPendingAsync();
        return View(list);
    }

    [HttpGet]
    public async Task<IActionResult> Details(Guid id)
    {
        var req = await _repo.GetByIdAsync(id);
        if (req is null) return NotFound();
        return PartialView("_DetailsModal", req);
    }

    [HttpPost]
    public async Task<IActionResult> ApproveRequest([FromBody] Guid requestId)
    {
        try
        {
            // In a real app, get current user
            var approver = User?.Identity?.Name ?? "system";
            await _repo.ApproveAsync(requestId, approver);

            var req = await _repo.GetByIdAsync(requestId);
            if (req is not null)
            {
                await _emailSender.SendAsync(req.Email, "Account Approved", "Your account has been approved.");
            }
            return new JsonResult(new { success = true });
        }
        catch (InvalidOperationException ex)
        {
            return new JsonResult(new { success = false, error = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> RejectRequest([FromBody] Guid requestId)
    {
        // In a real app, get current user
        var approver = User?.Identity?.Name ?? "system";
        await _repo.RejectAsync(requestId, approver);

        var req = await _repo.GetByIdAsync(requestId);
        if (req is not null)
        {
            await _emailSender.SendAsync(req.Email, "Account Request Rejected", "Your account request was rejected.");
        }

        return new JsonResult(new { success = true });
    }
}
