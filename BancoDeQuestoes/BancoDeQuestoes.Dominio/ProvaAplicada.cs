using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeQuestoes.Dominio
{
    public class ProvaAplicada
    {
        public virtual int Codigo { get; set; }

        public virtual Prova Prova { get; set; }
        public virtual Aluno Aluno { get; set; }

        public virtual IList<ItemQuestao> Resultados { get; set; }

        public virtual DateTime DataAplicacao { get; set; }
    }
}
