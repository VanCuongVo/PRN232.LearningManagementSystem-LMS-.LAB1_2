using PRN232.LMS.Repositories.Entities;
using PRN232.LMS.Repositories.Data;
using PRN232.LMS.Repositories.Repositories;

namespace PRN232.LMS.Repositories.IRepositories
{
    public class CourseRepository : GenericRepositories<Course>, ICourseRepository
    {
        public CourseRepository(LmsdbContext lmsdbContext) : base(lmsdbContext)
        {
        }
    }
}