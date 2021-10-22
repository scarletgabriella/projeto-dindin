using Dindin.Interface;
using Dindin.Models;
using Dindin.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Dindin.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : Controller
    {
        CursoModel modelCuso = new CursoModel();

        private readonly IRepository _repositorio; // somente leitura (injeção de dependência)

        public CursoController(IRepository repositorio) // significa que a instância pode ser qualquer coisa que implemente a interface 
        {
            _repositorio = repositorio;
        }

        [HttpGet("")]
        public IActionResult GetCursos()
        {
            List<Curso> verificaLista = _repositorio.GetCursos();

            if (verificaLista != null) return Ok(_repositorio.GetCursos().Select(curso => new CursoModel(curso)));
            return NotFound($"Nenhum curso cadastrado.");
        }

        [HttpGet("{id}")]
        public IActionResult GetCursoID(int id)
        {
            Curso curso = _repositorio.GetCursoID(id);

            if (curso != null)
            {
                this.modelCuso.ID = curso.retornaID();
                this.modelCuso.Titulo = curso.retornaTitulo();
                this.modelCuso.Capa = curso.retornaCapa();
                this.modelCuso.NomeProfessor = curso.retornaNomeProfessor();
                this.modelCuso.Descricao = curso.retornaDescricao();
                return Ok(this.modelCuso);
            }
            return NotFound($"Nenhum curso cadastrado referente ao id = {id}.");
        }

        [HttpGet("AulasDoCurso/{id}")]
        public IActionResult GetAulasByCursoID(int id)
        {
            List<Aula> verificaLista = _repositorio.GetAulasByCursoID(id);

            if (verificaLista != null) return Ok(_repositorio.GetAulasByCursoID(id).Select(aula => new AulaModel(aula)));
            return NotFound($"Nenhuma aula cadastrada referente ao id = {id}.");
        }


        [HttpPost("")]
        public IActionResult CreateCurso([FromBody] object curso)
        {
            dynamic data = JObject.Parse(curso.ToString());
            AulaModel modelAula = new AulaModel();
            List<Aula> listModel = new List<Aula>();

            if (curso != null)
            {
                this.modelCuso.Titulo = data.titulo;
                this.modelCuso.Capa = data.capa;
                this.modelCuso.NomeProfessor = data.nomeProfessor;
                this.modelCuso.Descricao = data.descricao;

                for (int i = 0; i < data.Aulas.Count; i++)
                {
                    modelAula.Titulo = data.Aulas[i].titulo;
                    modelAula.Link = data.Aulas[i].link;
                    modelAula.Descricao = data.Aulas[i].descricao;

                    listModel.Add(modelAula.ToAula());
                }

                this.modelCuso.Aulas = listModel;

                bool result = _repositorio.CreateCurso(modelCuso.ToCurso());

                if (result) return Created("", null);
                else return NotFound($"Curso não foi cadastrado.");
            }
            return BadRequest("Request inválido");
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateCurso(int? id, [FromBody] object curso)
        {
            if (id != null && curso != null)
            {
                dynamic data = JObject.Parse(curso.ToString());

                this.modelCuso.Titulo = data.titulo;
                this.modelCuso.Capa = data.capa;
                this.modelCuso.NomeProfessor = data.nomeProfessor;
                this.modelCuso.Descricao = data.descricao;

                bool result = _repositorio.UpdateCurso(id, modelCuso.ToCurso());

                if (result) return Ok($"Curso atualizado com sucesso.");
                else return NotFound($"Curso não encontrado.");
            }
            return BadRequest("Request inválido");
        }

        [HttpPut("AulaDoCurso")]
        public IActionResult UpdateAulasByCursoID(int? id, string tituloAula, [FromBody] object aula)
        {
            if (id != null && tituloAula != null && aula != null)
            {
                string newTituloAula = Regex.Replace(tituloAula, "-", " ");
                dynamic data = JObject.Parse(aula.ToString());
                AulaModel modelAula = new AulaModel();

                modelAula.Titulo = data.titulo;
                modelAula.Link = data.link;
                modelAula.Descricao = data.descricao;

                bool result = _repositorio.UpdateAulasByCursoTitulo(id, newTituloAula, modelAula.ToAula());

                if (result) return Ok($"Aula atualizada com sucesso.");
                else return NotFound($"Aula não encontrada.");
            }
            return BadRequest("Request inválido");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCurso(int id)
        {
            bool result = _repositorio.DeleteCurso(id);

            if (result) return Ok($"Curso referente ao id = {id} removido com sucesso.");
            else return NotFound($"Curso referente ao id = {id} não encontrado.");
        }

        [HttpDelete("AulaDoCurso")]
        public IActionResult DeleteAulaByCursoID(int? id, string tituloAula)
        {
            if (id != null && tituloAula != null)
            {
                string newTitulo = Regex.Replace(tituloAula, "-", " ");
                bool result = _repositorio.DeleteAulaByCursoID(id, newTitulo);

                if (result) return Ok($"Aula referente ao id = {id} removida com sucesso.");
                else return NotFound($"Aula do curso referente ao id = {id} não encontrada.");
            }
            return BadRequest("Request inválido");
        }
    }
}
