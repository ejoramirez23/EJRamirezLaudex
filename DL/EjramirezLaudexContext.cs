using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DL;

public partial class EjramirezLaudexContext : DbContext
{
    public EjramirezLaudexContext()
    {
    }

    public EjramirezLaudexContext(DbContextOptions<EjramirezLaudexContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Estatus> Estatuses { get; set; }

    public virtual DbSet<Prioridad> Prioridads { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<UserTask> UserTasks { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.; Database=EJRamirezLaudex; TrustServerCertificate=True; Trusted_Connection=True; User ID=sa; Password=pass@word1;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Estatus>(entity =>
        {
            entity.HasKey(e => e.IdEstatus).HasName("PK__Estatus__B32BA1C759FB91A7");

            entity.ToTable("Estatus");

            entity.HasIndex(e => e.Estatus1, "UQ__Estatus__D692F36EBFD7A090").IsUnique();

            entity.Property(e => e.Estatus1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Estatus");
        });

        modelBuilder.Entity<Prioridad>(entity =>
        {
            entity.HasKey(e => e.IdPrioridad).HasName("PK__Priorida__0FC70DD56380991E");

            entity.ToTable("Prioridad");

            entity.HasIndex(e => e.Prioridad1, "UQ__Priorida__B913BC5CE27515CD").IsUnique();

            entity.Property(e => e.Prioridad1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Prioridad");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.IdTask).HasName("PK__Task__9FCAD1C57C308DE4");

            entity.ToTable("Task");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion).HasColumnType("date");
            entity.Property(e => e.FechaVencimiento).HasColumnType("date");
            entity.Property(e => e.TaskName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEstatusNavigation).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.IdEstatus)
                .HasConstraintName("FK_EstatusTask");

            entity.HasOne(d => d.IdPrioridadNavigation).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.IdPrioridad)
                .HasConstraintName("FK_PrioridadTask");
        });

        modelBuilder.Entity<UserTask>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("UserTask");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF972B3EB10E");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Email, "UQ__Usuario__A9D1053476196359").IsUnique();

            entity.HasIndex(e => e.UserName, "UQ__Usuario__C9F28456AD5C86E0").IsUnique();

            entity.Property(e => e.ApellidoM)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ApellidoP)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Pass)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
