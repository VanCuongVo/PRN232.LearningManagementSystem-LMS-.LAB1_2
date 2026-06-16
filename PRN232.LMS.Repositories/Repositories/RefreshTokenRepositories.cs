
using Microsoft.EntityFrameworkCore;
using PRN232.LMS.Models.Entities;
using PRN232.LMS.Repositories.Data;
using PRN232.LMS.Repositories.IRepositories;

namespace PRN232.LMS.Repositories.Repositories
{
    public class RefreshTokenRepositories : IRefreshTokenRepositories
    {
        private readonly LmsdbContext _context;

        public RefreshTokenRepositories(LmsdbContext context)
        {
            _context = context;
        }
        public async Task<RefreshToken?> GetByTokenAsync(string token)
        {
            return await _context.RefreshTokens.Include(x => x.User).ThenInclude(u => u.Student).FirstOrDefaultAsync(x => x.Token == token);
        }


        public async Task AddAsync(RefreshToken token)
        {
            await _context.RefreshTokens.AddAsync(token);
        }
    }
}