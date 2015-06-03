using BancoDeQuestoes.Dominio;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using System.Linq;
using System.Web;


namespace BancoDeQuestoes.UI.Models
{
    public class QuestaoModel
    {

        public QuestaoModel()
        {
            Itens = new List<ItemQuestaoModel>();
            Anos = new List<AnoModel>();
        }
        public HttpPostedFileBase MyFile { get; set; }

        public string CroppedImagePath { get; set; }

        public int Codigo { get; set; }

        public string Enunciado { get; set; }

        public string IdItens { get; set; }

        public string IdDisciplinas { get; set; }

        public string Comentario { get; set; }

        public string Tipo { get; set; }

        public Usuario Autor { get; set; }

        public string Dificuldade { get; set; }

        public Grau Grau { get; set; }
        public IList<AnoModel> Anos { get; set; }

        public IList<ItemQuestaoModel> Itens { get; set; }

        public Disciplina Disciplina { get; set; }

        public Assunto Assunto { get; set; }

        public ItemQuestaoModel ItemSubjetiva { get; set; }

        public string DataCriacao { get; set; }


    }
}
