using BancoDeQuestoes.Dominio;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeQuestoes.DAL
{
    public class DisciplinaDAL : BaseClassDAL<Disciplina>
    {
        public List<Disciplina> RetornarDisciplinas()
        {
            // Criteria
            var resultado = Session.CreateCriteria<Disciplina>();
            return resultado.List<Disciplina>().ToList();
        }

        //public List<Disciplina> RetornarGrauFundamental()
        //{
        //    var resultado = Session.QueryOver<Disciplina>()
        //                   .Right.JoinQueryOver<Grau>(x => x.Graus)
        //                   .Where(c => c.GrauID == 1);
        //    return resultado.List<Disciplina>().ToList();
        //}

        //public List<Disciplina> RetornarGrauMedio()
        //{
        //    var resultado = Session.QueryOver<Disciplina>()
        //                   .Right.JoinQueryOver<Grau>(x => x.Graus)
        //                   .Where(c => c.GrauID == 2);
        //    return resultado.List<Disciplina>().ToList();
        //}

        //public List<Disciplina> RetornarGrauSuperior()
        //{
        //    var resultado = Session.QueryOver<Disciplina>()
        //                   .Right.JoinQueryOver<Grau>(x => x.Graus)
        //                   .Where(c => c.GrauID == 3);
        //    return resultado.List<Disciplina>().ToList();
        //}

        public List<Disciplina> RetornarPrimeiroFundamental()
        {
            var resultado = Session.QueryOver<Disciplina>()
                            .Right.JoinQueryOver<Ano>(x => x.Anos)
                            .Where(c => c.AnoID == 1);
            return resultado.List<Disciplina>().ToList();
        }
        public List<Disciplina> RetornarSegundoFundamental()
        {
            var resultado = Session.QueryOver<Disciplina>()
                            .Right.JoinQueryOver<Ano>(x => x.Anos)
                            .Where(c => c.AnoID == 2);
            return resultado.List<Disciplina>().ToList();
        }
        public List<Disciplina> RetornarTerceiroFundamental()
        {
            var resultado = Session.QueryOver<Disciplina>()
                            .Right.JoinQueryOver<Ano>(x => x.Anos)
                            .Where(c => c.AnoID == 3);
            return resultado.List<Disciplina>().ToList();
        }
        public List<Disciplina> RetornarQuartoFundamental()
        {
            var resultado = Session.QueryOver<Disciplina>()
                            .Right.JoinQueryOver<Ano>(x => x.Anos)
                            .Where(c => c.AnoID == 4);
            return resultado.List<Disciplina>().ToList();
        }
        public List<Disciplina> RetornarQuintoFundamental()
        {
            var resultado = Session.QueryOver<Disciplina>()
                            .Right.JoinQueryOver<Ano>(x => x.Anos)
                            .Where(c => c.AnoID == 5);
            return resultado.List<Disciplina>().ToList();
        }
        public List<Disciplina> RetornarSextoFundamental()
        {
            var resultado = Session.QueryOver<Disciplina>()
                            .Right.JoinQueryOver<Ano>(x => x.Anos)
                            .Where(c => c.AnoID == 6);
            return resultado.List<Disciplina>().ToList();
        }
        public List<Disciplina> RetornarSetimoFundamental()
        {
            var resultado = Session.QueryOver<Disciplina>()
                            .Right.JoinQueryOver<Ano>(x => x.Anos)
                            .Where(c => c.AnoID == 7);
            return resultado.List<Disciplina>().ToList();
        }
        public List<Disciplina> RetornarOitavoFundamental()
        {
            var resultado = Session.QueryOver<Disciplina>()
                            .Right.JoinQueryOver<Ano>(x => x.Anos)
                            .Where(c => c.AnoID == 8);
            return resultado.List<Disciplina>().ToList();
        }
        public List<Disciplina> RetornarNonoFundamental()
        {
            var resultado = Session.QueryOver<Disciplina>()
                            .Right.JoinQueryOver<Ano>(x => x.Anos)
                            .Where(c => c.AnoID == 9);
            return resultado.List<Disciplina>().ToList();
        }
        public List<Disciplina> RetornarPrimeiroMedio()
        {
            var resultado = Session.QueryOver<Disciplina>()
                            .Right.JoinQueryOver<Ano>(x => x.Anos)
                            .Where(c => c.AnoID == 10);
            return resultado.List<Disciplina>().ToList();
        }
        public List<Disciplina> RetornarSegundoMedio()
        {
            var resultado = Session.QueryOver<Disciplina>()
                            .Right.JoinQueryOver<Ano>(x => x.Anos)
                            .Where(c => c.AnoID == 11);
            return resultado.List<Disciplina>().ToList();
        }
        public List<Disciplina> RetornarTerceiroMedio()
        {
            var resultado = Session.QueryOver<Disciplina>()
                            .Right.JoinQueryOver<Ano>(x => x.Anos)
                            .Where(c => c.AnoID == 12);
            return resultado.List<Disciplina>().ToList();
        }
    }
}
