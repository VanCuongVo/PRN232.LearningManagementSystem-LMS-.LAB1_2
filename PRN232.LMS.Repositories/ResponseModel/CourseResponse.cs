namespace PRN232.LMS.Models.ResponseModel
{
    public class CourseResponse
    {
        public int CourseId { get; set; }

        public string CourseName { get; set; } = string.Empty;

        public int SemesterId { get; set; }
        public string SemesterName { get; set; } = string.Empty;

        public List<EnrollmentInCourseResponse> Enrollments { get; set; }
       = new();
        public List<StudentInCourseResponse> Students { get; set; }
            = new();
    }
}