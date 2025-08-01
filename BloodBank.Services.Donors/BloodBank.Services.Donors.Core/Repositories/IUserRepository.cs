using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodBank.Services.Donors.Core.Entities;

namespace BloodBank.Services.Donors.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(Guid id);
        Task<Guid> AddAsync(User donor);
        Task UpdateAsync(User donor);
        Task<User> GetUserByEmailAndPasswordAsync(string email, string password);
        Task<bool> UserExistsAsync(string userId);
    }
}