using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PAR_INTRANET.Models.Clases.Tablas;
using PAR_INTRANET.Models.Contexto;

namespace PAR_INTRANET.Controllers
{
    public class EstadoSucursalesController : Controller
    {
        private CentralDBContexto db = new CentralDBContexto();

        // GET: EstadoSucursales
        public ActionResult Index()
        {
            ViewBag.FechaHora = DateTime.Now;
            return View(db.EstadoSucursales.ToList());
        }

        // GET: EstadoSucursales/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoSucursal estadoSucursal = db.EstadoSucursales.Find(id);
            if (estadoSucursal == null)
            {
                return HttpNotFound();
            }
            return View(estadoSucursal);
        }

        // GET: EstadoSucursales/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstadoSucursales/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodSuc,TXUltimaActualizacion,TXUltimaConsulta,TXEstado,TXError,TXUltimaActualizacionCentral,TXUltimaConsultaCentral,TXEstadoCentral,IBBAUltimaActualizacion,IBBAUltimaConsulta,IBBAError")] EstadoSucursal estadoSucursal)
        {
            if (ModelState.IsValid)
            {
                db.EstadoSucursales.Add(estadoSucursal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estadoSucursal);
        }

        // GET: EstadoSucursales/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoSucursal estadoSucursal = db.EstadoSucursales.Find(id);
            if (estadoSucursal == null)
            {
                return HttpNotFound();
            }
            return View(estadoSucursal);
        }

        // POST: EstadoSucursales/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodSuc,TXUltimaActualizacion,TXUltimaConsulta,TXEstado,TXError,TXUltimaActualizacionCentral,TXUltimaConsultaCentral,TXEstadoCentral,IBBAUltimaActualizacion,IBBAUltimaConsulta,IBBAError")] EstadoSucursal estadoSucursal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estadoSucursal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estadoSucursal);
        }

        // GET: EstadoSucursales/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoSucursal estadoSucursal = db.EstadoSucursales.Find(id);
            if (estadoSucursal == null)
            {
                return HttpNotFound();
            }
            return View(estadoSucursal);
        }

        // POST: EstadoSucursales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            EstadoSucursal estadoSucursal = db.EstadoSucursales.Find(id);
            db.EstadoSucursales.Remove(estadoSucursal);
            db.SaveChanges();
            return RedirectToAction("Index");
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
