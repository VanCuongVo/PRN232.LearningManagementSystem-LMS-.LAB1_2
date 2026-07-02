using PRN232.LMS.Repositories.Enum;

namespace PRN232.LMS.Repositories.ResponseModel
{
    public class CourseEnrollmentResponse
    {
        public int EnrollmentId { get; set; }

        public DateTime EnrollDate { get; set; }

        public EnrollmentStatus Status { get; set; }

        public int StudentId { get; set; }

        public int CourseId { get; set; }

        public StudentInEnrollmentResponse? Student { get; set; }
    }
}