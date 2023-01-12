using LinkDev.API.Dto;

namespace LinkDev.API.Interface
{
    public interface IApplyVacancy
    {
        Task<int> Insert(AppliedVacancyDto model);
        Task<bool> ValidateDupplicateApply(AppliedVacancyDto model);
    }
}
