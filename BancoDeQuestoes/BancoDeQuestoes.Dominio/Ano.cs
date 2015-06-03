using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeQuestoes.Dominio
{
    public class Ano 
    {
        public virtual int AnoID { get; set; }

        public virtual string Descricao { get; set; }

        public virtual Grau Grau { get; set; }

        public virtual IList<Disciplina> Disciplinas { get; set; }
        public virtual IList<Assunto> Assuntos { get; set; }
        public virtual IList<Questao> Questoes { get; set; }

         public Ano()
        {
            Disciplinas = new List<Disciplina>();
            Assuntos = new List<Assunto>();
            Questoes = new List<Questao>();
        }
    }
}
