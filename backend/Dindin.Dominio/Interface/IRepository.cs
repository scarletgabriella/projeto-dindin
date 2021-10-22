using Dindin.Models;
using System.Collections.Generic;

namespace Dindin.Interface
{
    public interface IRepository
    {
        public List<Curso> GetCursos();
        public Curso GetCursoID(int? id);
        public List<Aula> GetAulasByCursoID(int id);
        public bool CreateCurso(Curso curso);
        public bool UpdateCurso(int? id, Curso curso);
        public bool UpdateAulasByCursoTitulo(int? id, string tituloAula, Aula listaAula);
        public bool DeleteCurso(int? id);
        public bool DeleteAulaByCursoID(int? id, string tituloAula);
    }
}
