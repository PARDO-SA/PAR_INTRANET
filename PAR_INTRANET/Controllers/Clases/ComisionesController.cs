using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PAR_INTRANET.Models.Clases;
using PAR_INTRANET.Models.Contexto;

namespace PAR_INTRANET.Controllers.Clases
{
    public class ComisionesController : Controller
    {
        private CentralDBContexto db = new CentralDBContexto();

        // GET: Comisiones
        public ActionResult Index()
        {
            var comisiones = db.Comisiones; //.Include(c => c.FuncionComi);
            return View(comisiones.ToList());
        }

        // GET: Comisiones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comision comision = db.Comisiones.Find(id);
            if (comision == null)
            {
                return HttpNotFound();
            }
            return View(comision);
        }

        // GET: Comisiones/Create
        public ActionResult Create()
        {
            ViewBag.IdFuncion = new SelectList(db.FuncionesComisiones, "IdFuncion", "DesFuncion");
            ViewBag.CodNivArt1 = new SelectList(db.Rubros, "CodNivArt1", "DesNivArt1");
            ViewBag.CodEleRefArt = new SelectList(db.Marcas, "CodEleRefArt", "DesEleRefArt");
            return View();
        }

        // POST: Comisiones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdComi,DesComi,FecVigDesComi,FecVigHasComi,CodNivArt1,CodNivArt2,CodNivArt3,CodeleRefArt,ArtIncComi,ArtExcComi,VendeComi,ImpComi,PorComi,RestoComi,ImpRestoComi,PorRestoComi,Inactivo,IdFuncion")] Comision comision)
        {
            if (ModelState.IsValid)
            {
                db.Comisiones.Add(comision);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdFuncion = new SelectList(db.FuncionesComisiones, "IdFuncion", "DesFuncion", comision.IdFuncion);
            ViewBag.CodNivArt1 = new SelectList(db.Rubros, "CodNivArt1", "DesNivArt1", comision.CodNivArt1);
            ViewBag.CodEleRefArt = new SelectList(db.Marcas, "CodEleRefArt", "DesEleRefArt", comision.CodEleRefArt);

            return View(comision);
        }

        // GET: Comisiones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comision comision = db.Comisiones.Find(id);
            if (comision == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdFuncion = new SelectList(db.FuncionesComisiones, "IdFuncion", "DesFuncion", comision.IdFuncion);
            ViewBag.CodNivArt1 = new SelectList(db.Rubros, "CodNivArt1", "DesNivArt1", comision.CodNivArt1);
            ViewBag.CodEleRefArt = new SelectList(db.Marcas, "CodEleRefArt", "DesEleRefArt", comision.CodEleRefArt);
            return View(comision);
        }

        // POST: Comisiones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdComi,DesComi,FecVigDesComi,FecVigHasComi,CodNivArt1,CodNivArt2,CodNivArt3,CodeleRefArt,ArtIncComi,ArtExcComi,VendeComi,ImpComi,PorComi,RestoComi,ImpRestoComi,PorRestoComi,Inactivo,IdFuncion")] Comision comision)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comision).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdFuncion = new SelectList(db.FuncionesComisiones, "IdFuncion", "DesFuncion", comision.IdFuncion);
            ViewBag.CodNivArt1 = new SelectList(db.Rubros, "CodNivArt1", "DesNivArt1", comision.CodNivArt1);
            ViewBag.CodEleRefArt = new SelectList(db.Marcas, "CodEleRefArt", "DesEleRefArt", comision.CodEleRefArt);
            return View(comision);
        }

        // GET: Comisiones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comision comision = db.Comisiones.Find(id);
            if (comision == null)
            {
                return HttpNotFound();
            }
            return View(comision);
        }

        // POST: Comisiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comision comision = db.Comisiones.Find(id);
            db.Comisiones.Remove(comision);
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
