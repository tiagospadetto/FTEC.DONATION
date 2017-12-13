using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FTEC.DONATION.Controllers;
using FTEC.DONATION.Models;
using FTEC.DONATION.Filtro;
using FTEC.DONATION.INFRA.REPOSITORIO;
using FTEC.DONATION.DOMINIO.Entidade;


namespace FTEC.DONATION.Controllers
{
    [FiltroAdm]
    public class AdministradorController : Controller
    {
        private string strConexao = "Server=localhost; Port=5432; Database=projeto; User Id = postgres; Password = 12345; ";

        // GET: Administrador
        public ActionResult Index()
        {
            String administrador = (String)Session["Administrador"];

            ViewBag.administrador = administrador;

            return View();
        }

        public ActionResult GerenciarFundacao()
        {
            List<Funcacao> Fundacoes;
            List<Funcacao> FundacoesAprove;

            FundacaoRepositorio fundacaoRepositorio = new FundacaoRepositorio(strConexao);


            Fundacoes = fundacaoRepositorio.Listar();
            FundacoesAprove = fundacaoRepositorio.ListarAprovadas();

            ViewBag.Fundacoes = Fundacoes;
            ViewBag.FundacoesAprove = FundacoesAprove;

            return View();
        }

        [HttpPost]
        public ActionResult Aprova(Guid id)
        {
            List<Funcacao> Fundacoes;
            List<Funcacao> FundacoesAprove;

            FundacaoRepositorio fundacaoRepositorio = new FundacaoRepositorio(strConexao);

            Fundacoes = fundacaoRepositorio.Listar();



            var fundacao = Fundacoes.Where(p => p.Id == id).FirstOrDefault();

            if (fundacao != null)
            {
                fundacaoRepositorio.Inserir(fundacao,"Aprovada");

                fundacaoRepositorio.Aprova(fundacao.Id);

            }


            return View("GerenciarFundacao");
        }
        public ActionResult Logout()
        {
            Session["Administrador"] = null;

            return RedirectToAction("Index", "Donation");
        }

    }
}