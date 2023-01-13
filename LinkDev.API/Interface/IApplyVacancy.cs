using LinkDev.API.Dto;

namespace LinkDev.API.Interface
{
    public interface IApplyVacancy
    {
        Task<int> Insert(AppliedVacancyDto model);
        Task<bool> ValidateDupplicateApply(AppliedVacancyDto model);
        Task<bool> CheckMaxApplicants(int vacancyId);
        Task<List<ApplicantDto>> GetVacancyApplicants(int vacancyId);
    }
}
