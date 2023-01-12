using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinkDev.API.Models
{
    [Table("Applicant")]
    public partial class Applicant
    {
        public Applicant()
        {
            AppliedVacancies = new HashSet<AppliedVacancy>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(50)]
        public string Mobile { get; set; }

        [InverseProperty("Applicant")]
        public virtual ICollection<AppliedVacancy> AppliedVacancies { get; set; }
    }
}