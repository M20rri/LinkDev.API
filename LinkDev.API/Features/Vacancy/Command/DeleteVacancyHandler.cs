using LinkDev.API.Exceptions;
using LinkDev.API.Features.Vacancy.Query;
using LinkDev.API.Interface;
using MediatR;
using System.Net;

namespace LinkDev.API.Features.Vacancy.Command
{
    public sealed class DeleteVacancyHandler : IRequestHandler<DeletVacancyQuery, int>
    {
        private readonly IVacancy _repo;
        public DeleteVacancyHandler(IVacancy repo)
        {
            _repo = repo;
        }

        public async Task<int> Handle(DeletVacancyQuery request, CancellationToken cancellationToken)
        {
            if (request.id <= 0) throw new ValidationException("Id is required", (int)HttpStatusCode.BadRequest);

            return await _repo.Delete(request.id);
        }
    }
}
