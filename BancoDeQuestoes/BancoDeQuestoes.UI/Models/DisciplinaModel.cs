using BancoDeQuestoes.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BancoDeQuestoes.UI.Models
{
    public class DisciplinaModel
    {
        public int DisciplinaID { get; set; }
        public string Descricao { get; set; }
        public IList<GrauModel> Graus { get; set; }
        public IList<AnoModel> Anos { get; set; }
        public IList<AssuntoModel> Assuntos { get; set; }
        public IList<QuestaoModel> Questoes { get; set; }
    }
}