using BancoDeQuestoes.Dominio;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeQuestoes.DAL
{
    public class AssuntoDAL : BaseClassDAL<Assunto>
    {
        public List<Assunto> RetornarAssuntos()
        {
            // Criteria
            var resultado = Session.CreateCriteria<Assunto>();
            //resultado.Add(Expression.Eq("Disciplinas", disciplina));
            return resultado.List<Assunto>().ToList();
        }
    }
}
