using PRN232.LMS.Models.Entities;

namespace PRN232.LMS.Repositories.IRepositories
{
    public interface IUserRepositories : IGenericRepositories<User>
    {
        Task<User?> GetByUsernameAsync(string username);
        Task<User?> GetByEmailAsync(string email);
    }
}