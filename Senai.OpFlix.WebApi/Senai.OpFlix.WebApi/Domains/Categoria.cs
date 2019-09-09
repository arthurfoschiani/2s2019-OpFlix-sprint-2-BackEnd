using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class Categoria
    {
        public Categoria()
        {
            Lancamento = new HashSet<Lancamento>();
        }

        public int IdCategoria { get; set; }
        public string Categoria1 { get; set; }

        public ICollection<Lancamento> Lancamento { get; set; }
    }
}
