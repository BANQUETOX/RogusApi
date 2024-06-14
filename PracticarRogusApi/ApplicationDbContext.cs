using Microsoft.EntityFrameworkCore;

namespace PracticarRogusApi
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Person> Person { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
