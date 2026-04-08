using Microsoft.EntityFrameworkCore;
using DwadTestRp.Models;

namespace DwadTestRp.Data;

public class UserRepository(ApplicationDbContext context) : IUserRepository
{
    public async Task<List<User>> GetAllAsync()
    {
        return await context.Users.OrderByDescending(u => u.CreatedAt).ToListAsync();
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await context.Users.FindAsync(id);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task AddAsync(User user)
    {
        user.CreatedAt = DateTime.UtcNow;
        context.Users.Add(user);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(User user)
    {
        user.UpdatedAt = DateTime.UtcNow;
        context.Users.Update(user);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var user = await context.Users.FindAsync(id);
        if (user is not null)
        {
            context.Users.Remove(user);
            await context.SaveChangesAsync();
        }
    }
}
