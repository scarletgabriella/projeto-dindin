using Dindin.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dindin.Web.Models
{
    public class CursoModel
    {
        public int ID { get; set; }
        [Required]
        public string Titulo { get; set; }
        public string Capa { get; set; }
        [Required]
        public string NomeProfessor { get; set; }
        [Required]
        public string Descricao { get; set; }
        public List<Aula> Aulas { get; set; } = new List<Aula>();

        public CursoModel()
        {

        }

        public CursoModel(Curso curso)
        {
            this.ID = curso.retornaID();
            this.Titulo = curso.retornaTitulo();
            this.Capa = curso.retornaCapa();
            this.NomeProfessor = curso.retornaNomeProfessor();
            this.Descricao = curso.retornaDescricao();
        }

        public Curso ToCurso()
        {
            return new Curso(ID, Titulo, Capa, NomeProfessor, Descricao, Aulas);
        }
    }
}
