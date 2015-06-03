using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BancoDeQuestoes.Dominio
{
    public class ResultadoQuestao
    {
        public virtual int Codigo { get; set; }

        public virtual Questao Questao { get; set; }

        public virtual ItemQuestao Resposta { get; set; }

        public virtual ProvaAplicada ProvaAplicada { get; set; }

    }
}
