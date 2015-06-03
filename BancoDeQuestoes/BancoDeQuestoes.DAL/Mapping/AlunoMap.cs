using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using BancoDeQuestoes.Dominio;

namespace BancoDeQuestoes.DAL.Mapping
{    
    public class AlunoMap : ClassMap<Aluno> {
        
        public AlunoMap() {
			Table("Aluno");
			LazyLoad();
			Id(x => x.Matricula).GeneratedBy.Identity().Column("Matricula");
			Map(x => x.Nome).Column("Nome");
			Map(x => x.Turma).Column("Turma");
        }
    }
}
