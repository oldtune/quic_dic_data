using Microsoft.EntityFrameworkCore;

namespace Data;
public class PorfolioDbContext : DbContext
{
    public PorfolioDbContext(DbContextOptions<PorfolioDbContext> options) : base(options)
    {

    }

    public DbSet<Profile> Profiles { set; get; }
    public DbSet<BlogPost> BlogPosts { set; get; }
    public DbSet<Platform> Platforms { set; get; }
    public DbSet<Project> Projects { set; get; }
}
