using PRN232.LMS.Repositories.Repositories;

namespace PRN232.LMS.Repositories.IRepositories
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
        IStudentRepositories Students { get; }

        ISubjectRepositories Subjects { get; }

        ISemestersRepositories Semesters { get; }

        ICourseRepository Courses { get; }

        IEnrollmentRepositories Enrollments { get; }

        IUserRepositories Users { get; }
        IRefreshTokenRepositories RefreshTokens { get; }
    }
}
