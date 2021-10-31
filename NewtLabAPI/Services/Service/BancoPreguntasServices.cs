using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewtlabAPI.Data;
using NewtlabAPI.Models;
using NewtlabAPI.Services.IServices;

namespace NewtlabAPI.Services.Service
{
    public class BancoPreguntasServices : IBancoPreguntaService
    {
        private readonly NewtLabContext context;

        public BancoPreguntasServices(NewtLabContext context)
        {
            this.context = context;
        }

        public IEnumerable<BancoPregunta> GetAll()
        {

            //var pes = context.PruebaExperimentos.
            //    .Where(pe => pe.Titulo == bp.Result.TituloPublicado).ToList();
            return context.BancoPreguntas.ToList();
        }

        public async Task<BancoPregunta> GetById(int id) => await context.BancoPreguntas.FindAsync(id);

        public async Task Insert(BancoPregunta bancoPregunta)
        {
            context.BancoPreguntas.Add(bancoPregunta);
            await context.SaveChangesAsync();
        }

        public bool Update(BancoPregunta bancoPregunta)
        {
            context.BancoPreguntas.Update(bancoPregunta);
            context.Entry(bancoPregunta).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

            return true;
        }

        public void Publicar(int id, DateTime limit, string t, string descripcion, string instruccion)
        {
            var bp = GetById(id);
            bp.Result.FechaLimite = limit;
            bp.Result.Publicado = true;
            bp.Result.TituloPublicado = t;
            bp.Result.Descripcion = descripcion;
            bp.Result.Instruccion = instruccion;
            context.SaveChanges();
        }

        public void Deshabilitar(int id)
        {
            var bp = GetById(id);
            var pes = context.PruebaExperimentos
                .Where(pe => pe.Titulo == bp.Result.TituloPublicado).ToList();
            for (int i = 0; i < pes.Count; i++)
            {
                pes[i].IsCerrada = true;
            }
            bp.Result.FechaLimite = new DateTime();
            bp.Result.Publicado = false;
            bp.Result.TituloPublicado = "";
            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            var getId = context.BancoPreguntas.Find(id);
            getId.IsOn = false;
            context.SaveChanges();

            return true;
        }

        public bool Relete(int id)
        {
            var getId = context.BancoPreguntas.Find(id);
            //context.BancoPreguntas.Remove(getId);
            getId.IsOn = true;
            context.SaveChanges();

            return true;
        }
    }
}
