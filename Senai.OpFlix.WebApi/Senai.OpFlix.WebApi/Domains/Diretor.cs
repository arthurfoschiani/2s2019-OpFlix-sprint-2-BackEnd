using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class Diretor
    {
        public Diretor()
        {
            Lancamento = new HashSet<Lancamento>();
        }

        public int IdDiretor { get; set; }
        public string Diretor1 { get; set; }

        public ICollection<Lancamento> Lancamento { get; set; }
    }
}
