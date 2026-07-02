using System.ComponentModel.DataAnnotations;

namespace PRN232.LMS.Models.RequestModel
{
    public class UpdateSubjectRequest
    {
        [Required(ErrorMessage = "SubjectCode is required")]
        [RegularExpression("^[A-Z0-9-]+$", ErrorMessage = "SubjectCode must be uppercase alphanumeric")]
        public string SubjectCode { get; set; } = null!;

        [Required(ErrorMessage = "SubjectName is required")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "SubjectName must be between 2 and 200 characters")]
        public string SubjectName { get; set; } = null!;

        [Range(1, 10, ErrorMessage = "Credit must be between 1 and 10")]
        public int Credit { get; set; }
    }
}