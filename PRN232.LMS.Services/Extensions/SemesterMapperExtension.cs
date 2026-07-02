using PRN232.LMS.Repositories.Entities;
using PRN232.LMS.Repositories.ResponseModel;

namespace PRN232.LMS.Services.Extensions
{
    public static class SemesterMapperExtension
    {
        public static SemesterResponse ToSemesterReponse(this Semester semesters)
        {
            return new SemesterResponse
            {
                SemesterId = semesters.Semesterid,
                SemesterName = semesters.Semestername,
                StartDate = semesters.Startdate,
                EndDate = semesters.Enddate,
                Courses = semesters.Courses.Select(x => new CourseResponse
                {
                    CourseId = x.Courseid,
                    CourseName = x.Coursename,
                    SemesterId = x.Semesterid,
                    SemesterName = x.Semester.Semestername,
                    Enrollments = x.Enrollments.Select(x => new EnrollmentInCourseResponse
                    {
                        EnrollmentId = x.Enrollmentid,
                        EnrollDate = x.Enrolldate,
                        Status = x.Status
                    }).ToList(),
                    Students = x.Enrollments.Where(x => x.Student != null).Select(x => new StudentInCourseResponse
                    {
                        StudentId = x.Student!.Studentid,
                        FullName = x.Student.Fullname,
                        Email = x.Student.Email
                    }).ToList()


                }).ToList()
            };
        }

        public static List<SemesterResponse> ToSemesterReponseList(this List<Semester> semesters)
        {
            return semesters.Select(x => x.ToSemesterReponse()).ToList();
        }

    }
}