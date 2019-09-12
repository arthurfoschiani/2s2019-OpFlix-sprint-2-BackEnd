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
    public class CategoriasController : ControllerBase
    {
        private ICategoriaRepository CategoriaRepository { get; set; }

        public CategoriasController()
        {
            CategoriaRepository = new CategoriaRepository();
        }

        /// <summary>
        /// Listar todas as categorias
        /// </summary>
        /// <returns>Lista de categorias</returns>
        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(CategoriaRepository.Listar());
        }

        /// <summary>
        /// Adicionar novas categorias
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns>Uma verificação</returns>
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Cadastrar(Categoria categoria)
        {
            try
            {
                CategoriaRepository.Cadastrar(categoria);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ocorreu um erro: " + ex.Message });
            }
        }

        /// <summary>
        /// Atualizar um determinada as categorias
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns>Uma verificação</returns>
        [Authorize(Roles = "Administrador")]
        [HttpPut]
        public IActionResult Atualizar(Categoria categoria)
        {
            try
            {
                Categoria CategoriaBuscada = CategoriaRepository.BuscarPorId(categoria.IdCategoria);
                if (CategoriaBuscada == null)
                    return NotFound();

                CategoriaRepository.Atualizar(categoria);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}