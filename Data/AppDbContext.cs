using DigitalEvidenceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitalEvidenceApp.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<MatterModel> Matters => Set<MatterModel>();
    public DbSet<EvidenceModel> Evidence => Set<EvidenceModel>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MatterModel>(entity =>
        {
            entity.ToTable("Matter");
            entity.HasKey(x => x.MatterID);
            entity.Property(x => x.MatterName).HasMaxLength(256);
            entity.Property(x => x.ClientName).HasMaxLength(256);
        });

        modelBuilder.Entity<EvidenceModel>(entity =>
        {
            entity.ToTable("Evidence");
            entity.HasKey(x => x.EvidenceID);
            entity.Property(x => x.Description).HasMaxLength(512);
            entity.Property(x => x.SerialNumber).HasMaxLength(128);
            entity.HasOne(x => x.Matter)
                  .WithMany(m => m.Evidences)
                  .HasForeignKey(x => x.MatterID)
                  .OnDelete(DeleteBehavior.Cascade);
        });
    }
}