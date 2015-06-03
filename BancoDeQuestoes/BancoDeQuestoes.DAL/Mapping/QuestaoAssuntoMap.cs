using BancoDeQuestoes.Dominio;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BancoDeQuestoes.DAL.Mapping
{
    class QuestaoAssuntoMap : ClassMap<QuestaoAssunto>
    {
         public QuestaoAssuntoMap()
        {
            Table("QuestoesAssuntos");
            CompositeId().KeyReference(x => x.Questao, "QuestaoID")
                     .KeyReference(x => x.Assunto, "AssuntoID");
        }
    }
}
