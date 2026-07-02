namespace PRN232.LMS.Models.ResponseModel
{
    public class StudentInCourseResponse
    {
        public int StudentId { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
    }
}