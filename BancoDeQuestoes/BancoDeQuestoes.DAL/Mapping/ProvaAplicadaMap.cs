using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using BancoDeQuestoes.Dominio;

namespace BancoDeQuestoes.DAL.Mapping {
    
    
    public class ProvaAplicadaMap : ClassMap<ProvaAplicada> {

        public ProvaAplicadaMap()
        {
			Table("ProvaAplicada");
			LazyLoad();
			Id(x => x.Codigo).GeneratedBy.Identity().Column("Codigo");
			References(x => x.Prova).Column("Prova_id");
			References(x => x.Aluno).Column("Aluno_id");
			Map(x => x.DataAplicacao).Column("DataAplicacao");
        }
    }
}
