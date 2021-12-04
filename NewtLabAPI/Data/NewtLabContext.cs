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
        public DbSet<PruebaRespuesta> PruebaRespuesta { get; set; }
        public DbSet<TipoPregunta> TipoPreguntas { get; set; }
        public DbSet<PruebaExperimento> PruebaExperimentos { get; set; }
        public DbSet<Sesion> Sesions { get; set; }
        public DbSet<History> History { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=tcp:newtlabapi.database.windows.net,1433;Initial Catalog=NewLab;User Id=Holascupido@newtlabapi;Password=Holas123");
            //optionsBuilder.UseSqlServer(@"Server=.;Database=NewtLab;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BancoPregunta>()
                .HasOne(e => e.User)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PruebaRespuesta>()
                .HasOne(e => e.PE)
                .WithMany(pe => pe.PruebaRespuestas)
                .HasForeignKey(e => e.PEId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
