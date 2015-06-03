﻿using BancoDeQuestoes.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BancoDeQuestoes.UI.Models
{
    public class AssuntoModel
    {
        public int AssuntoID { get; set; }
        public string Descricao { get; set; }
        public DisciplinaModel Disciplina { get; set; }
        public IList<GrauModel> Graus { get; set; }
        public IList<AnoModel> Anos { get; set; }
        public IList<QuestaoModel> Questao { get; set; }

    }
}