using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PRN232.LMS.Models.Entities;
using PRN232.LMS.Repositories.Data;
using PRN232.LMS.Repositories.IRepositories;

namespace PRN232.LMS.Repositories.Repositories
{
    public class UserRepository : GenericRepositories<User>, IUserRepository
    {
        public UserRepository(LmsdbContext lmsdbContext) : base(lmsdbContext)
        {
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Student.Email == email);
        }



        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Username == username);
        }
    }
}