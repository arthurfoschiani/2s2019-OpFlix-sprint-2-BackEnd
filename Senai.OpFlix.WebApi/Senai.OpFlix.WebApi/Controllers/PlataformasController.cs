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
    public class PlataformasController : ControllerBase
    {
        private IPlataformaRepository PlataformaRepository { get; set; }

        public PlataformasController()
        {
            PlataformaRepository = new PlataformaRepository();
        }

        /// <summary>
        /// Listar todas as plataformas 
        /// </summary>
        /// <returns>Uma lista de plataformas</returns>
        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(PlataformaRepository.Listar());
        }

        /// <summary>
        /// Adicionar uma nova plataforma
        /// </summary>
        /// <param name="plataforma"></param>
        /// <returns>Uma verificação</returns>
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Cadastrar(Plataforma plataforma)
        {
            try
            {
                PlataformaRepository.Cadastrar(plataforma);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ocorreu um erro: " + ex.Message });
            }
        }

        /// <summary>
        /// Atualizar os dados de uma determinada plataforma buscada pelo id
        /// </summary>
        /// <param name="plataforma"></param>
        /// <returns>Uma verificação</returns>
        [Authorize(Roles = "Administrador")]
        [HttpPut]
        public IActionResult Atualizar(Plataforma plataforma)
        {
            try
            {
                Plataforma PlataformaBuscada = PlataformaRepository.BuscarPorId(plataforma.IdPlataforma);
                if (PlataformaBuscada == null)
                    return NotFound();

                PlataformaRepository.Atualizar(plataforma);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}