using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FTEC.DONATION.Controllers;
using FTEC.DONATION.Models;
using FTEC.DONATION.Filtro;

namespace FTEC.DONATION.Controllers
{   
    [FiltroAdm]
    public class AdministradorController : Controller
    {
        // GET: Administrador
        public ActionResult Index()
        {
            String administrador = (String)Session["Administrador"];

            ViewBag.administrador = administrador;

            return View();
        }

        public ActionResult GerenciarFundacao()
        {
            List<Fundacao> Fundacoes;
            List<Fundacao> FundacoesAprove;

            Fundacoes = (List<Fundacao>)Session["AproveFundacao"];
            FundacoesAprove = (List<Fundacao>)Session["Fundacao"];

            ViewBag.Fundacoes = Fundacoes;
            ViewBag.FundacoesAprove = FundacoesAprove;
            return View();
        }

        [HttpPost]
        public ActionResult Aprova(Guid id)
        {
            List<Fundacao> fundacoes;
            List<Fundacao> fundaprovadas;

            if (Session["AproveFundacao"] == null)
            {
                fundacoes = new List<Fundacao>();
            }
            else
            {
                fundacoes = (List<Fundacao>)Session["AproveFundacao"];
            }

            

            var fundacao = fundacoes.Where(p => p.Id == id).FirstOrDefault();

            if (fundacao != null)
            {
                if (Session["Fundacao"] == null)
                {
                    fundaprovadas = new List<Fundacao>();
                }
                else
                {
                    fundaprovadas = (List<Fundacao>)Session["Fundacao"];
                }

                fundaprovadas.Add(fundacao);
                fundacoes.Remove(fundacao);

                Session["Fundacao"] = fundaprovadas ;
                Session["AproveFundacao"] = fundacoes;
            }


            return View("GerenciarFundacao");
        }
        public ActionResult Logout( )
        {
            Session["Administrador"] = null;

           return RedirectToAction("Index", "Donation");
        }

    }
}