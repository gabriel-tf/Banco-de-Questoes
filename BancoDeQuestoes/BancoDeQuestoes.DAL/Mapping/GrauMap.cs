using BancoDeQuestoes.Dominio;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeQuestoes.DAL.Mapping
{
    public class GrauMap: ClassMap<Grau>
    {
        public GrauMap()
        {
            LazyLoad();
            Id(x => x.GrauID).GeneratedBy.Identity();
            Map(x => x.Descricao);
            HasManyToMany(x => x.Assuntos);
            HasManyToMany(x => x.Disciplinas);
            HasMany(x => x.Questoes);
        }
    }
}
