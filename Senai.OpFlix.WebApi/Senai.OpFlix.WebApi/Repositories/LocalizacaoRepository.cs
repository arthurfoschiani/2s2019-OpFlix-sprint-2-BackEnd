using MongoDB.Driver;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class LocalizacaoRepository : ILocalizacaoRepository
    {
        private readonly IMongoCollection<Localizacao> _localizacoes;

        public LocalizacaoRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("m_opflix");
            _localizacoes = database.GetCollection<Localizacao>("mapas");
        }

        public void Cadastrar(Localizacao localizacao)
        {
            _localizacoes.InsertOne(localizacao);
        }

        public List<Localizacao> Listar()
        {
            return _localizacoes.Find(l => true).ToList();
        }
    }
}
