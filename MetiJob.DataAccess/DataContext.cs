using CwkSocial.Dal.Extensions;
using MetiJob.Domain.Aggregates.IdentityAggregates;
using MetiJob.Domain.Aggregates.JobsAggregates;
using MetiJob.Domain.Aggregates.ResumeAggregates;
using MetiJob.Domain.Enums;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MetiJob.DataAccess
{
    public class DataContext: IdentityDbContext<ApplicationUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<JobCategory> JobCategories{ get; set; }
        public DbSet<Domain.Aggregates.ResumeAggregates.Language> Languages{ get; set; }
        public DbSet<WorkExperience> WorkExperiences{ get; set; }
        public DbSet<EducationalRecord> EducationalRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyAllConfigurations();
            base.OnModelCreating(builder);
        }
    }
}
