using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DwadTestRp.Data;
using DwadTestRp.Models;

namespace DwadTestRp.Controllers;

public class UsersController(ApplicationDbContext context) : Controller
{
    public async Task<IActionResult> Index()
    {
        var users = await context.Users.OrderByDescending(u => u.CreatedAt).ToListAsync();
        return View(users);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(User user)
    {
        if (!ModelState.IsValid)
            return View(user);

        user.CreatedAt = DateTime.UtcNow;
        context.Users.Add(user);
        await context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id is null)
            return NotFound();

        var user = await context.Users.FindAsync(id);
        if (user is null)
            return NotFound();

        return View(user);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, User user)
    {
        if (id != user.Id)
            return NotFound();

        if (!ModelState.IsValid)
            return View(user);

        user.UpdatedAt = DateTime.UtcNow;
        context.Users.Update(user);
        await context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id is null)
            return NotFound();

        var user = await context.Users.FindAsync(id);
        if (user is null)
            return NotFound();

        return View(user);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id is null)
            return NotFound();

        var user = await context.Users.FindAsync(id);
        if (user is null)
            return NotFound();

        return View(user);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var user = await context.Users.FindAsync(id);
        if (user is not null)
        {
            context.Users.Remove(user);
            await context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }
}
