using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HospitalRoster.API.Models;

public partial class RosterContext : DbContext
{
    public RosterContext()
    {
    }

    public RosterContext(DbContextOptions<RosterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Roster> Rosters { get; set; }

    public virtual DbSet<Shift> Shifts { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MSI; Database= vaidyaInsights; TrustServerCertificate=true; Trusted_connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BEDE82F6B22");

            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Roster>(entity =>
        {
            entity.HasKey(e => e.RosterId).HasName("PK__Rosters__66F6BA8AEB014606");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsApproved).HasDefaultValue(false);
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Department).WithMany(p => p.Rosters)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__Rosters__Departm__5441852A");

            entity.HasOne(d => d.Shift).WithMany(p => p.Rosters)
                .HasForeignKey(d => d.ShiftId)
                .HasConstraintName("FK__Rosters__ShiftId__534D60F1");

            entity.HasOne(d => d.Staff).WithMany(p => p.Rosters)
                 .HasForeignKey(d => d.StaffId)
                .HasConstraintName("FK__Rosters__StaffId__52593CB8");
        });

        modelBuilder.Entity<Shift>(entity =>
        {
            entity.HasKey(e => e.ShiftId).HasName("PK__Shifts__C0A8388110A6C1ED");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__staff__96D4AB17D7D4531D");

            entity.ToTable("staff");

            entity.HasIndex(e => e.Email, "UQ__staff__A9D10534706B706F").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.MobileNumber).HasMaxLength(15);

            entity.HasOne(d => d.Department).WithMany(p => p.Staff)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__staff__Departmen__4CA06362");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
