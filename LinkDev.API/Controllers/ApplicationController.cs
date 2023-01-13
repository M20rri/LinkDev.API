using CoreApiResponse;
using LinkDev.API.Dto;
using LinkDev.API.Features.Applicant.Query;
using LinkDev.API.Features.ApplyVacancy.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LinkDev.API.Controllers
{
    [Route("api/application")]
    [ApiController]
    public class ApplicationController : BaseController
    {
        private readonly ISender _iSender;
        public ApplicationController(ISender iSender)
        {
            _iSender = iSender;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync(AppliedVacancyDto model)
        {
            var item = await _iSender.Send(new CreatApplicationQuery(model));
            return CustomResult("Saved Sucesfully", item, HttpStatusCode.OK);
        }

        [HttpGet("applicanter-per-vacancy/{id}")]
        public async Task<IActionResult> GetApplicantsForVacancy(int id)
        {
            var result = await _iSender.Send(new GetApplicantsPerVacancyQuery(id));
            return CustomResult(result, HttpStatusCode.OK);
        }
    }
}
