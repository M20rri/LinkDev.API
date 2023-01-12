using LinkDev.API.Exceptions;
using LinkDev.API.Features.Applicant.Query;
using LinkDev.API.Interface;
using LinkDev.API.Validations;
using MediatR;
using System.Net;

namespace LinkDev.API.Features.Applicant.Command
{
    public sealed class CreatApplicatantHandler : IRequestHandler<CreatApplicantQuery, int>
    {
        private readonly IApplicant _repo;
        public CreatApplicatantHandler(IApplicant repo)
        {
            _repo = repo;
        }

        public async Task<int> Handle(CreatApplicantQuery request, CancellationToken cancellationToken)
        {
            ApplicantValidation validationRules = new ApplicantValidation();
            var result = await validationRules.ValidateAsync(request.model);
            if (result.Errors.Any())
            {
                var Errors = result.Errors.Select(x => x.ErrorMessage).ToList();
                throw new ValidationException(Errors, (int)HttpStatusCode.BadRequest);
            }

            var isDupplicateEmail = await _repo.ValidateDupplicateEmail(request.model.Email);
            if (isDupplicateEmail)
            {
                throw new ValidationException("Email exist before", (int)HttpStatusCode.BadRequest);
            }

            var isDupplicateMobile = await _repo.ValidateDupplicateMobile(request.model.Mobile);
            if (isDupplicateMobile)
            {
                throw new ValidationException("Mobile exist before", (int)HttpStatusCode.BadRequest);
            }

            return await _repo.Insert(request.model);
        }
    }
}
