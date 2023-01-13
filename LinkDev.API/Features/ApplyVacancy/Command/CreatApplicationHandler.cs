using LinkDev.API.Exceptions;
using LinkDev.API.Features.ApplyVacancy.Query;
using LinkDev.API.Interface;
using LinkDev.API.Validations;
using MediatR;
using System.Net;

namespace LinkDev.API.Features.ApplyVacancy.Command
{
    public sealed class CreatApplicationHandler : IRequestHandler<CreatApplicationQuery, int>
    {
        private readonly IApplyVacancy _repo;
        public CreatApplicationHandler(IApplyVacancy repo)
        {
            _repo = repo;
        }

        public async Task<int> Handle(CreatApplicationQuery request, CancellationToken cancellationToken)
        {
            AppliedVacancyValidation validationRules = new AppliedVacancyValidation();
            var result = await validationRules.ValidateAsync(request.model);
            if (result.Errors.Any())
            {
                var Errors = result.Errors.Select(x => x.ErrorMessage).ToList();
                throw new ValidationException(Errors, (int)HttpStatusCode.BadRequest);
            }

            var isDupplicateVacancy = await _repo.ValidateDupplicateApply(request.model);
            if (isDupplicateVacancy)
            {
                throw new ValidationException("You apply this vacancy before", (int)HttpStatusCode.BadRequest);
            }

            var isAllowedBoundaryMaxApplicants = await _repo.CheckMaxApplicants(request.model.VacancyId);
            if (isAllowedBoundaryMaxApplicants)
            {
                throw new ValidationException("No longer available", (int)HttpStatusCode.BadRequest);
            }

            return await _repo.Insert(request.model);
        }
    }
}
