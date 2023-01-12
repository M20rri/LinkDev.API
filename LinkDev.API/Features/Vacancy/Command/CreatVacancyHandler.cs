using LinkDev.API.Exceptions;
using LinkDev.API.Features.Vacancy.Query;
using LinkDev.API.Interface;
using LinkDev.API.Validations;
using MediatR;
using System.Net;

namespace LinkDev.API.Features.Vacancy.Command
{
    public sealed class CreatVacancyHandler : IRequestHandler<CreatVacancyQuery, int>
    {
        private readonly IVacancy _repo;

        public CreatVacancyHandler(IVacancy repo)
        {
            _repo = repo;
        }

        public async Task<int> Handle(CreatVacancyQuery request, CancellationToken cancellationToken)
        {
            VacancyValidation validationRules = new VacancyValidation();
            var result = await validationRules.ValidateAsync(request.model);
            if (result.Errors.Any())
            {
                var Errors = result.Errors.Select(x => x.ErrorMessage).ToList();
                throw new ValidationException(Errors, (int)HttpStatusCode.BadRequest);
            }

            var isDupplicateVacancy = await _repo.ValidateDupplicateTitle(request.model.Name);
            if (isDupplicateVacancy)
            {
                throw new ValidationException("Dupplicated Vacancy", (int)HttpStatusCode.BadRequest);
            }

            return await _repo.Insert(request.model);
        }
    }
}
