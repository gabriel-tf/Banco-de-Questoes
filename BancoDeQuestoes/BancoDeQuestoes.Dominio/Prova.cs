using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeQuestoes.Dominio
{
    public class Prova
    {
        public virtual int Codigo { get; set; }

        public virtual IList<Questao> Questoes { get; set; }

        public virtual DateTime DataCriacao { get; set; }

    }
}
