using BancoDeQuestoes.Dominio;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeQuestoes.DAL.Mapping
{
    public class UsuarioMap : ClassMap<Usuario>
    {
        public UsuarioMap()
        {
            Table("Usuario");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity().Column("id");
            Map(x => x.Nome).Column("nome");
            Map(x => x.Email).Column("email");
            Map(x => x.Senha).Column("senha");
            Map(x => x.Permissao).Column("permissao");
        }
 
    }
}        
 