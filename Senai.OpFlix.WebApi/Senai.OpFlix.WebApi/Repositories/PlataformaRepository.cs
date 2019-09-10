using Microsoft.EntityFrameworkCore;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class PlataformaRepository : IPlataformaRepository
    {
        public void Atualizar(Plataforma plataforma)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Plataforma plataformaBuscada = ctx.Plataforma.FirstOrDefault(x => x.IdPlataforma == plataforma.IdPlataforma);
                plataformaBuscada.IdPlataforma = plataforma.IdPlataforma;
                plataformaBuscada.Plataforma1 = plataforma.Plataforma1;
                ctx.Plataforma.Update(plataformaBuscada);
                ctx.SaveChanges();
            }
        }

        public void Cadastrar(Plataforma plataforma)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Plataforma.Add(plataforma);
                ctx.SaveChanges();
            }
        }

        public List<Plataforma> Listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Plataforma.Include(x => x.Lancamento).ToList();
            }
        }

        public Plataforma BuscarPorId(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Plataforma.FirstOrDefault(x => x.IdPlataforma == id);
            }
        }
    }
}
