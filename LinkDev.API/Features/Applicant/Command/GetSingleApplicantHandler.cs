using LinkDev.API.Dto;
using LinkDev.API.Exceptions;
using LinkDev.API.Features.Applicant.Query;
using LinkDev.API.Interface;
using MediatR;
using System.Net;

namespace LinkDev.API.Features.Applicant.Command
{
    public class GetSingleApplicantHandler : IRequestHandler<GetSinglApplicantQuery, ApplicantDto>
    {
        private readonly IApplicant _repo;
        public GetSingleApplicantHandler(IApplicant repo)
        {
            _repo = repo;
        }

        public async Task<ApplicantDto> Handle(GetSinglApplicantQuery request, CancellationToken cancellationToken)
        {
            if (request.id <= 0) throw new ValidationException("Id is required", (int)HttpStatusCode.BadRequest);

            return await _repo.GetById(request.id);
        }
    }
}
