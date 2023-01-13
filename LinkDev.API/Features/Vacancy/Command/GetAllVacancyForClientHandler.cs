using LinkDev.API.Dto;
using LinkDev.API.Features.Vacancy.Query;
using LinkDev.API.Interface;
using MediatR;

namespace LinkDev.API.Features.Vacancy.Command
{
    public sealed class GetAllVacancyForClientHandler : IRequestHandler<GetAllVacancyForClientQuery, List<VacancyDto>>
    {
        private readonly IVacancy _repo;
        public GetAllVacancyForClientHandler(IVacancy repo)
        {
            _repo = repo;
        }

        public async Task<List<VacancyDto>> Handle(GetAllVacancyForClientQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetAll();
        }
    }
}
