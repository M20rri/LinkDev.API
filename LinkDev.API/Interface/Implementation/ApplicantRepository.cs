using AutoMapper;
using LinkDev.API.Context;
using LinkDev.API.Dto;
using LinkDev.API.Exceptions;
using LinkDev.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace LinkDev.API.Interface.Implementation
{
    public class ApplicantRepository : IApplicant
    {
        private readonly IMapper _mapper;
        private readonly LinkDevContext _ctx;
        public ApplicantRepository(IMapper mapper, LinkDevContext ctx)
        {
            _mapper = mapper;
            _ctx = ctx;
        }

        public async Task<ApplicantDto> GetApplicanitByEmail(string email)
        {
            var item = await _ctx.Applicants.FirstOrDefaultAsync(a => a.Email == email) ??
                             throw new ValidationException("Applicant is not exist", (int)HttpStatusCode.BadRequest);

            return _mapper.Map<ApplicantDto>(item);
        }

        public async Task<ApplicantDto> GetById(int id)
        {
            var item = await _ctx.Applicants.FindAsync(id) ??
                             throw new ValidationException("Applicant is not exist", (int)HttpStatusCode.BadRequest);

            return _mapper.Map<ApplicantDto>(item);
        }

        public async Task<int> Insert(ApplicantDto model)
        {
            var item = _mapper.Map<Applicant>(model);
            await _ctx.Applicants.AddAsync(item);
            await _ctx.SaveChangesAsync();

            return item.Id;
        }

        public async Task<bool> ValidateDupplicateEmail(string email)
        {
            return await _ctx.Applicants.AnyAsync(a => a.Email == email);
        }

        public async Task<bool> ValidateDupplicateMobile(string mobile)
        {
            return await _ctx.Applicants.AnyAsync(a => a.Mobile == mobile);
        }
    }
}
