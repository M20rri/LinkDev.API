using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinkDev.API.Models
{
    [Table("AppliedVacancy")]
    public partial class AppliedVacancy
    {
        [Key]
        public int Id { get; set; }
        public int? ApplicantId { get; set; }
        public int? VacancyId { get; set; }

        [ForeignKey("ApplicantId")]
        [InverseProperty("AppliedVacancies")]
        public virtual Applicant Applicant { get; set; }
        [ForeignKey("VacancyId")]
        [InverseProperty("AppliedVacancies")]
        public virtual Vacancy Vacancy { get; set; }
    }
}