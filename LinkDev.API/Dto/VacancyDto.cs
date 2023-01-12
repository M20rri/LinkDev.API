namespace LinkDev.API.Dto
{
    public class VacancyDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Responsibilities { get; set; }
        public string? Skills { get; set; }
        public string? Category { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public int? MaxApplicants { get; set; }
    }

    public class VacancyPagination
    {
        public List<VacancyDto> vacancies { get; set; }
        public int totalCount { get; set; }
    }
}
