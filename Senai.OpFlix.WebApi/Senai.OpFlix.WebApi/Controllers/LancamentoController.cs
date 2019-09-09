using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class LancamentoController : ControllerBase
    {
        private ILancamentoRepository LancamentoRepository { get; set; }

        public LancamentoController()
        {
            LancamentoRepository = new LancamentoRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(LancamentoRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(Lancamento lancamento)
        {
            try
            {
                LancamentoRepository.Cadastrar(lancamento);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ocorreu um erro: " + ex.Message });
            }
        }
        
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
        
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            LancamentoRepository.Deletar(id);
            return Ok();
        }
    }
}