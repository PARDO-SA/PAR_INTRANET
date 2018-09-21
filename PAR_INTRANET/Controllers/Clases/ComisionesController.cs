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
            return View(db.Comisiones.ToList());
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
            return View();
        }

        // POST: Comisiones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdComi,DesComi,FecVigDesComi,FecVigHasComi,CodNivArt1Comi,CodNivArt2Comi,CodNivArt3Comi,MarcaComi,ArtIncComi,ArtExcComi,VendeComi,ImpComi,PorComi,RestoComi,ImpRestoComi,PorRestoComi,Inactivo,IdFuncion")] Comision comision)
        {
            if (ModelState.IsValid)
            {
                db.Comisiones.Add(comision);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

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
            return View(comision);
        }

        // POST: Comisiones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdComi,DesComi,FecVigDesComi,FecVigHasComi,CodNivArt1Comi,CodNivArt2Comi,CodNivArt3Comi,MarcaComi,ArtIncComi,ArtExcComi,VendeComi,ImpComi,PorComi,RestoComi,ImpRestoComi,PorRestoComi,Inactivo,IdFuncion")] Comision comision)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comision).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
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
