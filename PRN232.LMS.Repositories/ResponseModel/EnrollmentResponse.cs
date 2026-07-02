
using PRN232.LMS.Models.Enum;

namespace PRN232.LMS.Models.ResponseModel
{
    public class EnrollmentResponse
    {
        public int EnrollmentId { get; set; }

        public DateTime EnrollDate { get; set; }

        public EnrollmentStatus Status { get; set; }

        public StudentInEnrollmentResponse? Student { get; set; }

        public CourseInEnrollmentResponse? Course { get; set; }
    }
}