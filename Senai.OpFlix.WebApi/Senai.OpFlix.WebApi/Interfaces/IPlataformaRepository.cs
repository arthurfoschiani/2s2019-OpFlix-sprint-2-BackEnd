using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    public interface IPlataformaRepository
    {
        Plataforma BuscarPorId(int id);
        List<Plataforma> Listar();
        void Cadastrar(Plataforma plataforma);
        void Atualizar(Plataforma plataforma);
    }
}
