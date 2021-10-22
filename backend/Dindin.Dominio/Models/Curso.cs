using Dindin.Helper;
using System.Collections.Generic;

namespace Dindin.Models
{
    public class Curso
    {
        private int ID { get; set; }
        private string Titulo { get; set; }
        private string Capa { get; set; }
        private string NomeProfessor { get; set; }
        private string Descricao { get; set; }
        public List<Aula> Aulas { get; set; } = new List<Aula>();

        public Curso(int id, string titulo, string capa, string nomeProfessor, string descricao, List<Aula> listAulas)
        {
            this.ID = id;
            this.Titulo = titulo.ValidarStringVazia();
            this.Capa = capa;
            this.NomeProfessor = nomeProfessor.ValidarStringVazia();
            this.Descricao = descricao.ValidarStringVazia();
            this.Aulas = listAulas;
        }

        public int retornaID()
        {
            return this.ID;
        }
        public string retornaTitulo()
        {
            return this.Titulo;
        }
        public string retornaCapa()
        {
            return this.Capa;
        }
        public string retornaNomeProfessor()
        {
            return this.NomeProfessor;
        }
        public string retornaDescricao()
        {
            return this.Descricao;
        }
    }
}
