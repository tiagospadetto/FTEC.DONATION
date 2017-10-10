using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FTEC.DONATION.Models;
using FTEC.DONATION.Controllers;

namespace FTEC.DONATION.Controllers
{
    public class VoluntarioController : Controller
    {
        // GET: Vonluntario
        public ActionResult Index()
        {
            List<Voluntario> Voluntarios;

            Voluntarios = (List<Voluntario>)Session["voluntarios"];

            ViewBag.voluntarios = Voluntarios;

            return View();
        }
 
    }
}