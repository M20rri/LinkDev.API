using AutoMapper;
using LinkDev.API.Context;
using LinkDev.API.Dto;
using LinkDev.API.Exceptions;
using LinkDev.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace LinkDev.API.Interface.Implementation
{
    public class VacancyRepository : IVacancy
    {
        private readonly IMapper _mapper;
        private readonly LinkDevContext _ctx;
        private readonly IConfiguration _cfg;
        public VacancyRepository(IMapper mapper, LinkDevContext ctx, IConfiguration cfg)
        {
            _mapper = mapper;
            _ctx = ctx;
            _cfg = cfg;
        }

        public async Task<int> Delete(int id)
        {
            var item = await _ctx.Vacancies.FindAsync(id) ??
                               throw new ValidationException("Vacancy is not exist", (int)HttpStatusCode.BadRequest);

            _ctx.Vacancies.Remove(item);
            await _ctx.SaveChangesAsync();

            return item.Id;
        }

        public async Task<VacancyPagination> GetAll(QueryParameters queryParameters)
        {
            var items = await _ctx.Vacancies.ToListAsync();

            if (!string.IsNullOrWhiteSpace(queryParameters.Name))
            {
                items = items.Where(a => a.Name.Contains(queryParameters.Name, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            int pageSize = _cfg.GetValue<int>("pageSize");
            int totalNumber = (queryParameters.Page - 1) * pageSize;

            var vacancies = items.Skip(totalNumber).Take(pageSize);
            var totalCounts = await _ctx.Vacancies.CountAsync();

            VacancyPagination vacancyPagination = new()
            {
                vacancies = _mapper.Map<List<VacancyDto>>(vacancies),
                totalCount = totalCounts
            };

            return vacancyPagination;
        }

        public async Task<VacancyDto> GetById(int id)
        {
            var item = await _ctx.Vacancies.FindAsync(id) ??
                              throw new ValidationException("Vacancy is not exist", (int)HttpStatusCode.BadRequest);

            return _mapper.Map<VacancyDto>(item);
        }

        public async Task<int> Insert(VacancyDto model)
        {
            var item = _mapper.Map<Vacancy>(model);
            await _ctx.Vacancies.AddAsync(item);
            await _ctx.SaveChangesAsync();

            return item.Id;
        }

        public async Task<int> Update(VacancyDto model)
        {
            var item = await _ctx.Vacancies.FindAsync(model.Id) ??
                              throw new ValidationException("Vacancy is not exist", (int)HttpStatusCode.BadRequest);

            item.Name = model.Name;
            item.Description = model.Description;
            item.Responsibilities = model.Responsibilities;
            item.Skills = model.Skills;
            item.Category = model.Category;
            item.ValidFrom = model.ValidFrom;
            item.ValidTo = model.ValidTo;
            item.MaxApplicants = model.MaxApplicants;
            await _ctx.SaveChangesAsync();

            return item.Id;
        }

        public async Task<bool> ValidateDupplicateTitle(string title)
        {
            return await _ctx.Vacancies.AnyAsync(a => a.Name == title);
        }
    }
}
