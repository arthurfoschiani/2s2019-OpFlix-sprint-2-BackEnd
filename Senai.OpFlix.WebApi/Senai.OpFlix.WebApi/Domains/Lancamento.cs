using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class Lancamento
    {
        public int IdLancamento { get; set; }
        public int? IdTipoMidia { get; set; }
        public string NomeMidia { get; set; }
        public string Sinopse { get; set; }
        public string TempoDuracao { get; set; }
        public int? IdCategoria { get; set; }
        public int? IdDiretor { get; set; }
        [Required]
        public DateTime? DataLancamento { get; set; }
        public int? IdPlataforma { get; set; }
        public string Descricao { get; set; }

        public Categoria IdCategoriaNavigation { get; set; }
        public Diretor IdDiretorNavigation { get; set; }
        public Plataforma IdPlataformaNavigation { get; set; }
        public TipoMidia IdTipoMidiaNavigation { get; set; }
        public List<Favorito> Favoritos { get; set; }
    }
}
