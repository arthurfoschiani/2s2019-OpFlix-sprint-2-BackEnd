using Microsoft.EntityFrameworkCore;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using Senai.OpFlix.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        /// <summary>
        /// Buscar o email e senha presente no banco de dados e comparar se são iguais as inseridas pelo usuário
        /// </summary>
        /// <param name="login"></param>
        /// <returns>Um usuário que possui aquele email e senha</returns>
        public Usuario BuscarPorEmailSenha(LoginViewModel login)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Usuario usuarios = ctx.Usuario.Include(x => x.TipoUsuarioNavigation).FirstOrDefault(x => x.EmailUsuario == login.Email && x.SenhaUsuario == login.Senha);
                if (usuarios == null)
                {
                    return null;
                }
                return usuarios;
            }
        }

        /// <summary>
        /// Cadastrar um novo usuário
        /// </summary>
        /// <param name="usuarios"></param>
        public void Cadastrar(Usuario usuarios)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Usuario.Add(usuarios);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Listar todos os usuários
        /// </summary>
        /// <returns>Uma lista de usuários</returns>
        public List<UsuarioViewModel> Listar()
        {
            List<UsuarioViewModel> usuariosViewModel = new List<UsuarioViewModel>();

            using (OpFlixContext ctx = new OpFlixContext())
            {
                List<Usuario> usuarios = ctx.Usuario.Include(x => x.TipoUsuarioNavigation).ToList();
                foreach (var item in usuarios)
                {
                    UsuarioViewModel usuarioViewModel = new UsuarioViewModel();
                    usuarioViewModel.IdUsuario = item.IdUsuario;
                    usuarioViewModel.NomeUsuario = item.NomeUsuario;
                    usuarioViewModel.EmailUsuario = item.EmailUsuario;
                    usuarioViewModel.Telefone = item.Telefone;
                    usuarioViewModel.Cpf = item.Cpf;
                    usuarioViewModel.DataDeNascimento = item.DataDeNascimento;
                    usuarioViewModel.TipoUsuario = item.TipoUsuario;
                    usuarioViewModel.TipoUsuarioNavigation = item.TipoUsuarioNavigation;
                    usuarioViewModel.Favoritos = item.Favoritos;
                    usuariosViewModel.Add(usuarioViewModel);
                }
                return usuariosViewModel;
            }
        }
    }
}
