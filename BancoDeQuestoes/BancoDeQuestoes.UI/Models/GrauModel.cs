using BancoDeQuestoes.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BancoDeQuestoes.UI.Models
{
    public class GrauModel
    {
        public GrauModel()
        {
            Anos = new List<AnoModel>();
            Disciplinas = new List<DisciplinaModel>();
            Assuntos = new List<AssuntoModel>();
            Questoes = new List<QuestaoModel>();

        }
        public int GrauID { get; set; }
        public string Descricao { get; set; }
        public IList<AnoModel> Anos { get; set; }
        public IList<DisciplinaModel> Disciplinas { get; set; }
        public IList<AssuntoModel> Assuntos { get; set; }
        public IList<QuestaoModel> Questoes { get; set; }
 
    }
}