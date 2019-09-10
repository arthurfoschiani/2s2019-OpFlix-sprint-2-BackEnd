using Microsoft.EntityFrameworkCore;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class FavoritoRepository : IFavoritoRepository
    {
        public void Cadastrar(Favorito favorito)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Favorito.Add(favorito);
                ctx.SaveChanges();
            }
        }

        public List<Favorito> Listar(int UsuarioId)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {   
                return ctx.Favorito.Include(x => x.Lancamentos).Where(x => x.IdUsuario == UsuarioId).ToList();
            }
        }
    }
}
