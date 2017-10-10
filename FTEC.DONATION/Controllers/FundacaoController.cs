﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FTEC.DONATION.Filtro;

namespace FTEC.DONATION.Controllers
{   
    [FiltroFundacao]
    public class FundacaoController : Controller
    {
        // GET: Fundacao
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Novo()
        {
            return View();
        }
    }
}