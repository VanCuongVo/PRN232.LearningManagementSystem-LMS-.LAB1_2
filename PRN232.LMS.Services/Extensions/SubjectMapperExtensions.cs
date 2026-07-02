using PRN232.LMS.Repositories.Entities;
using PRN232.LMS.Repositories.ResponseModel;

namespace PRN232.LMS.Services.Extensions
{
    public static class SubjectMapperExtensions
    {
        public static SubjectResponse ToSubjectResponse(this Subject subjects)
        {
            return new SubjectResponse
            {
                SubjectId = subjects.Subjectid,
                SubjectName = subjects.Subjectname,
                SubjectCode = subjects.Subjectcode,
                Credit = subjects.Credit
            };
        }

        public static IEnumerable<SubjectResponse> ToSubjectResponseList(this IEnumerable<Subject> subjects)
        {
            return subjects.Select(x => x.ToSubjectResponse()).ToList();
        }
    }
}