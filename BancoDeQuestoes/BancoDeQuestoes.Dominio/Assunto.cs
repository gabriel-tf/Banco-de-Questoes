using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeQuestoes.Dominio
{
    public class Assunto
    {
        public virtual int AssuntoID { get; set; }

        public virtual string Descricao { get; set; }

        public virtual IList<Grau> Graus { get; set; }

        public virtual IList<Ano> Anos { get; set; }

        public virtual Disciplina Disciplina { get; set; }

        public virtual IList<Questao> Questoes { get; set; }


        public Assunto()
        {
            Questoes = new List<Questao>();
            Graus = new List<Grau>();
            Anos = new List<Ano>();
        }
        
    }
}
