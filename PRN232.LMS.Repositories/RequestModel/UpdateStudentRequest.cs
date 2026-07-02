using System.ComponentModel.DataAnnotations;

namespace PRN232.LMS.Models.RequestModel
{
    public class UpdateStudentRequest
    {
        [Required(ErrorMessage = "FullName is required")]
        public required string FullName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email is not valid")]
        public required string Email { get; set; }

        public DateTime DateOfBirth { get; set; }
        [Required]
        [Range(18, 60)]
        public int Age { get; set; }
        [Required]
        [Phone]
        public string Phonenumber { get; set; } = null!;
        [Required]
        [RegularExpression(@"^[A-Z]{2}\d{5}$", ErrorMessage = "StudentCode must be like SE19886")]
        public string Studentcode { get; set; } = null!;

    }
}