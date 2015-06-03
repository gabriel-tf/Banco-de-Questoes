using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BancoDeQuestoes.Dominio;

namespace BancoDeQuestoes.UI.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public BancoDeQuestoes.Dominio.Usuario.Permissoes Permissao { get; set; }

    }
}