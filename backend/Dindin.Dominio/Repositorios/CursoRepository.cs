using Dindin.DAO;
using Dindin.Interface;
using Dindin.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Dindin.Dominio.Repositorio
{
    public class CursoRepository : IRepository
    {
        private Curso curso;

        public List<Curso> GetCursos()
        {
            List<Curso> listaCursos = new List<Curso>();

            DataTable dt = ConexaoMysql.retornaDados($"SELECT * FROM curso");

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int idCurso = Convert.ToInt32($"{dt.Rows[i]["idcurso"]}");
                    string titulo = $"{dt.Rows[i]["titulo"]}";
                    string capa = $"{dt.Rows[i]["capa"]}";
                    string nomeProfessor = $"{dt.Rows[i]["nome_professor"]}";
                    string descricao = $"{dt.Rows[i]["descricao"]}";
                    this.curso = new Curso(idCurso, titulo, capa, nomeProfessor, descricao, null);

                    listaCursos.Add(this.curso);
                }
            }
            else return null;

            return listaCursos;
        }

        public Curso GetCursoID(int? id)
        {
            DataTable dt = ConexaoMysql.retornaDados($"SELECT * FROM curso WHERE curso.idcurso = {id}");

            if (dt.Rows.Count > 0)
            {
                int idCurso = Convert.ToInt32($"{dt.Rows[0]["idcurso"]}");
                string tituloCurso = $"{dt.Rows[0]["titulo"]}";
                string capa = $"{dt.Rows[0]["capa"]}";
                string nomeProfessor = $"{dt.Rows[0]["nome_professor"]}";
                string descricaoCurso = $"{dt.Rows[0]["descricao"]}";
                this.curso = new Curso(idCurso, tituloCurso, capa, nomeProfessor, descricaoCurso, null);
            }
            else return null;

            return this.curso;
        }

        public List<Aula> GetAulasByCursoID(int id)
        {
            List<Aula> listaAulas = new List<Aula>();
            DataTable dt = ConexaoMysql.retornaDados($"SELECT * FROM curso WHERE curso.idcurso = {id}");

            if (dt.Rows.Count > 0)
            {
                DataTable dtAula = ConexaoMysql.retornaDados($"SELECT * FROM aula WHERE aula.id_curso = {id}");

                if (dtAula.Rows.Count > 0)
                {
                    for (int i = 0; i < dtAula.Rows.Count; i++)
                    {
                        string tituloAula = $"{dtAula.Rows[i]["titulo"]}";
                        string link = $"{dtAula.Rows[i]["link"]}";
                        string descricaoAula = $"{dtAula.Rows[i]["descricao"]}";
                        listaAulas.Add(new Aula(tituloAula, link, descricaoAula, id));
                    }
                }
                else return null;
            }
            else return null;

            return listaAulas;
        }

        public bool CreateCurso(Curso curso)
        {
            try
            {
                int? idFK = ConexaoMysql.executaComando($"INSERT INTO curso (titulo, capa, nome_professor, descricao) VALUES ('{curso.retornaTitulo()}', '{curso.retornaCapa()}', '{curso.retornaNomeProfessor()}', '{curso.retornaDescricao()}')", true);

                for (int i = 0; i < curso.Aulas.Count; i++)
                {
                    Aula aula = new Aula(curso.Aulas[i].retornaTitulo(), curso.Aulas[i].retornaLink(), curso.Aulas[i].retornaDescricao(), curso.Aulas[i].retornaCursoID());
                    ConexaoMysql.executaComando($"INSERT INTO aula (titulo, link, descricao, id_curso) VALUES ('{aula.retornaTitulo()}', '{aula.retornaLink()}','{aula.retornaDescricao()}', {idFK})", false);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateCurso(int? id, Curso curso)
        {
            try
            {
                DataTable dt = ConexaoMysql.retornaDados($"SELECT * FROM curso WHERE curso.idcurso = {id}");

                if (dt.Rows.Count > 0)
                {
                    ConexaoMysql.executaComando(@$"UPDATE curso 
                                           SET titulo = '{curso.retornaTitulo()}',
                                           capa = '{curso.retornaCapa()}',
                                           nome_professor = '{curso.retornaNomeProfessor()}',
                                           descricao = '{curso.retornaDescricao()}'
                                           WHERE idcurso = {id}", false);
                }
                else return false;

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateAulasByCursoTitulo(int? id, string tituloAula, Aula listaAula)
        {
            try
            {
                DataTable dt = ConexaoMysql.retornaDados($"(SELECT * FROM curso WHERE curso.idcurso = {id})");

                if (dt.Rows.Count > 0)
                {
                    DataTable dtAula = ConexaoMysql.retornaDados($"SELECT * FROM aula WHERE aula.id_curso = {id} AND aula.titulo = '{tituloAula}'");

                    if (dtAula.Rows.Count > 0)
                    {
                        ConexaoMysql.executaComando(@$"UPDATE aula SET titulo = '{listaAula.retornaTitulo()}',
                                           link = '{listaAula.retornaLink()}',
                                           descricao = '{listaAula.retornaDescricao()}'
                                           WHERE aula.id_curso = {id} AND aula.titulo = '{tituloAula}'", false);
                    }
                }
                else return false;

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteCurso(int? id)
        {
            try
            {
                DataTable dt = ConexaoMysql.retornaDados($"SELECT * FROM curso WHERE curso.idcurso = {id}");

                if (dt.Rows.Count > 0)
                {
                    ConexaoMysql.executaComando($"DELETE FROM aula WHERE aula.id_curso = {id}", false);
                    ConexaoMysql.executaComando($"DELETE FROM curso WHERE curso.idcurso = {id}", false);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteAulaByCursoID(int? id, string tituloAula)
        {
            try
            {
                DataTable dtCurso = ConexaoMysql.retornaDados($"SELECT * FROM curso WHERE curso.idcurso = {id}");

                if (dtCurso.Rows.Count > 0)
                {
                    DataTable dt = ConexaoMysql.retornaDados($"SELECT * FROM aula WHERE aula.id_curso = {id} AND aula.titulo = '{tituloAula}'");

                    if (dt.Rows.Count > 0)
                    {
                        ConexaoMysql.executaComando($"DELETE FROM aula WHERE aula.id_curso = {id} AND aula.titulo = '{tituloAula}'", false);
                    }
                    else return false;

                }
                else return false;

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
