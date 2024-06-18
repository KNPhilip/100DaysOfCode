using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Mapster;
using Domain.Models;

namespace DataAccess;

public class UserRepository(DataContext context)
{
    private readonly DataContext _context = context;

    public virtual async Task<List<User>> GetAllUsersAsync()
    {
        return await _context.Users.Include(c => c.Company).ToListAsync() ?? [];
    }

    public virtual async Task<User?> GetUserByIdAsync(int id)
    {
        return await _context.Users.Include(c => c.Company).FirstOrDefaultAsync(u => u.Id == id);
    }

    public virtual async Task<User?> GetUserByEmailAsync(string email)
    {
        return await _context.Users.Include(c => c.Company).FirstOrDefaultAsync(u => u.Email == email);
    }

    public virtual async Task CreateUserAsync(User user)
    {
        await _context.Users.AddAsync(user.Adapt<User>());
        await _context.SaveChangesAsync();
    }

    public virtual async Task UpdateUserByIdAsync(User newUser)
    {
        User? user = await _context.Users.FindAsync(newUser.Id)
            ?? throw new Exception($"User with id {newUser.Id} does not exist.");

        user = newUser.Adapt(user);

        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public virtual async Task DeleteUserByIdAsync(int id)
    {
        User? user = await _context.Users.FindAsync(id)
            ?? throw new Exception($"User with id {id} does not exist.");

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }
}
