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
        /// <summary>
        /// Adicionar um novo lançamento para o usuário
        /// </summary>
        /// <param name="favorito"></param>
        public void Cadastrar(Favorito favorito)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Favorito.Add(favorito);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Listar todos os lançamentos favoritados pelo usuário
        /// </summary>
        /// <param name="UsuarioId"></param>
        /// <returns>Uma lista de favoritos</returns>
        public List<Favorito> Listar(int UsuarioId)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {   
                return ctx.Favorito.Include(x => x.Lancamentos).Where(x => x.IdUsuario == UsuarioId).ToList();
            }
        }

        /// <summary>
        /// Deletar um lançamento da lista de favoritos de um usuário
        /// </summary>
        /// <param name="IdLancamento"></param>
        /// <param name="IdUsuario"></param>
        public void Deletar (int IdLancamento, int IdUsuario)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Favorito FavoritoBuscado = ctx.Favorito.FirstOrDefault(x => x.IdLancamento == IdLancamento && x.IdUsuario == IdUsuario);
                ctx.Favorito.Remove(FavoritoBuscado);
                ctx.SaveChanges();
            }
        }
    }
}
