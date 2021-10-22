using Dindin.Models;
using System.ComponentModel.DataAnnotations;

namespace Dindin.Web.Models
{
    public class AulaModel
    {
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Link { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public int? CursoID { get; private set; }

        public AulaModel()
        {

        }

        public AulaModel(Aula aula)
        {
            this.Titulo = aula.retornaTitulo();
            this.Link = aula.retornaLink();
            this.Descricao = aula.retornaDescricao();
            this.CursoID = aula.retornaCursoID();
        }

        public Aula ToAula()
        {
            return new Aula(Titulo, Link, Descricao, CursoID);
        }
    }
}
