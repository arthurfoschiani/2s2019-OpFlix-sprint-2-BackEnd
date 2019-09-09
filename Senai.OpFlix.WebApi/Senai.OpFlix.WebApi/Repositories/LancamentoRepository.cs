using Microsoft.EntityFrameworkCore;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class LancamentoRepository : ILancamentoRepository
    {
        public void Atualizar(Lancamento lancamento)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Lancamento lancamentoBuscado = ctx.Lancamento.FirstOrDefault(x => x.IdLancamento == lancamento.IdLancamento);
                lancamentoBuscado.IdLancamento = lancamento.IdLancamento;
                lancamentoBuscado.IdTipoMidia = lancamento.IdTipoMidia;
                lancamentoBuscado.NomeMidia = lancamento.NomeMidia;
                lancamentoBuscado.Sinopse = lancamento.Sinopse;
                lancamentoBuscado.TempoDuracao = lancamento.TempoDuracao;
                lancamentoBuscado.IdCategoria = lancamento.IdCategoria;
                lancamentoBuscado.IdDiretor = lancamento.IdDiretor;
                lancamentoBuscado.DataLancamento = lancamento.DataLancamento;
                lancamentoBuscado.IdPlataforma = lancamento.IdPlataforma;
                lancamentoBuscado.Descricao = lancamento.Descricao;
                ctx.Lancamento.Update(lancamentoBuscado);
                ctx.SaveChanges();
            }
        }

        public void Cadastrar(Lancamento lancamento)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Lancamento.Add(lancamento);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Lancamento lancamentoBuscado = ctx.Lancamento.FirstOrDefault(x => x.IdLancamento == id);
                ctx.Lancamento.Remove(lancamentoBuscado);
                ctx.SaveChanges();
            }
        }

        public List<Lancamento> Listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Lancamento.ToList();
            }
        }

        public Lancamento BuscarPorId(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Lancamento.FirstOrDefault(x => x.IdLancamento == id);
            }
        }
    }
}
