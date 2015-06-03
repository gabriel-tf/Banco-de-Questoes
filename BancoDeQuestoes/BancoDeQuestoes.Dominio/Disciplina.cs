using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeQuestoes.Dominio
{
    public class Disciplina
    {
        public virtual int DisciplinaID { get; set; }

        public virtual string Descricao { get; set; }

        public virtual IList<Grau> Graus { get; set; }

        public virtual IList<Ano> Anos { get; set; }

        public virtual IList<Assunto> Assuntos { get; set; }

        public virtual IList<Questao> Questoes { get; set; }

        public Disciplina()
        {
            Graus = new List<Grau>();
            Anos = new List<Ano>();
            Assuntos = new List<Assunto>();
            Questoes = new List<Questao>();
        }
    }
}
