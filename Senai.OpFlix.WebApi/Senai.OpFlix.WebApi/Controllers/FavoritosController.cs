using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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
    public class FavoritosController : ControllerBase
    {
        private IFavoritoRepository FavoritoRepository { get; set; }

        public FavoritosController()
        {
            FavoritoRepository = new FavoritoRepository();
        }

        /// <summary>
        /// Listar todos os favoritos de um usuário
        /// </summary>
        /// <returns>Uma lista de favoritos</returns>
        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            int UsuarioId = Convert.ToInt32(HttpContext.User.Claims.First(x => x.Type == JwtRegisteredClaimNames.Jti).Value);
            return Ok(FavoritoRepository.Listar(UsuarioId));
        }

        /// <summary>
        /// Cadastrar um novo favorito do usuário
        /// </summary>
        /// <param name="favorito"></param>
        /// <returns>Uma verificação</returns>
        [Authorize]
        [HttpPost]
        public IActionResult Cadastrar(Favorito favorito)
        {
            try
            {
                int UsuarioId = Convert.ToInt32(HttpContext.User.Claims.First(x => x.Type == JwtRegisteredClaimNames.Jti).Value);
                favorito.IdUsuario = UsuarioId;
                FavoritoRepository.Cadastrar(favorito);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ocorreu um erro: " + ex.Message });
            }
        }

        /// <summary>
        /// Deletar um lançamento da área de favoritos de um usuário
        /// </summary>
        /// <param name="IdLancamento"></param>
        /// <returns>Uma verificação</returns>
        [HttpDelete("{IdLancamento}")]
        public IActionResult Deletar(int IdLancamento)
        {
            int IdUsuario = Convert.ToInt32(HttpContext.User.Claims.First(x => x.Type == JwtRegisteredClaimNames.Jti).Value);
            FavoritoRepository.Deletar(IdLancamento, IdUsuario);
            return Ok();
        }
    }
}