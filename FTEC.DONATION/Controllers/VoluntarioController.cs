﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FTEC.DONATION.Models;
using FTEC.DONATION.Controllers;
using FTEC.DONATION.Filtro;

namespace FTEC.DONATION.Controllers
{
    [FiltroAcesso]
    public class VoluntarioController : Controller
    {
        // GET: Vonluntario
        [FiltroAcesso]
        public ActionResult Index()
        {
            List<Voluntario> Voluntarios;
            Guid Voluntario = new Guid();


            if(Session["Usuario"] != null)
            {
                Voluntario = (Guid)Session["Usuario"];
            }
            

            Voluntarios = (List<Voluntario>)Session["voluntarios"];

            var voluntario = Voluntarios.Where(p => p.Id == Voluntario).FirstOrDefault();

            ViewBag.Voluntario = voluntario.Nome;

            return View();

        }
        public ActionResult Logout()
        {
            Session["Usuario"] = null;
            return RedirectToAction("Index", "Donation");
           
        }
    }
}