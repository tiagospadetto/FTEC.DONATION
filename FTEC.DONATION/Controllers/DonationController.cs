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

            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Autenticar(String Tipo, String Email, String Senha)
        {
            List<Voluntario> Voluntarios;
            List<Fundacao> Fundacoes;

            Adm administrador = new Adm();

            administrador.Email = "admin";
            administrador.Senha = "admin123";


            Voluntarios = (List<Voluntario>)Session["voluntarios"];
            Fundacoes = (List<Fundacao>)Session["Fundacao"];

            if (Voluntarios != null && Tipo == "2")
            {
                foreach (var Voluntario in Voluntarios)
                {

                    if (Voluntario.Email == Email || Voluntario.Senha == Senha)
                    {
                        Session["Usuario"] = Voluntario.Id;
                        return RedirectToAction("Index", "Voluntario");

                    }
                    else
                    {
                        Session["Usuario"] = null;
                        return JavaScript("<script>alert(\"método CarregarGrid()\")</script>");
                    }


                }
            }
            if (Fundacoes != null && Tipo == "1")
            {
                foreach (var Fundacao in Fundacoes)
                {

                    if (Fundacao.Email == Email || Fundacao.Senha == Senha)
                    {
                        Session["AcessoF"] = Fundacao.Id;
                        return RedirectToAction("Index", "Fundacao");

                    }
                    else
                    {
                        Session["AcessoF"] = null;
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
                    return RedirectToAction("Index", "Administrador");
                }
                

            }

            return RedirectToAction("Index");
        }

    }   
}