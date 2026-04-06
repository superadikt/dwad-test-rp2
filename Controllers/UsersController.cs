using Microsoft.AspNetCore.Mvc;
using DwadTestRp.Data;
using DwadTestRp.Models;

namespace DwadTestRp.Controllers;

public class UsersController(IUserRepository userRepository) : Controller
{
    public async Task<IActionResult> Index()
    {
        var users = await userRepository.GetAllAsync();
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

        await userRepository.AddAsync(user);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id is null)
            return NotFound();

        var user = await userRepository.GetByIdAsync(id.Value);
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

        await userRepository.UpdateAsync(user);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id is null)
            return NotFound();

        var user = await userRepository.GetByIdAsync(id.Value);
        if (user is null)
            return NotFound();

        return View(user);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id is null)
            return NotFound();

        var user = await userRepository.GetByIdAsync(id.Value);
        if (user is null)
            return NotFound();

        return View(user);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await userRepository.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
