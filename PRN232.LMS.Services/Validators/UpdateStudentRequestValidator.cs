using FluentValidation;
using PRN232.LMS.Models.RequestModel;

namespace PRN232.LMS.Services.Validators
{
    public class UpdateStudentRequestValidator : AbstractValidator<UpdateStudentRequest>
    {
        public UpdateStudentRequestValidator()
        {
            RuleFor(x => x.FullName).NotEmpty().NotNull().MaximumLength(100).MinimumLength(3);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Age).InclusiveBetween(18, 60);
            RuleFor(x => x.Studentcode).Matches(@"^[A-Z]{2}\d{5}$").WithMessage("StudentCode must be like SE19886");
            RuleFor(x => x.Phonenumber).NotEmpty().Matches(@"^(0|\+84)[0-9]{9}$").WithMessage("Phone number is invalid");
        }
    }
}