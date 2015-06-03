using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using BancoDeQuestoes.Dominio;

namespace BancoDeQuestoes.DAL.Mapping {
    
    
    public class DisciplinaMap : ClassMap<Disciplina> {
        
        public DisciplinaMap() {
			Table("Disciplina");
			LazyLoad();
			Id(x => x.DisciplinaID).GeneratedBy.Identity();
			Map(x => x.Descricao);
            HasMany(x => x.Assuntos);
            HasMany(x => x.Questoes);
            HasManyToMany(x => x.Anos);
            HasManyToMany(x => x.Graus);
           
        }
    }
}
