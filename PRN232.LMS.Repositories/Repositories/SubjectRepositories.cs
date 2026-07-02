using PRN232.LMS.Repositories.Entities;
using PRN232.LMS.Repositories.Data;
using PRN232.LMS.Repositories.IRepositories;

namespace PRN232.LMS.Repositories.Repositories
{
    public class SubjectRepositories : GenericRepositories<Subject>, ISubjectRepositories
    {
        public SubjectRepositories(LmsdbContext lmsdbContext) : base(lmsdbContext)
        {
        }
    }
}