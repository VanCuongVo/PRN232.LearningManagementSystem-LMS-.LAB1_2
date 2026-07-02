using System.ComponentModel.DataAnnotations;
using PRN232.LMS.Repositories.Enum;

namespace PRN232.LMS.Repositories.RequestModel
{
    public class UpdateEnrollmentRequest
    {
        [Range(1, int.MaxValue, ErrorMessage = "StudentId must be a positive integer")]
        public int StudentId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "CourseId must be a positive integer")]
        public int CourseId { get; set; }

        public DateTime EnrollDate { get; set; }

        [EnumDataType(typeof(EnrollmentStatus))]
        public EnrollmentStatus Status { get; set; }
    }
}