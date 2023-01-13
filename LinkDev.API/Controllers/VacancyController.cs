using CoreApiResponse;
using LinkDev.API.Dto;
using LinkDev.API.Features.Vacancy.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LinkDev.API.Controllers
{

    [Route("api/vacancy")]
    [ApiController]
    public class VacancyController : BaseController
    {
        private readonly ISender _iSender;
        public VacancyController(ISender iSender)
        {
            _iSender = iSender;
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _iSender.Send(new GetSinglVacancyQuery(id));
            return CustomResult(result, HttpStatusCode.OK);
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllAsync([FromQuery] QueryParameters queryParameters)
        {
            var result = await _iSender.Send(new GetAllVacancyQuery(queryParameters));
            return CustomResult(result, HttpStatusCode.OK);
        }

        [HttpGet("get-all-vacancies")]
        public async Task<IActionResult> GetAllVacanciesAsync()
        {
            var result = await _iSender.Send(new GetAllVacancyForClientQuery());
            return CustomResult(result, HttpStatusCode.OK);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync(VacancyDto model)
        {
            var item = await _iSender.Send(new CreatVacancyQuery(model));
            return CustomResult("Saved Sucesfully", item, HttpStatusCode.OK);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var item = await _iSender.Send(new DeletVacancyQuery(id));
            return CustomResult(item, HttpStatusCode.OK);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync(VacancyDto model)
        {
            var item = await _iSender.Send(new UpdatVacancyQuery(model));
            return CustomResult("Updated Succesfully", item, HttpStatusCode.OK);
        }
    }
}
