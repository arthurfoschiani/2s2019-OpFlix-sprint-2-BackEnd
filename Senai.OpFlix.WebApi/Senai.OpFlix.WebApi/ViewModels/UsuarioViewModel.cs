using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.ViewModels
{
    public class UsuarioViewModel
    {
        public int IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string EmailUsuario { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public DateTime? DataDeNascimento { get; set; }
        public int? TipoUsuario { get; set; }
        public List<Favorito> Favoritos { get; set; }

        public TipoUsuario TipoUsuarioNavigation { get; set; }
    }
}
