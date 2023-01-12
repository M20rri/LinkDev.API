using FluentValidation;
using LinkDev.API.Dto;

namespace LinkDev.API.Validations
{
    public class VacancyValidation : AbstractValidator<VacancyDto>
    {
        public VacancyValidation()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage(x => "Vacancy Name is required");
            RuleFor(x => x.ValidFrom).NotNull().NotEmpty().WithMessage(x => "From-Time is required");
            RuleFor(x => x.ValidFrom).LessThan(a => a.ValidTo).WithMessage(x => "From-Time should be less than To-Time ");
            RuleFor(x => x.ValidTo).NotNull().NotEmpty().WithMessage(x => "To-Time is required");
        }
    }
}
