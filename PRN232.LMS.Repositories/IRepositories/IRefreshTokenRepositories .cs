using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PRN232.LMS.Models.Entities;

namespace PRN232.LMS.Repositories.IRepositories
{
    public interface IRefreshTokenRepositories
    {
        Task<RefreshToken?> GetByTokenAsync(string token);
        Task AddAsync(RefreshToken token);
    }
}