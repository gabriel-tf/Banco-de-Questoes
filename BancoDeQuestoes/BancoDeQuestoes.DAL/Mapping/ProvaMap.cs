using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using BancoDeQuestoes.Dominio; 

namespace BancoDeQuestoes.DAL.Mapping {
    
    
    public class ProvaMap : ClassMap<Prova> {
        
        public ProvaMap() {
			Table("Prova");
			LazyLoad();
			Id(x => x.Codigo).GeneratedBy.Identity().Column("Codigo");
			Map(x => x.DataCriacao).Column("DataCriacao");
        }
    }
}
