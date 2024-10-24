using Microsoft.EntityFrameworkCore;

namespace PPL.Models;

public partial class PplDatabaseContext : DbContext
{
    public PplDatabaseContext()
    {

    }

    public PplDatabaseContext(DbContextOptions<PplDatabaseContext> options)
        : base(options)
    {

    }

    public virtual required DbSet<Session> Sessions { get; init; }

    public virtual required DbSet<SessionUser> SessionUsers { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Session>(entity =>
        {
            entity.HasKey(e => e.SessionId).HasName("PK__Session__C9F49290BBE9A559");

            entity.ToTable("Session");

            entity.Property(e => e.SessionId).ValueGeneratedNever();
            entity.Property(e => e.Description).HasMaxLength(1024);
            entity.Property(e => e.Name).HasMaxLength(128);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<SessionUser>(entity =>
        {
            entity.HasKey(e => e.SessionUserId).HasName("PK__SessionU__96CEF1C0BD06F1A2");

            entity.ToTable("SessionUser");

            entity.Property(e => e.SessionUserId).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(128);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.VoteDate).HasColumnType("datetime");

            entity.HasOne(d => d.Session).WithMany(p => p.SessionUsers)
                .HasForeignKey(d => d.SessionId)
                .HasConstraintName("FK__SessionUs__Sessi__5EBF139D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
