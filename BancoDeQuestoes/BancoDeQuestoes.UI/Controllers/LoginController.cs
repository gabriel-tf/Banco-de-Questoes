using BancoDeQuestoes.DAL;
using BancoDeQuestoes.Dominio;
using CryptSharp;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BancoDeQuestoes.UI.Controllers
{
    public class LoginController : Controller
    {
        public enum Permissoes
        {
            Administrador = 1,
            Professor = 2,
        }
    
        //public Usuario usuario
        //{
        //    //get{ return (BancoDeQuestoes.Dominio.Usuario)Session["user"] as Usuario;}
        //    get { return HttpContext.Session["user"] as Usuario; }
        //    set{ Session["user"] = value;}
        //}
        public ActionResult Index()
        {
            return View();
        }

        public static bool Compara(string senha, string hash)
        {
            return Crypter.CheckPassword(senha, hash);
        }

        public JsonResult LoginUser(string email, string senha)
        {

            UsuarioDAL usuarioDAL = new UsuarioDAL();
            try
            {
                var usuario = usuarioDAL.RetornarUsuarioPorLogin(email);
                Session["user"] = null;


                if (usuario != null)
                {
                    if (Compara(senha, usuario.Senha))
                    {
                        if (ModelState.IsValid)
                        {
                            System.Web.Security.FormsAuthentication.SetAuthCookie(User.Identity.Name, false);
                            Session["user"] = usuario;

                            switch (usuario.Permissao)
                            {
                                case Usuario.Permissoes.Administrador:
                                    return Json("Adm");
                                    break;
                                    //break;
                                case Usuario.Permissoes.Professor:
                                    return Json("Professor");
                                    break;
                                    //break;
                            }

                        }
                        else { return Json("Model Invalido"); }
                    }
                }
                else
                {
                    // Nao há usuário registrado com esse email.
                    return Json("errado");
                }


                return Json("errado");

            }
            catch (Exception)
            {
                return Json("Erro");
            }
        }


        public JsonResult CadastraUser(int id, string nome, string email, string senha)
        {
            UsuarioDAL usuarioDAL = new UsuarioDAL();

            try
            {
                Usuario usuario = new Usuario();

                usuario.Id = id;
                usuario.Nome = nome;
                usuario.Email = email;
                usuario.Senha = Codifica(senha);
                usuario.Permissao = Usuario.Permissoes.Professor;

                var valida = usuarioDAL.ValidarLogin(email);

                if (valida == null)
                {
                    usuarioDAL.SaveOrUpdate(usuario);
                }
                else
                {
                  return Json("Email já existe");
                }
                return Json("");

            }
            catch (Exception)
            {
                return Json("Erro");
            }
        }

        public ActionResult LogOff()
        {
            System.Web.Security.FormsAuthentication.SignOut();
            return Redirect("/Home/Index");
        }

        public static string Codifica(string senha)
        {
            return Crypter.MD5.Crypt(senha);
           
        }
        
        public ActionResult Cadastro()
        {
            return View();
        }

        
    }

}