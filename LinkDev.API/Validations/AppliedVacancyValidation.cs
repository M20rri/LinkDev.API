using FluentValidation;
using LinkDev.API.Dto;

namespace LinkDev.API.Validations
{
    public class AppliedVacancyValidation : AbstractValidator<AppliedVacancyDto>
    {
        public AppliedVacancyValidation()
        {
            RuleFor(x => x.VacancyId).GreaterThan(0).WithMessage(x => "Please select vacancy");
            RuleFor(x => x.ApplicantId).GreaterThan(0).WithMessage(x => "please verify your account to apply");

        }
    }
}
