using Microsoft.EntityFrameworkCore;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        public void Atualizar(Categoria categoria)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Categoria categoriaBuscada = ctx.Categoria.FirstOrDefault(x => x.IdCategoria == categoria.IdCategoria);
                categoriaBuscada.IdCategoria = categoria.IdCategoria;
                categoriaBuscada.Categoria1 = categoria.Categoria1;
                ctx.Categoria.Update(categoriaBuscada);
                ctx.SaveChanges();
            }
        }

        public Categoria BuscarPorId(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Categoria.FirstOrDefault(x => x.IdCategoria == id);
            }
        }

        public void Cadastrar(Categoria categoria)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Categoria.Add(categoria);
                ctx.SaveChanges();
            }
        }

        public List<Categoria> Listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Categoria.Include(x => x.Lancamento).ToList();
            }
        }
    }
}
