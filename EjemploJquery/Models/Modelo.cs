namespace EjemploJquery.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Modelo : DbContext
    {
        public Modelo()
            : base("name=Modelo")
        {
        }

        public virtual DbSet<Docentes> Docentes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Docentes>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Docentes>()
                .Property(e => e.apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Docentes>()
                .Property(e => e.direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Docentes>()
                .Property(e => e.especialidad)
                .IsUnicode(false);
        }
    }
}
