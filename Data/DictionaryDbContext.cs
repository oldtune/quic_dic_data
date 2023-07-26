using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data;
public class DictionaryDbContext : DbContext
{
    public DictionaryDbContext(DbContextOptions<DictionaryDbContext> options) : base(options)
    {
    }

    public DbSet<WordRecord> Words { set; get; }
    public DbSet<WordType> WordTypes { set; get; }
    public DbSet<WordTypeLink> WordTypeLinks { set; get; }
    public DbSet<WordMeaning> WordMeanings { set; get; }
    public DbSet<Example> Examples { set; get; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WordRecord>().HasKey(x => x.Word);
        modelBuilder.Entity<WordRecord>().Property(x => x.Word).HasMaxLength(128).HasColumnType("nvarchar");
        modelBuilder.Entity<WordRecord>().Property(x => x.EnUkPronounce).HasMaxLength(20).HasColumnType("nvarchar");
        modelBuilder.Entity<WordRecord>().Property(x => x.EnUsPronounce).HasMaxLength(20).HasColumnType("nvarchar");
        modelBuilder.Entity<WordRecord>().Property(x => x.ViPronounce).HasMaxLength(20).HasColumnType("nvarchar");

        modelBuilder.Entity<WordType>().HasKey(x => x.Id);
        modelBuilder.Entity<WordType>().Property(x => x.En).HasMaxLength(40).HasColumnType("nvarchar");
        modelBuilder.Entity<WordType>().Property(x => x.Vi).HasMaxLength(40).HasColumnType("nvarchar");

        modelBuilder.Entity<WordTypeLink>().HasKey(x => x.Id);
        modelBuilder.Entity<WordTypeLink>().Property(x => x.Word).HasMaxLength(128).HasColumnType("nvarchar");

        modelBuilder.Entity<WordMeaning>().HasKey(x => x.Id);
        modelBuilder.Entity<WordMeaning>().Property(x => x.EnMeaning).HasColumnType("nvarchar").HasMaxLength(256);
        modelBuilder.Entity<WordMeaning>().Property(x => x.ViMeaning).HasColumnType("nvarchar").HasMaxLength(256);

        modelBuilder.Entity<Example>().HasKey(x => x.Id);
        modelBuilder.Entity<Example>().Property(x => x.EnExample).HasColumnType("nvarchar").HasMaxLength(256);
        modelBuilder.Entity<Example>().Property(x => x.ViMeaning).HasColumnType("nvarchar").HasMaxLength(256);

        base.OnModelCreating(modelBuilder);
    }
}
