using Microsoft.EntityFrameworkCore;
using PRN232.LMS.Repositories.Entities;
using PRN232.LMS.Repositories.Data;
using PRN232.LMS.Repositories.IRepositories;

namespace PRN232.LMS.Repositories.Repositories
{
    public class StudentRepositoies : GenericRepositories<Student>, IStudentRepositories
    {
        public StudentRepositoies(LmsdbContext lmsdbContext) : base(lmsdbContext)
        {
        }
    }
}
