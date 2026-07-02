using System.ComponentModel.DataAnnotations;
using PRN232.LMS.Services.Custom;

namespace PRN232.LMS.Repositories.RequestModel
{
    public class CreateStudentRequest
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
        [StudentCode(ErrorMessage = "Student code must be SE/CE/AI + 5 digits (ex: SE19886)")]
        public string Studentcode { get; set; } = null!;
    }
}