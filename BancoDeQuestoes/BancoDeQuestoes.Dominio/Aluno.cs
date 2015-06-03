using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeQuestoes.Dominio
{
    public class Aluno
    {
        public virtual int Matricula { get; set; }

        public virtual string Nome { get; set; }

        public virtual string Turma { get; set; }

        public virtual IList<ProvaAplicada> ProvasAplicadas { get; set; }
    }
}
