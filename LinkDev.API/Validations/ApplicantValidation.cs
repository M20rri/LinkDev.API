using FluentValidation;
using LinkDev.API.Dto;

namespace LinkDev.API.Validations
{
    public class ApplicantValidation : AbstractValidator<ApplicantDto>
    {
        public ApplicantValidation()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage(x => "Applicant Name is required");
            RuleFor(x => x.Email).Cascade(CascadeMode.Stop).NotNull().NotEmpty().WithMessage(x => "Email is required")
                .EmailAddress().WithMessage(x => "Invalid Email Format");
            RuleFor(x => x.Mobile).NotNull().NotEmpty().WithMessage(x => "Mobile is required");

        }
    }
}
