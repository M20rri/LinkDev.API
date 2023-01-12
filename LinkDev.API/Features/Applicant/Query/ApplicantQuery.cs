using LinkDev.API.Dto;
using MediatR;

namespace LinkDev.API.Features.Applicant.Query
{
    public record CreatApplicantQuery(ApplicantDto model) : IRequest<int>;
    public record GetSinglApplicantQuery(int id) : IRequest<ApplicantDto>;
}
