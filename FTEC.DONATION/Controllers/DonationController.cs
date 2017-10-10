using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FTEC.DONATION.Models;

namespace FTEC.DONATION.Controllers
{
    public class DonationController : Controller
    {
        // GET: Donation
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SelectCad(String teste)
        {
            if(teste == "2")
            {
                return RedirectToAction("NewVoluntario");
            }
            else
            {
                return RedirectToAction("NewFundacao");
            }
        }

        public ActionResult NewVoluntario()
        {
            return View();
        }

        public ActionResult NewFundacao()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NovoVoluntario(Voluntario voluntario)
        {
            List<Voluntario> Voluntarios;


            if (Session["voluntarios"] == null)
            {
                Voluntarios = new List<Voluntario>();
            }
            else
            {
                Voluntarios = (List<Voluntario>)Session["voluntarios"];
            }

            Voluntarios.Add(voluntario);

            Session["voluntarios"] = Voluntarios;
            return RedirectToAction("Index", "Voluntario", new { area = "" });
        }

    }   
}