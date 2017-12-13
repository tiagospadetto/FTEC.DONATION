using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FTEC.DONATION.Filtro;
using FTEC.DONATION.Models;
using FTEC.DONATION.INFRA.REPOSITORIO;
using FTEC.DONATION.DOMINIO.Entidade;

namespace FTEC.DONATION.Controllers
{
    [FiltroFundacao]
    public class FundacaoController : Controller
    {

        private string strConexao = "Server=localhost; Port=5432; Database=projeto; User Id = postgres; Password = 12345; ";

        // GET: Fundacao
        [FiltroFundacao]
        public ActionResult Index()
        {
            Guid Fundacao = new Guid();
            List<Funcacao> Fundacoes;
            FundacaoRepositorio fundacaoRepositorio = new FundacaoRepositorio(strConexao);

            if (Session["AcessoF"] != null)
            {
                Fundacao = (Guid)Session["AcessoF"];

                Fundacoes = fundacaoRepositorio.ListarAprovadas();

                var fundacao = Fundacoes.Where(p => p.Id == Fundacao).FirstOrDefault();

                ViewBag.Fundacao = fundacao.Nome;
            }
            return View();
        }
        public ActionResult Novo()
        {
            return View();
        }

        public ActionResult VisualizarEventos()
        {
            return View();
        }

        public ActionResult FazerDoacao()
        {
            return View();
        }


        public ActionResult VisualizarFundacoes()
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