using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using BancoDeQuestoes.Dominio;

namespace BancoDeQuestoes.DAL.Mapping {
    
    
    public class AssuntoMap : ClassMap<Assunto> {
        
        public AssuntoMap() {
			Table("Assunto");
			
			Id(x => x.AssuntoID).GeneratedBy.Identity();
			Map(x => x.Descricao);
            References(x => x.Disciplina);
            HasMany(x => x.Questoes);
            HasManyToMany(x => x.Graus);
            HasManyToMany(x => x.Anos);
        }
    }
}
