using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using BancoDeQuestoes.Dominio;

namespace BancoDeQuestoes.DAL.Mapping {
    
    
    public class QuestaoMap : ClassMap<Questao> {
        
        public QuestaoMap() {
			Table("Questao");
			
			Id(x => x.QuestaoID).GeneratedBy.Identity();
			References(x => x.Prova);
            References(x => x.Autor);
            References(x => x.Assunto);
            References(x => x.Disciplina);
            References(x => x.Grau);
            Map(x => x.Tipo);
            Map(x => x.Comentario);
            Map(x => x.Dificuldade);
            Map(x => x.Enunciado);
			Map(x => x.DataCriacao);
            Map(x => x.DataDelecao).Column("QuestaoDelDate");
            Map(x => x.Imagem);
            HasManyToMany(x => x.Anos);
        }
    }
}
