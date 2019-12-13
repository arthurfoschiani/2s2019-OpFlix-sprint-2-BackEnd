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
using Senai.OpFlix.WebApi.ViewModels;

namespace Senai.OpFlix.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class LancamentosController : ControllerBase
    {
        private ILancamentoRepository LancamentoRepository { get; set; }

        public LancamentosController()
        {
            LancamentoRepository = new LancamentoRepository();
        }

        /// <summary>
        /// Listar todos os lançamentos
        /// </summary>
        /// <returns>Uma lista de lançamntos</returns>
        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(LancamentoRepository.Listar());
        }

        /// <summary>
        /// Buscar um lançamento pelo seu id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Um lançamento</returns>
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                Lancamento lancamento = LancamentoRepository.BuscarPorId(id);
                if (lancamento == null)
                    return NotFound();
                return Ok(lancamento);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        /// <summary>
        /// Cadastrar um novo lançamento
        /// </summary>
        /// <param name="lancamento"></param>
        /// <returns>Uma verificação</returns>
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Cadastrar(Lancamento lancamentos)
        {
            try
            {
                LancamentoRepository.Cadastrar(lancamentos);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ocorreu um erro: " + ex.Message });
            }
        }

        /// <summary>
        /// Atualizar um determinado lançamento buscado pelo seu id
        /// </summary>
        /// <param name="lancamento"></param>
        /// <returns>Uma verificação</returns>
        [Authorize(Roles = "Administrador")]
        [HttpPut]
        public IActionResult Atualizar(Lancamento lancamento)
        {
            try
            {
                Lancamento LancamentoBuscado = LancamentoRepository.BuscarPorId(lancamento.IdLancamento);
                if (LancamentoBuscado == null)
                    return NotFound();

                LancamentoRepository.Atualizar(lancamento);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Deletar um determinado lançamento buscado pelo seu id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Uma verificação</returns>
        [Authorize(Roles = "Administrador")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            LancamentoRepository.Deletar(id);
            return Ok();
        }

        /// <summary>
        /// Listar lançamentos que tiverem a mesma plataforma
        /// </summary>
        /// <param name="Nome"></param>
        /// <returns>Lista de lançamentos</returns>
        [Authorize]
        [HttpGet("FiltrarPorPlataforma/{plataforma}")]
        public IActionResult FiltrarPorPlataforma (string plataforma)
        {
            return Ok(LancamentoRepository.FiltrarPorPlataforma(plataforma));
        }

        /// <summary>
        /// Listar lançamentos que tiverem a mesma categoria
        /// </summary>
        /// <param name="plataforma"></param>
        /// <returns>Lista de categorias</returns>
        [Authorize]
        [HttpGet("FiltrarPorCategoria/{categoria}")]
        public IActionResult FiltrarPorCategoria(int categoria)
        {
            return Ok(LancamentoRepository.FiltrarPorCategoria(categoria));
        }

        [Authorize]
        [HttpGet("FiltrarPorCategoria/")]
        public IActionResult Nula ()
        {
            return Ok(LancamentoRepository.Listar());
        }

        /// <summary>
        /// Listar lançamentos que tiveram o mesmo dia de lançamento
        /// </summary>
        /// <param name="lancamento"></param>
        /// <returns>Lista de lançamentos</returns>
        [Authorize]
        [HttpGet("FiltrarPorDataLancamento/{lancamento}")]
        public IActionResult FiltrarPorDataLancamento (int lancamento)
        {
            return Ok(LancamentoRepository.FiltrarPorDataLancamento(lancamento));
        }

        [Authorize]
        [HttpGet("FiltrarPorDataLancamento/")]
        public IActionResult Nulo()
        {
            return Ok(LancamentoRepository.Listar());
        }
    }
}