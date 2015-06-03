using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using BancoDeQuestoes.Dominio;

namespace BancoDeQuestoes.DAL {
    
    
    public class ResultadoQuestaoMap : ClassMap<ResultadoQuestao> {

        public ResultadoQuestaoMap()
        {
			Table("ResultadoQuestao");
			LazyLoad();
			Id(x => x.Codigo).GeneratedBy.Identity().Column("Codigo");
			References(x => x.Questao).Column("Questao_id");
			References(x => x.Resposta).Column("item_questao_id");
			References(x => x.ProvaAplicada).Column("ProvaAplicada_id");
        }
    }
}
