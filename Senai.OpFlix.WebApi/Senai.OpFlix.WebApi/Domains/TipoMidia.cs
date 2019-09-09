using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class TipoMidia
    {
        public TipoMidia()
        {
            Lancamento = new HashSet<Lancamento>();
        }

        public int IdTipoMidia { get; set; }
        public string TipoMidia1 { get; set; }

        public ICollection<Lancamento> Lancamento { get; set; }
    }
}
