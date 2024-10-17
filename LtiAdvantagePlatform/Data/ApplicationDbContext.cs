using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LtiAdvantagePlatform.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<AdvantagePlatformUser>(options)
{
    public DbSet<Course> Courses { get; set; }
    
    public DbSet<GradebookColumn> GradebookColumns { get; set; }
    
    public DbSet<GradebookRow> GradebookRows { get; set; }
    
    public DbSet<Person> People { get; set; }
    
    public DbSet<Platform> Platforms { get; set; }
    
    public DbSet<ResourceLink> ResourceLinks { get; set; }
    
    public DbSet<Tool> Tools { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<GradebookColumn>().HasMany(c => c.Scores).WithOne()
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<ResourceLink>().HasMany<GradebookColumn>().WithOne(g => g.ResourceLink)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Tool>().HasMany<ResourceLink>().WithOne(l => l.Tool)
            .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(builder);
    }
}