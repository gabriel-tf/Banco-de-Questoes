using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using BancoDeQuestoes.Dominio;

namespace BancoDeQuestoes.DAL.Mapping {
    
    
    public class ItemQuestaoMap : ClassMap<ItemQuestao> {

        public ItemQuestaoMap()
        {
			Table("ItemQuestao");
			LazyLoad();
			Id(x => x.Codigo).GeneratedBy.Identity().Column("Codigo");
			References(x => x.Questao).Column("Questao_id");
			Map(x => x.Descricao).Column("Descricao");
            Map(x => x.Resposta).Column("Resposta");
            Map(x => x.ComentarioItem).Column("ComentarioItem");
        }
    }
}
