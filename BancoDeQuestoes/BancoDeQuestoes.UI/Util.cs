using BancoDeQuestoes.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BancoDeQuestoes.UI
{
    public static class Util
    {
        public static Usuario RetornarUsuarioLogado()
        {
            var usuario = HttpContext.Current.Session["user"];

            if (usuario != null)
            {
                //if (usuario.Equals(Usuario.Permissoes.Professor))
                //{

                //}
                return (Usuario)usuario;
            }

            return null;
        }


    }
}