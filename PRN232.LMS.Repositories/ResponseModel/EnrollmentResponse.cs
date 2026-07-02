
using PRN232.LMS.Repositories.Enum;

namespace PRN232.LMS.Repositories.ResponseModel
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