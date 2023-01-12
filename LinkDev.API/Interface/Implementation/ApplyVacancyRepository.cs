using AutoMapper;
using LinkDev.API.Context;
using LinkDev.API.Dto;
using LinkDev.API.Models;
using Microsoft.EntityFrameworkCore;

namespace LinkDev.API.Interface.Implementation
{
    public class ApplyVacancyRepository : IApplyVacancy
    {
        private readonly IMapper _mapper;
        private readonly LinkDevContext _ctx;
        public ApplyVacancyRepository(IMapper mapper, LinkDevContext ctx)
        {
            _mapper = mapper;
            _ctx = ctx;
        }

        public async Task<int> Insert(AppliedVacancyDto model)
        {
            var item = _mapper.Map<AppliedVacancy>(model);
            await _ctx.AppliedVacancies.AddAsync(item);
            await _ctx.SaveChangesAsync();

            return item.Id;
        }

        public async Task<bool> ValidateDupplicateApply(AppliedVacancyDto model)
        {
            return await _ctx.AppliedVacancies.AnyAsync(a => a.ApplicantId == model.ApplicantId && a.VacancyId == model.VacancyId);
        }
    }
}
