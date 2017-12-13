using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FTEC.DONATION.Models;
using FTEC.DONATION.Controllers;
using FTEC.DONATION.Filtro;
using FTEC.DONATION.INFRA.REPOSITORIO;
using FTEC.DONATION.DOMINIO.Entidade;


namespace FTEC.DONATION.Controllers
{
    [FiltroAcesso]
    public class VoluntarioController : Controller
    {
        private string strConexao = "Server=localhost; Port=5432; Database=projeto; User Id = postgres; Password = 12345; ";

        // GET: Vonluntario
        [FiltroAcesso]
        public ActionResult Index()
        {
            List<EVoluntario> Voluntarios;
            Guid Voluntario = new Guid();
            VoluntarioRepositorio voluntarioRepositorio = new VoluntarioRepositorio(strConexao);


            if (Session["Usuario"] != null)
            {
                Voluntario = (Guid)Session["Usuario"];
                Voluntarios = voluntarioRepositorio.List();

                var voluntario = Voluntarios.Where(p => p.Id == Voluntario).FirstOrDefault();

                ViewBag.Voluntario = voluntario.Nome;
            }
            return View();

        }
        public ActionResult Logout()
        {
            Session["Usuario"] = null;
            return RedirectToAction("Index", "Donation");

        }

        public ActionResult VisualizarEventos()
        {
            return View();
            // return RedirectToAction("VisualizarEventos", "Voluntario");
        }

        public ActionResult Doar()
        {
            return RedirectToAction("Doar", "Voluntario");
        }

        public ActionResult VisualizarFundacoes()
        {
            //Gerar aqui um objeto com as fundações já cadastradas para enviar a view???
            return RedirectToAction("VisualizarFundacoes", "Voluntario");
        }
    }
}