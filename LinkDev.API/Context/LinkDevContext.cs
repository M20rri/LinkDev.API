using Microsoft.EntityFrameworkCore;
using LinkDev.API.Models;

namespace LinkDev.API.Context
{
    public partial class LinkDevContext : DbContext
    {
        public LinkDevContext(DbContextOptions<LinkDevContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Applicant> Applicants { get; set; }
        public virtual DbSet<AppliedVacancy> AppliedVacancies { get; set; }
        public virtual DbSet<Vacancy> Vacancies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppliedVacancy>(entity =>
            {
                entity.HasOne(d => d.Applicant)
                    .WithMany(p => p.AppliedVacancies)
                    .HasForeignKey(d => d.ApplicantId)
                    .HasConstraintName("FK_AppliedVacancy_Applicant");

                entity.HasOne(d => d.Vacancy)
                    .WithMany(p => p.AppliedVacancies)
                    .HasForeignKey(d => d.VacancyId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_AppliedVacancy_Vacancy");

            });

        }
    }
}