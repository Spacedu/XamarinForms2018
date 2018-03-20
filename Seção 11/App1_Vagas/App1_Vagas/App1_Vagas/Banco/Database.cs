using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Linq;
using App1_Vagas.Modelos;
using Xamarin.Forms;

namespace App1_Vagas.Banco
{
    class Database
    {
        private SQLiteConnection _conexao;

        public Database()
        {
            var dep = DependencyService.Get<ICaminho>();
            string caminho = dep.ObterCaminho("database.sqlite");

            _conexao = new SQLiteConnection(caminho);
            _conexao.CreateTable<Vaga>();
        }

        public List<Vaga> Consultar()
        {
            return _conexao.Table<Vaga>().ToList();
        }
        public List<Vaga> Pesquisar(string palavra)
        {
            return _conexao.Table<Vaga>().Where(a=>a.NomeVaga.Contains(palavra)).ToList();
        }
        public Vaga ObterVagaPorId(int id)
        {
            return _conexao.Table<Vaga>().Where(a=>a.Id == id).FirstOrDefault();
        }
        public void Cadastro(Vaga vaga)
        {
            _conexao.Insert(vaga);
        }
        public void Atualizacao(Vaga vaga)
        {
            _conexao.Update(vaga);
        }
        public void Exclusao(Vaga vaga)
        {
            _conexao.Delete(vaga);
        }
    }
}
