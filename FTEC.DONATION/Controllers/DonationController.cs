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
        public ActionResult NovaFundacao(Fundacao fundacao)
        {
            List<Fundacao> Fundacoes;


            if (Session["AproveFundacao"] == null)
            {
                Fundacoes = new List<Fundacao>();
            }
            else
            {
                Fundacoes = (List<Fundacao>)Session["AproveFundacao"];
            }

            Fundacoes.Add(fundacao);

            Session["AproveFundacao"] = Fundacoes;

            return RedirectToAction("Index", "Fundacao", new { area = "" });
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

        [HttpPost]
        public ActionResult Autenticar(String Tipo, String Email, String Senha)
        {
            List<Voluntario> Voluntarios;

            Adm administrador = new Adm();

            administrador.Email = "admin";
            administrador.Senha = "admin123";


            Voluntarios = (List<Voluntario>)Session["voluntarios"];

            if (Voluntarios != null || Tipo == "2")
            {
                foreach (var Voluntario in Voluntarios)
                {

                    if (Voluntario.Email == Email || Voluntario.Senha == Senha)
                    {
                        Session["Usuario"] = Email;
                        return RedirectToAction("Index", "Voluntario");

                    }
                    else
                    {
                        Session["Usuario"] = null;
                        return JavaScript("<script>alert(\"método CarregarGrid()\")</script>");
                    }


                }
            }
            if (Tipo == "3")
            {
                if (administrador.Email == Email || administrador.Senha == Senha)
                {
                    Session["Usuario"] = null;
                    Session["Administrador"] = Email;
                    return RedirectToAction("Index", "Adminstrador");
                }
                

            }

            return RedirectToAction("Index");
        }

    }   
}