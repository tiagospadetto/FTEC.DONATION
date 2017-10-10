using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FTEC.DONATION.Filtro
{
    public class FiltroAcesso : ActionFilterAttribute
    {

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            object usuariologado = filterContext.HttpContext.Session["Usuario"];
            if(usuariologado == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new { action = "Index", controller = "Login" }));
            }

        }

    }
}