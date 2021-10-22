using Dindin.Helper;

namespace Dindin.Models
{
    public class Aula
    {
        private string Titulo { get; set; }
        private string Link { get; set; }
        private string Descricao { get; set; }
        public int? CursoID { get; protected set; }

        public Aula(string titulo, string link, string descricao, int? cursoID)
        {
            this.Titulo = titulo.ValidarStringVazia();
            this.Link = link.ValidarStringVazia();
            this.Descricao = descricao.ValidarStringVazia();
            this.CursoID = cursoID;
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }
        public string retornaLink()
        {
            return this.Link;
        }
        public string retornaDescricao()
        {
            return this.Descricao;
        }
        public int? retornaCursoID()
        {
            return this.CursoID;
        }
    }
}
