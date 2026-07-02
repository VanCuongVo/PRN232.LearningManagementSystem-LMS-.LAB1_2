using PRN232.LMS.Models.Enum;

namespace PRN232.LMS.Models.ResponseModel
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