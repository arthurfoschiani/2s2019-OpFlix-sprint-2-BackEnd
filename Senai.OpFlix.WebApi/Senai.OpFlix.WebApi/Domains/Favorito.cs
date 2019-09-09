using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Domains
{
    public class Favorito
    {
        public int IdUsuario { get; set; }
        public Usuario Usuarios { get; set; }

        public int IdLancamento { get; set; }
        public Lancamento Lancamentos { get; set; }
    }
}
