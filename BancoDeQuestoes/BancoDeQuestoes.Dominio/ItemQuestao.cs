using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeQuestoes.Dominio
{
    public class ItemQuestao
    {
        public virtual int Codigo { get; set; }

        public virtual Questao Questao { get; set; }

        public virtual string Descricao { get; set; }

        public virtual string ComentarioItem { get; set; }
        
        public virtual int Resposta { get; set; }
    }
}
