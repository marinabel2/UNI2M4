using Microsoft.EntityFrameworkCore;
using Practica2EF2M4.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2EF2M4.Datos
{
    public class UNIDbContext:DbContext
    {
        public DbSet<AreaConocimiento> Areas => Set<AreaConocimiento>();
        public DbSet<Carrera> Carreras => Set<Carrera>();
        public DbSet <Estudiante> Estudiantes => Set<Estudiante>();
        public DbSet <Asignatura> Asignaturas => Set<Asignatura>();

        public DbSet <EstudianteAsignatura> Inscripciones => Set<EstudianteAsignatura>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"server=DESKTOP-F0HIFN6\SQLSERVER2019;"+
                    "Database=UNI2M4;" +
                    "Trusted_Connection = true;TrustServerCertificate=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AreaConocimiento>(e =>
            {
                e.ToTable("AreaConocimiento");
                e.HasKey(x => x.IdArea);
                e.Property(x => x.Nombre).HasMaxLength(50).IsRequired();
            });

            modelBuilder.Entity<Carrera>(e =>
            {
                e.ToTable("Carreras");
                e.HasKey(x => x.IdCarrera);
                e.Property(x => x.Nombre).HasMaxLength(50).IsRequired();
                e.HasOne (x =>x.Area).WithMany(x =>x.Carreras)
                .HasForeignKey(x =>x.IdArea).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Estudiante>(e => 
            {
                e.ToTable("Estudiantes");
                e.HasKey (x => x.IdEstudiante);
                e.Property(x =>x.Carnet).HasMaxLength(10).IsRequired();
                e.Property(x =>x.Nombres).HasMaxLength(100).IsRequired();
                e.Property(x => x.Apellidos).HasMaxLength(100).IsRequired();
                e.HasIndex(x => x.Carnet).IsUnique();
                e.HasOne(X =>X.Carrera)
                .WithMany(x =>x.Estudiante)
                .HasForeignKey(x =>x.IdCarrera).OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Asignatura>(e =>
            {
                e.ToTable("Asignatura");
                e.HasKey(x => x.IdAsignatura);
                e.HasIndex(x => x.Codigo).IsUnique();
            });

            modelBuilder.Entity<EstudianteAsignatura>(e => 
            {
                e.ToTable("EstudianteAsignatura");
                e.HasKey(x => new { x.IdEstudiante, x.IdAsignatura }); 
                e.Property(x => x.Nota).HasPrecision(3, 2);

                e.HasOne(x =>x.Estudiante).WithMany(x =>x.Inscripciones)
                .HasForeignKey(x =>x.IdEstudiante).OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x =>x.Asignatura).WithMany(x =>x.Inscripciones).
                HasForeignKey(x =>x.IdAsignatura).OnDelete(DeleteBehavior.Restrict);

            });
        }
    }
}
