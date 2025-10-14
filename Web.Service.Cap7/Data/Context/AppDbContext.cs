using Microsoft.EntityFrameworkCore;
using Web.Service.Cap7.Models;

namespace Web.Service.Cap7.Data.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; } = default!;
    public DbSet<Sector> Sectors { get; set; } = default!;
    public DbSet<Equipment> Equipments { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasSequence<int>("SEQ_USERS");
        modelBuilder.HasSequence<int>("SEQ_SECTORS");
        modelBuilder.HasSequence<int>("SEQ_EQUIPMENTS");

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("USERS");

            entity.HasKey(u => u.Id);

            entity.Property(u => u.Id)
                .HasDefaultValueSql("SEQ_USERS.NEXTVAL")
                .ValueGeneratedOnAdd();

            entity.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("NAME");

            entity.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("EMAIL");

            entity.HasIndex(u => u.Email)
                .IsUnique()
                .HasDatabaseName("IX_USERS_EMAIL");

            entity.Property(u => u.PasswordHash)
                .IsRequired()
                .HasColumnType("BLOB")
                .HasColumnName("PASSWORD_HASH");

            entity.Property(u => u.PasswordSalt)
                .IsRequired()
                .HasColumnType("BLOB")
                .HasColumnName("PASSWORD_SALT");

            entity.Property(u => u.Role)
                .IsRequired()
                .HasColumnName("ROLE");

            entity.Property(u => u.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("CREATED_AT");

            entity.Property(u => u.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("UPDATED_AT");

            entity.HasMany(u => u.Sectors)
                .WithOne(s => s.User)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Sector>(entity =>
        {
            entity.ToTable("SECTORS");

            entity.HasKey(s => s.Id);

            entity.Property(s => s.Id)
                .HasDefaultValueSql("SEQ_SECTORS.NEXTVAL")
                .ValueGeneratedOnAdd();

            entity.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("NAME");

            entity.Property(s => s.Description)
                .HasMaxLength(250)
                .HasColumnName("DESCRIPTION");

            entity.Property(s => s.ConsumptionLimit)
                .IsRequired()
                .HasColumnName("CONSUMPTION_LIMIT");

            entity.Property(s => s.UserId)
                .HasColumnName("USER_ID");

            entity.Property(s => s.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("CREATED_AT");

            entity.Property(s => s.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("UPDATED_AT");

            entity.HasMany(s => s.Equipments)
                .WithOne(e => e.Sector)
                .HasForeignKey("SectorId")
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Equipment>(entity =>
        {
            entity.ToTable("EQUIPMENTS");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("SEQ_EQUIPMENTS.NEXTVAL")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("NAME");

            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasColumnName("IS_ACTIVE")
                .HasConversion<int>();

            entity.Property(e => e.ConsumptionPerHour)
                .IsRequired()
                .HasColumnName("CONSUMPTION_PER_HOUR");

            entity.Property(e => e.MaxActiveHours)
                .IsRequired()
                .HasColumnName("MAX_ACTIVE_HOURS");

            entity.Property(e => e.LastActivedAt)
                .IsRequired()
                .HasColumnName("LAST_ACTIVED_AT");

            entity.Property(u => u.SectorId)
                .IsRequired()
                .HasColumnName("SECTOR_ID");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("CREATED_AT");

            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("UPDATED_AT");

            entity.HasOne(e => e.Sector)
                .WithMany(s => s.Equipments)
                .HasForeignKey("SectorId")
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
