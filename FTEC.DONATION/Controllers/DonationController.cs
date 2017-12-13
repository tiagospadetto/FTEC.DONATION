using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FTEC.DONATION.Models;
using FTEC.DONATION.INFRA.REPOSITORIO;
using FTEC.DONATION.DOMINIO.Entidade;

namespace FTEC.DONATION.Controllers
{
    public class DonationController : Controller
    {   
        private string strConexao = "Server=localhost; Port=5432; Database=projeto; User Id = postgres; Password = 12345; ";
        // GET: Donation
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SelectCad(String teste)
        {
            if (teste == "2")
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
            Funcacao fund = new Funcacao();

            fund.Id     = fundacao.Id;
            fund.Nome   = fundacao.Nome;
            fund.Tipo   = fundacao.Tipo;
            fund.Email  = fundacao.Email;
            fund.Senha  = fundacao.Senha;

            FundacaoRepositorio fundacaoRepositorio = new FundacaoRepositorio(strConexao);

            fundacaoRepositorio.Inserir(fund, "aprovar");

            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult NovoVoluntario(Voluntario voluntario)
        {
            EVoluntario volunt = new EVoluntario();

            volunt.Id        = voluntario.Id;
            volunt.Nome      = voluntario.Nome;
            volunt.Sobrenome = voluntario.Sobrenome;
            volunt.Sexo      = voluntario.Sexo;
            volunt.Email     = voluntario.Email;
            volunt.Senha     = voluntario.Senha;


            VoluntarioRepositorio voluntarioRepositorio = new VoluntarioRepositorio(strConexao);


            voluntarioRepositorio.Inserir(volunt);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Autenticar(String Tipo, String Email, String Senha)
        {
            List<EVoluntario> Voluntarios;
            List<Funcacao> Fundacoes;

            AdmRepositorio adminRepositorio = new AdmRepositorio(strConexao);
            FundacaoRepositorio fundacaoRepositorio = new FundacaoRepositorio(strConexao);
            VoluntarioRepositorio voluntarioRepositorio = new VoluntarioRepositorio(strConexao);

            Funcacao fund = new Funcacao();


            Voluntarios = voluntarioRepositorio.List();
            Fundacoes = fundacaoRepositorio.ListarAprovadas();

            if (Voluntarios != null && Tipo == "2")
            {
                EVoluntario voluntario = new EVoluntario();

                voluntario = voluntarioRepositorio.Acesso(Email, Senha);


                    if (voluntario.Email == Email)
                    {
                        Session["Usuario"] = voluntario.Id;
                        return RedirectToAction("Index", "Voluntario");

                    }
                    else
                    {
                        Session["Usuario"] = null;
                        return JavaScript("<script>alert(\"método CarregarGrid()\")</script>");
                    }


                
            }
            if (Fundacoes != null && Tipo == "1")
            {
                fund = fundacaoRepositorio.Acesso(Email, Senha);

                    if (fund.Email != null )
                    {
                        Session["AcessoF"] = fund.Id;
                        return RedirectToAction("Index", "Fundacao");

                    }
                    else
                    {
                        Session["AcessoF"] = null;
                        return JavaScript("<script>alert(\"método CarregarGrid()\")</script>");
                    }

            }
            if (Tipo == "3")
            {
                

                

                FTEC.DONATION.DOMINIO.Entidade.Adm admin = new FTEC.DONATION.DOMINIO.Entidade.Adm();

                admin = adminRepositorio.ValidAdm(Email,Senha);

                if (admin.Email != null )
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