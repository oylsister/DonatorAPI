namespace DonatorAPI.Data.Repositories.IRepository;

using DonatorAPI.Common.Models;
using DonatorAPI.Data.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

public interface IUserRepository
{
    Task AddUserAsync(User user);
    Task DeleteUserAsync(Guid userId);
    Task<PaginationResponse<User>> GetAllUsersAsync(PaginationRequest pagination, CancellationToken cancellationToken = default);
    Task<User?> GetUserByIdAsync(Guid userId);
    Task UpdateUserAsync(User user);
}