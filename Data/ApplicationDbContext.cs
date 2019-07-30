using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RRHH.Data;

namespace RRHH.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<RRHH.Data.jobPosting> jobPosting { get; set; }
        public DbSet<RRHH.Data.applicant1> applicant1 { get; set; }
    }
}
