using LinkDev.API.Dto;
using MediatR;

namespace LinkDev.API.Features.Vacancy.Query
{
    public record CreatVacancyQuery(VacancyDto model) : IRequest<int>;
    public record UpdatVacancyQuery(VacancyDto model) : IRequest<int>;
    public record DeletVacancyQuery(int id) : IRequest<int>;
    public record GetSinglVacancyQuery(int id) : IRequest<VacancyDto>;
    public record GetAllVacancyQuery(QueryParameters QueryParameters) : IRequest<VacancyPagination>;
    public record GetAllVacancyForClientQuery() : IRequest<List<VacancyDto>>;
}
