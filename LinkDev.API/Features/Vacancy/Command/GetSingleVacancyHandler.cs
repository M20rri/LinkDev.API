using LinkDev.API.Dto;
using LinkDev.API.Exceptions;
using LinkDev.API.Features.Vacancy.Query;
using LinkDev.API.Interface;
using MediatR;
using System.Net;

namespace LinkDev.API.Features.Vacancy.Command
{
    public sealed class GetSingleVacancyHandler : IRequestHandler<GetSinglVacancyQuery, VacancyDto>
    {
        private readonly IVacancy _repo;
        public GetSingleVacancyHandler(IVacancy repo)
        {
            _repo = repo;
        }

        public async Task<VacancyDto> Handle(GetSinglVacancyQuery request, CancellationToken cancellationToken)
        {
            if (request.id <= 0) throw new ValidationException("Id is required", (int)HttpStatusCode.BadRequest);

            return await _repo.GetById(request.id);
        }
    }
}
