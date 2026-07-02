using FluentValidation;
using PRN232.LMS.Models.RequestModel;

namespace PRN232.LMS.Services.Validators.CourseValidators
{
    public class UpdateCourseRequestValidator : AbstractValidator<UpdateCourseRequest>
    {
        public UpdateCourseRequestValidator()
        {
            RuleFor(x => x.CourseName)
              .NotEmpty()
              .WithMessage("CourseName is required")
              .MinimumLength(2)
              .MaximumLength(100);

            RuleFor(x => x.SemesterId)
                .GreaterThan(0)
                .WithMessage(
                    "SemesterId must be greater than 0");

            RuleFor(x => x.Coursecode)
                .NotEmpty()
                .Matches(@"^[A-Z]{3}\d{3}$")
                .WithMessage(
                    "CourseCode must be like PRN232");
        }
    }
}