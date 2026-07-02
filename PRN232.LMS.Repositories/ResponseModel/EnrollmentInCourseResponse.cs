using PRN232.LMS.Models.Enum;

namespace PRN232.LMS.Models.ResponseModel
{
    public class EnrollmentInCourseResponse
    {
        public int EnrollmentId { get; set; }

        public DateTime EnrollDate { get; set; }

        public EnrollmentStatus Status { get; set; }

    }
}