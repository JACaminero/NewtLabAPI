using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewtlabAPI.Models;

namespace NewtlabAPI.Data
{
    public class NewtLabContext : DbContext
    {
        public NewtLabContext() : base()
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Experimento> Experimentos { get; set; }
        public DbSet<GuiaExperimento> GuiaExperimentos { get; set; }
        public DbSet<BancoPregunta> BancoPreguntas { get; set; }
        public DbSet<Pregunta> Preguntas { get; set; }
        public DbSet<Respuesta> Respuestas { get; set; }
        public DbSet<TipoPregunta> TipoPreguntas { get; set; }
        public DbSet<PruebaExperimento> PruebaExperimentos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=NewtLab;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BancoPregunta>()
                .HasOne(e => e.User)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
