using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            if(teste == "Vonluntario")
            {
                return RedirectToAction("Novo", "Vonluntario", new { area = "" });
            }
            else
            {
                return RedirectToAction("Novo", "Fundacao", new { area = "" });
            }
        }

        public ActionResult Vonluntario()
        {
            return RedirectToAction("Novo", "Vonluntario", new { area = "" });
        }

        public ActionResult Fundacao()
        {
            return RedirectToAction("Novo", "Fundacao", new { area = "" });
        }
    }   
}