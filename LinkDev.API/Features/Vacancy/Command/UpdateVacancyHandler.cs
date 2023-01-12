using LinkDev.API.Exceptions;
using LinkDev.API.Features.Vacancy.Query;
using LinkDev.API.Interface;
using LinkDev.API.Validations;
using MediatR;
using System.Net;

namespace LinkDev.API.Features.Vacancy.Command
{
    public class UpdateVacancyHandler : IRequestHandler<UpdatVacancyQuery, int>
    {
        private readonly IVacancy _repo;

        public UpdateVacancyHandler(IVacancy repo)
        {
            _repo = repo;
        }

        public async Task<int> Handle(UpdatVacancyQuery request, CancellationToken cancellationToken)
        {
            if (request.model.Id <= 0) throw new ValidationException("Id is required", (int)HttpStatusCode.BadRequest);

            VacancyValidation validationRules = new VacancyValidation();
            var result = await validationRules.ValidateAsync(request.model);
            if (result.Errors.Any())
            {
                var Errors = result.Errors.Select(x => x.ErrorMessage).ToList();
                throw new ValidationException(Errors, (int)HttpStatusCode.BadRequest);
            }

            return await _repo.Update(request.model);
        }
    }
}
