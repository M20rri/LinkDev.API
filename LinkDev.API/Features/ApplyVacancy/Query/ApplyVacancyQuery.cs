using LinkDev.API.Dto;
using MediatR;

namespace LinkDev.API.Features.ApplyVacancy.Query
{
    public record CreatApplicationQuery(AppliedVacancyDto model) : IRequest<int>;
    public record GetApplicantsPerVacancyQuery(int vacancyId) : IRequest<List<ApplicantDto>>;
}
