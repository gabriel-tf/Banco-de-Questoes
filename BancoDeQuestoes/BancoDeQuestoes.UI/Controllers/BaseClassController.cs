using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BancoDeQuestoes.DAL;
using BancoDeQuestoes.UI;

namespace BancoDeQuestoes.UI.Controllers
{
    public class BaseClassController : Controller
    {
        private bool EstaLogado = false;

        public BaseClassController() : base()
        {

        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ValidarCredencial();

            if (!EstaLogado)
            {
                filterContext.Result = new RedirectResult(string.Concat("~/Login"));
            }

            base.OnActionExecuting(filterContext);
        }

        protected override void Execute(RequestContext requestContext)
        {
            ValidarCredencial();

            base.Execute(requestContext);
        }

        private void ValidarCredencial()
        {
            if (Util.RetornarUsuarioLogado() == null)
                EstaLogado = false;
            else
                EstaLogado = true;
        }

        protected override JsonResult Json(object data, string contentType, System.Text.Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new JsonResult()
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior,
                MaxJsonLength = Int32.MaxValue
            };
        }
    }
}
