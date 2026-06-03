using PRN232.LMS.Models.Entities;
using PRN232.LMS.Models.ResponseModel;

namespace PRN232.LMS.Services.Extensions
{
    public static class CourseMapperExtension
    {
        public static CourseEnrollmentResponse ToCourseEnrollmentResponse(this Enrollment enrollment)
        {
            return new CourseEnrollmentResponse
            {
                EnrollmentId = enrollment.Enrollmentid,

                EnrollDate = enrollment.Enrolldate,

                Status = enrollment.Status,

                StudentId = enrollment.Studentid,

                CourseId = enrollment.Courseid,

                Student = enrollment.Student == null
                ? null
                : new StudentInEnrollmentResponse
                {
                    StudentId = enrollment.Student.Studentid,

                    FullName = enrollment.Student.Fullname,

                    Email = enrollment.Student.Email
                }
            };
        }
        public static CourseResponse ToCourseResponse(this Course course)
        {
            return new CourseResponse
            {
                CourseId = course.Courseid,
                CourseName = course.Coursename,
                SemesterId = course.Semester?.Semesterid ?? 0,
                SemesterName = course.Semester?.Semestername ?? string.Empty,
                Enrollments = course.Enrollments?.Select(x => new EnrollmentInCourseResponse
                {
                    EnrollmentId = x.Enrollmentid,
                    EnrollDate = x.Enrolldate,
                    Status = x.Status
                }).ToList() ?? new List<EnrollmentInCourseResponse>(),
                Students = course.Enrollments?.Where(x => x.Student != null).Select(x => new StudentInCourseResponse
                {
                    StudentId = x.Student!.Studentid,
                    FullName = x.Student.Fullname,
                    Email = x.Student.Email
                }).ToList() ?? new List<StudentInCourseResponse>()
            };
        }

        public static List<CourseResponse> ToCourseResponseList(
          this List<Course> courses)
        {
            return courses
                .Select(ToCourseResponse)
                .ToList();
        }
    }
}