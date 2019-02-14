using Microsoft.EntityFrameworkCore;

namespace WebAPI1
{
    public class DockerTestContext : DbContext
    {
        public DbSet<DockerTestTable> DockerTestTable { get; set; }
        public DockerTestContext(DbContextOptions<DockerTestContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
