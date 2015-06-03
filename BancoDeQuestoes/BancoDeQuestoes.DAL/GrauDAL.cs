using BancoDeQuestoes.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeQuestoes.DAL
{
    public class GrauDAL : BaseClassDAL<Grau>
    {
            public List<Grau> RetornarGraus()
            {
                // Criteria
                var resultado = Session.CreateCriteria<Grau>();
                return resultado.List<Grau>().ToList();
            }

            public List<Grau> RetornaGrausDisc(int idDisc)
            {
                var resultado = Session.QueryOver<Grau>()
                            .Right.JoinQueryOver<Disciplina>(x => x.Disciplinas)
                            .Where(c => c.DisciplinaID == idDisc);
                return resultado.List<Grau>().ToList();
            }
    }
}
