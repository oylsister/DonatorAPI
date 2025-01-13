namespace DonatorAPI.Data.Repositories;

using DonatorAPI.Common.Models;
using DonatorAPI.Data.Entities;
using DonatorAPI.Data.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

public class UserRepository(
    DonatorDataContext donatorDataContext
    ) : IUserRepository
{
    private readonly DonatorDataContext _donatorDataContext = donatorDataContext;

    public async Task<PaginationResponse<User>> GetAllUsersAsync(PaginationRequest pagination, CancellationToken cancellationToken = default)
    {
        var users = await _donatorDataContext.Users
            .AsNoTracking()
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Take(pagination.PageSize)
            .OrderBy(user => user.DateCreated)
            .ToListAsync(cancellationToken);

        var totalRecords = await _donatorDataContext.Users.CountAsync(cancellationToken);

        return new PaginationResponse<User>(users, totalRecords, pagination.PageNumber);
    }

    public async Task<User?> GetUserByIdAsync(Guid userId)
    {
        return await _donatorDataContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == userId);
    }

    public async Task AddUserAsync(User user)
    {
        await _donatorDataContext.Users.AddAsync(user);
        await _donatorDataContext.SaveChangesAsync();
    }

    public async Task UpdateUserAsync(User user)
    {
        _donatorDataContext.Users.Update(user);
        await _donatorDataContext.SaveChangesAsync();
    }

    public async Task DeleteUserAsync(Guid userId)
    {
        var user = await _donatorDataContext.Users.FindAsync(userId);
        if (user is not null)
        {
            _donatorDataContext.Users.Remove(user);
            await _donatorDataContext.SaveChangesAsync();
        }
    }
}
