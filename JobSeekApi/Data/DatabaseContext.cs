using Microsoft.EntityFrameworkCore;

namespace JobSeekApi.Data;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions options) : base(options) { }
    public DbSet<JobDetails> JobDetails { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)    {
        JobDetails details1 = new JobDetails { Name = "Developer", Contents="A C# job...."  };
        modelBuilder.Entity<JobDetails>().HasData(new Data.JobDetails[] { details1 });
    }
}
