using LinkDev.API.Dto;

namespace LinkDev.API.Interface
{
    public interface IVacancy
    {
        Task<VacancyPagination> GetAll(QueryParameters queryParameters);
        Task<VacancyDto> GetById(int id);
        Task<int> Insert(VacancyDto model);
        Task<int> Update(VacancyDto model);
        Task<int> Delete(int id);
        Task<bool> ValidateDupplicateTitle(string title);
    }
}
