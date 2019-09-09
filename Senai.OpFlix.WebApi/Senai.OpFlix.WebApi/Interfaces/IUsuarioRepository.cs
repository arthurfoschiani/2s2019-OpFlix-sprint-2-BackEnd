using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario BuscarPorEmailSenha(LoginViewModel login);
        void Cadastrar(Usuario usuarios);
        List<UsuarioViewModel> Listar();
    }
}
