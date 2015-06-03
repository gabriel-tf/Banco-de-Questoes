using BancoDeQuestoes.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BancoDeQuestoes.UI.Models
{
    public class AnoModel
    {
        public int AnoID { get; set; }
        public string Descricao { get; set; }
        public Grau Graus { get; set; }
        public IList<DisciplinaModel> Disciplinas { get; set; }
        public IList<AssuntoModel> Assuntos { get; set; }
        public IList<QuestaoModel> Questoes { get; set; }


    }
}