using PRN232.LMS.Repositories.Entities;
using PRN232.LMS.Repositories.Data;
using PRN232.LMS.Repositories.Repositories;

namespace PRN232.LMS.Repositories.IRepositories
{
    public class EnrollmentRepositories : GenericRepositories<Enrollment>, IEnrollmentRepositories
    {
        public EnrollmentRepositories(LmsdbContext lmsdbContext) : base(lmsdbContext)
        {
        }
    }
}