﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PAR_INTRANET.Models.Clases.Tablas;
using PAR_INTRANET.Models.Contexto;

namespace PAR_INTRANET.Controllers.Clases
{
    public class EstadoSucursalesController : Controller
    {
        private readonly CentralDBContexto db = new CentralDBContexto();

        // GET: EstadoSucursales
        public ActionResult Index()
        {
            ViewBag.FechaHora = DateTime.Now;
            return View();
        }

        public ActionResult MostrarEstados()
        {
            var estados = db.EstadoSucursales.ToList();
            return PartialView("_MostrarEstados", estados);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
