using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BancoDeQuestoes.Dominio;
using NHibernate.Mapping;
using NHibernate.Criterion;


namespace BancoDeQuestoes.DAL
{
    public class QuestaoDAL : BaseClassDAL<Questao>
    {
        public List<Questao> ListarQuestoes()
        {
            // Criteria
            var resultado = Session.CreateCriteria<Questao>();
            resultado.Add(Expression.IsNull("DataDelecao"));
            return resultado.List<Questao>().ToList();

        }

       
    }
}
