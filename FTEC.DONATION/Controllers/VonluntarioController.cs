using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FTEC.DONATION.Controllers
{
    public class VonluntarioController : Controller
    {
        // GET: Vonluntario
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Novo()
        {
            return View();
        }
    }
}