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
    public class LancamentoRepository : ILancamentoRepository
    {
        /// <summary>
        /// Atualizar os dados de um lançamento
        /// </summary>
        /// <param name="lancamento"></param>
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

        /// <summary>
        /// Adicionar um novo lançamento
        /// </summary>
        /// <param name="lancamento"></param>
        public void Cadastrar(Lancamento lancamento)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Lancamento.Add(lancamento);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Deletar um lançamento buscado por seu Id
        /// </summary>
        /// <param name="id"></param>
        public void Deletar(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Lancamento lancamentoBuscado = ctx.Lancamento.FirstOrDefault(x => x.IdLancamento == id);
                ctx.Lancamento.Remove(lancamentoBuscado);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Listar todos os lançamentos
        /// </summary>
        /// <returns>Uma lista de lançamentos</returns>
        public List<Lancamento> Listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Lancamento.Include(x => x.IdCategoriaNavigation).Include(x => x.IdDiretorNavigation).Include(x => x.IdPlataformaNavigation).Include(x => x.IdTipoMidiaNavigation).ToList();
            }
        }

        /// <summary>
        /// Buscar por id um lançamento
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Um lançamento</returns>
        public Lancamento BuscarPorId(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Lancamento.FirstOrDefault(x => x.IdLancamento == id);
            }
        }

        /// <summary>
        /// Listar os lançamentos de uma mesma plataforma
        /// </summary>
        /// <param name="plataforma"></param>
        /// <returns>Uma lista de lançamentos</returns>
        public List<Lancamento> FiltrarPorPlataforma (string plataforma)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Lancamento.Include(x => x.IdPlataformaNavigation).Where(x => x.IdPlataformaNavigation.Plataforma1 == plataforma).ToList();
            }
        }

        /// <summary>
        /// Listar os lançamentos de uma mesma categoria
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns>Uma lista de lançamentos</returns>
        public List<Lancamento> FiltrarPorCategoria(int categoria)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Lancamento.Include(x => x.IdCategoriaNavigation).Include(x => x.IdDiretorNavigation).Include(x => x.IdPlataformaNavigation).Include(x => x.IdTipoMidiaNavigation).Where(x => x.IdCategoria == categoria).ToList();
            }
        }

        /// <summary>
        /// Listar os lançamentos a partir da busca de uma data
        /// </summary>
        /// <param name="lancamento"></param>
        /// <returns>Uma lista de lançamentos</returns>
        public List<Lancamento> FiltrarPorDataLancamento (int lancamento)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Lancamento.Include(x => x.IdCategoriaNavigation).Include(x => x.IdDiretorNavigation).Include(x => x.IdPlataformaNavigation).Include(x => x.IdTipoMidiaNavigation).Where(x => x.DataLancamento.Value.Month == lancamento).ToList();
            }
        }
    }
}
