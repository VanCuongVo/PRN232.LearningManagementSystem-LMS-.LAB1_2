using FluentValidation;
using PRN232.LMS.Models.RequestModel;

namespace PRN232.LMS.Services.Validators.SubjectValidators.Command
{
    public class CreateSubjectRequestValidator : AbstractValidator<CreateSubjectRequest>
    {
        public CreateSubjectRequestValidator()
        {
            RuleFor(x => x.Credit).InclusiveBetween(1, 10);
            RuleFor(x => x.SubjectName).NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.SubjectCode).Matches(@"^[A-Z]{3}\d{3}$").WithMessage("SubjectCode must be like PRN232");
        }
    }
}