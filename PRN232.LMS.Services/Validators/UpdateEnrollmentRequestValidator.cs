using FluentValidation;
using PRN232.LMS.Repositories.RequestModel;

namespace PRN232.LMS.Services.Validators
{
    public class UpdateEnrollmentRequestValidator : AbstractValidator<UpdateEnrollmentRequest>
    {
        public UpdateEnrollmentRequestValidator()
        {
            RuleFor(x => x.StudentId)
                .NotEmpty().WithMessage("StudentId is required")
                .GreaterThan(0).WithMessage("StudentId must be a positive integer");

            RuleFor(x => x.CourseId)
                .NotEmpty().WithMessage("CourseId is required")
                .GreaterThan(0).WithMessage("CourseId must be a positive integer");

            RuleFor(x => x.EnrollDate)
                .NotEmpty().WithMessage("EnrollDate is required");

            RuleFor(x => x.Status)
                .IsInEnum().WithMessage("Status must be a valid enrollment status");
        }
    }
}
