using BancoDeQuestoes.Dominio;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BancoDeQuestoes.DAL
{
    public class UsuarioDAL : BaseClassDAL<Usuario>
    {

        public bool ValidarAcesso(string email, string senha)
        {
            using (ISession session = NHibernateSessionPerRequest.GetCurrentSession())
            {
                return (from e in session.Query<Usuario>() where e.Email.Equals(email) && e.Senha.Equals(senha) select e).Count() > 0;
            }
        }

        //verifica o login e senha do usuário na tabela usuário
        public Usuario RetornarUsuarioPorLogin(String login)
        {
            var resultado = Session.CreateCriteria<Usuario>();
            resultado.Add(Expression.Eq("Email", login));
         
            return resultado.List<Usuario>().ToList().FirstOrDefault();
        }

        //verifica se um login já está cadastrado na tabela usuário
        public Usuario ValidarLogin(String email)
        {
            var resultado = Session.CreateCriteria<Usuario>();
            resultado.Add(Expression.Eq("Email", email));

            return resultado.List<Usuario>().ToList().FirstOrDefault();
        }

    }
}
