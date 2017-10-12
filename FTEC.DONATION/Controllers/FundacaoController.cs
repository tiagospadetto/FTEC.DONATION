using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FTEC.DONATION.Filtro;
using FTEC.DONATION.Models;

namespace FTEC.DONATION.Controllers
{   
    [FiltroFundacao]
    public class FundacaoController : Controller
    {
        // GET: Fundacao
        [FiltroFundacao]
        public ActionResult Index()
        {
            Guid Fundacao = new Guid ();
            List<Fundacao> Fundacoes;
            if(Session["AcessoF"] != null)
            {
                Fundacao = (Guid)Session["AcessoF"];
            
            Fundacoes = (List<Fundacao>)Session["Fundacao"];

            var fundacao = Fundacoes.Where(p => p.Id == Fundacao).FirstOrDefault();

            ViewBag.Fundacao = fundacao.Nome;
            }
            return View();
        }
        public ActionResult Novo()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session["AcessoF"] = null;

            return RedirectToAction("Index", "Donation");
        }
    }
}