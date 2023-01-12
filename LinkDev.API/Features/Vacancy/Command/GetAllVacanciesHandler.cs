using LinkDev.API.Dto;
using LinkDev.API.Features.Vacancy.Query;
using LinkDev.API.Interface;
using MediatR;

namespace LinkDev.API.Features.Vacancy.Command
{
    public sealed class GetAllVacanciesHandler : IRequestHandler<GetAllVacancyQuery, VacancyPagination>
    {
        private readonly IVacancy _repo;
        public GetAllVacanciesHandler(IVacancy repo)
        {
            _repo = repo;
        }

        public async Task<VacancyPagination> Handle(GetAllVacancyQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetAll(request.QueryParameters);
        }
    }
}
