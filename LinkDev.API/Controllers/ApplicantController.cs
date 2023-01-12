using CoreApiResponse;
using LinkDev.API.Dto;
using LinkDev.API.Features.Applicant.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LinkDev.API.Controllers
{
    [Route("api/applicant")]
    [ApiController]
    public class ApplicantController : BaseController
    {
        private readonly ISender _iSender;
        public ApplicantController(ISender iSender)
        {
            _iSender = iSender;
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _iSender.Send(new GetSinglApplicantQuery(id));
            return CustomResult(result, HttpStatusCode.OK);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync(ApplicantDto model)
        {
            var item = await _iSender.Send(new CreatApplicantQuery(model));
            return CustomResult("Saved Sucesfully", item, HttpStatusCode.OK);
        }
    }
}
