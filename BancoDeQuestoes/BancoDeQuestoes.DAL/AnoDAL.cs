using BancoDeQuestoes.Dominio;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeQuestoes.DAL
{
    public class AnoDAL : BaseClassDAL<Ano>
    {
        public List<Ano> RetornarAnos()
        {
            // Criteria
            var resultado = Session.CreateCriteria<Ano>();
            return resultado.List<Ano>().ToList();
        }

        public List<Ano> RetornarEnsinoFundamental()
        {
            var resultado = Session.QueryOver<Ano>().Where(x => x.Grau.GrauID == 1);
            return resultado.List<Ano>().ToList();
        }

        public List<Ano> RetornarEnsinoMedio()
        {
            var resultado = Session.QueryOver<Ano>().Where(x => x.Grau.GrauID == 2);
            return resultado.List<Ano>().ToList();

        }

        public List<Ano> RetornarEnsinoSuperior()
        {
            var resultado = Session.QueryOver<Ano>().Where(x => x.Grau.GrauID == 3);
            return resultado.List<Ano>().ToList();
        }

        public List<Ano> RetornaAnosDisc(int idDisc)
        {
            var resultado = Session.QueryOver<Ano>()
                            .Right.JoinQueryOver<Disciplina>(x => x.Disciplinas)
                            .Where(c => c.DisciplinaID == idDisc);
            return resultado.List<Ano>().ToList();
        }
    }
}
