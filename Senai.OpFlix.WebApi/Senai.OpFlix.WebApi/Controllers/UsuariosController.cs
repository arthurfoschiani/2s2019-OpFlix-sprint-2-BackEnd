using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using Senai.OpFlix.WebApi.Repositories;

namespace Senai.OpFlix.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository UsuarioRepository { get; set; }

        public UsuariosController()
        {
            UsuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Listar todos os usuários
        /// </summary>
        /// <returns>Lista de usuários</returns>
        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(UsuarioRepository.Listar());
        }

        /// <summary>
        /// O administrador pode adicionar um novo usuário de qualquer tipo
        /// </summary>
        /// <param name="usuarios"></param>
        /// <returns>uma verificação</returns>
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Cadastrar(Usuario usuarios)
        {
            try
            {
                UsuarioRepository.Cadastrar(usuarios);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ocorreu um erro: " + ex.Message });
            }
        }

        /// <summary>
        /// Adicionar um novo usuario do tipo comum
        /// </summary>
        /// <param name="usuarios"></param>
        /// <returns>Uma verificação</returns>
        [HttpPost("CadastrarCliente")]
        public IActionResult CadastrarComum(Usuario usuarios)
        {
            try
            {
                usuarios.TipoUsuario = 2;
                UsuarioRepository.Cadastrar(usuarios);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ocorreu um erro: " + ex.Message });
            }
        }
    }
}