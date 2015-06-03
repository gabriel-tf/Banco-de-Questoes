using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeQuestoes.Dominio
{
    public class Questao
    {
        public Questao()
        {
            Itens = new List<ItemQuestao>();
            Anos = new List<Ano>();
        }
        public virtual int QuestaoID { get; set; }

        public virtual string Tipo { get; set; }

        public virtual string Comentario { get; set; }

        public virtual string Dificuldade { get; set; }

        public virtual string Enunciado { get; set; }

        public virtual Usuario Autor { get; set; }

        public virtual string EnunciadoCurto
        {
            get
            {
                if (Enunciado.Length > 30)
                {
                    return Enunciado.Substring(0, 30) + "...";
                }
                else {
                    return Enunciado;
                }

            }
        }

        public virtual IList<ItemQuestao> Itens { get; set; }
        
        public virtual ItemQuestao ItemSubjetiva { get; set; }

        public virtual Disciplina Disciplina { get; set; }

        public virtual Assunto Assunto { get; set; }

        public virtual Grau Grau { get; set; }

        public virtual IList<Ano> Anos { get; set; }

        public virtual DateTime DataCriacao { get; set; }

        public virtual Prova Prova { get; set; }

        public virtual DateTime? DataDelecao { get; set; }

        public virtual string Imagem { get; set; }
    }
}
