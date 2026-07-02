using PRN232.LMS.Repositories.Entities;
using PRN232.LMS.Repositories.Data;
using PRN232.LMS.Repositories.IRepositories;

namespace PRN232.LMS.Repositories.Repositories
{
    public class SemestersRepositories : GenericRepositories<Semester>, ISemestersRepositories
    {
        public SemestersRepositories(LmsdbContext lmsdbContext) : base(lmsdbContext)
        {
        }
    }
}