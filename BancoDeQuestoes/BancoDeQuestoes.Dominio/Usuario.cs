using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeQuestoes.Dominio
{
    public class Usuario
    {
        public enum Permissoes
        {
            Administrador = 1,
            Professor = 2,
        }

        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Email { get; set; }
        public virtual string Senha { get; set; }
        public virtual Permissoes Permissao { get; set; }
        
       
    }
}
