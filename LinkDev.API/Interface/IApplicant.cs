using LinkDev.API.Dto;

namespace LinkDev.API.Interface
{
    public interface IApplicant
    {
        Task<int> Insert(ApplicantDto model);
        Task<ApplicantDto> GetById(int id);
        Task<ApplicantDto> GetApplicanitByEmail(string email);
        Task<bool> ValidateDupplicateEmail(string email);
        Task<bool> ValidateDupplicateMobile(string mobile);
    }
}
