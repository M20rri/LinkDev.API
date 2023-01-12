using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinkDev.API.Models
{
    [Table("Vacancy")]
    public partial class Vacancy
    {
        public Vacancy()
        {
            AppliedVacancies = new HashSet<AppliedVacancy>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Responsibilities { get; set; }
        public string Skills { get; set; }
        public string Category { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ValidFrom { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ValidTo { get; set; }
        public int? MaxApplicants { get; set; }

        [InverseProperty("Vacancy")]
        public virtual ICollection<AppliedVacancy> AppliedVacancies { get; set; }
    }
}