using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
     public interface IFavoritoRepository
    {
        List<Favorito> Listar(int UsuarioId);
        void Cadastrar(Favorito favorito);
    }
}
