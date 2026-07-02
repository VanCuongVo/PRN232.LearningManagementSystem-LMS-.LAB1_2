using PRN232.LMS.Repositories.Entities;
using PRN232.LMS.Repositories.Data;
using PRN232.LMS.Repositories.IRepositories;

namespace PRN232.LMS.Repositories.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LmsdbContext _context;
        public IStudentRepositories Students { get; }

        public ISubjectRepositories Subjects { get; }

        public ISemestersRepositories Semesters { get; }

        public ICourseRepository Courses { get; }

        public IEnrollmentRepositories Enrollments { get; }

        public IUserRepositories Users { get; }

        public IRefreshTokenRepositories RefreshTokens { get; }

        public UnitOfWork(
            LmsdbContext context,
            IStudentRepositories students,
            ISubjectRepositories subjects,
            ISemestersRepositories semesters,
            ICourseRepository courses,
            IEnrollmentRepositories enrollments,
            IUserRepositories users,
            IRefreshTokenRepositories refreshTokens)
        {
            _context = context;
            Students = students;
            Subjects = subjects;
            Semesters = semesters;
            Courses = courses;
            Enrollments = enrollments;
            Users = users;
            RefreshTokens = refreshTokens;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
