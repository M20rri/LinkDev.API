using LinkDev.API.Dto;
using LinkDev.API.Exceptions;
using LinkDev.API.Features.ApplyVacancy.Query;
using LinkDev.API.Interface;
using MediatR;
using System.Net;

namespace LinkDev.API.Features.ApplyVacancy.Command
{
    public sealed class GetApplicantsPerVacancyHandler : IRequestHandler<GetApplicantsPerVacancyQuery, List<ApplicantDto>>
    {
        private readonly IApplyVacancy _repo;
        public GetApplicantsPerVacancyHandler(IApplyVacancy repo)
        {
            _repo = repo;
        }

        public async Task<List<ApplicantDto>> Handle(GetApplicantsPerVacancyQuery request, CancellationToken cancellationToken)
        {
            if (request.vacancyId <= 0) throw new ValidationException("Id is required", (int)HttpStatusCode.BadRequest);

            return await _repo.GetVacancyApplicants(request.vacancyId);
        }
    }
}
