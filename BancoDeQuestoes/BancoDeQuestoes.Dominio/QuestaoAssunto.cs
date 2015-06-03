using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeQuestoes.Dominio
{
    public class QuestaoAssunto
    {
        public virtual Questao Questao { get; set; }
        public virtual Assunto Assunto { get; set; }

        #region Fluent NHibernate Composite Key Overrides

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            var compare = obj as QuestaoAssunto;

            if (compare == null)
                return false;

            return Questao.QuestaoID == compare.Questao.QuestaoID &&
                   Assunto.AssuntoID == compare.Assunto.AssuntoID;
        }

        public override int GetHashCode()
        {
            return (Questao.QuestaoID + "|" + Assunto.AssuntoID).GetHashCode();
        }

        #endregion
    }
}
