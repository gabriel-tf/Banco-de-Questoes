using BancoDeQuestoes.Dominio;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeQuestoes.DAL.Mapping
{
    public class AnoMap : ClassMap<Ano>
    {
        public AnoMap()
        {
            LazyLoad();
            Id(x => x.AnoID).GeneratedBy.Identity();
            Map(x => x.Descricao);
            References(x => x.Grau);
            HasManyToMany(x => x.Disciplinas);
            HasManyToMany(x => x.Assuntos);
            HasManyToMany(x => x.Questoes);
        }
    }
}
