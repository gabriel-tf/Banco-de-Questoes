using BancoDeQuestoes.Dominio;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using System.Linq;
using System.Web;

namespace BancoDeQuestoes.UI.Models
{
    public class ItemQuestaoModel
    {        
        public int Codigo { get; set; }

        public string Descricao { get; set; }

        public string ComentarioItem { get; set; }

        public bool EhResposta { get; set; }

        public QuestaoModel Questao { get; set; }
         
    }
}