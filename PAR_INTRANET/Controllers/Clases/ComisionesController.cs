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
            var comisiones = db.Comisiones.Include(c => c.Nivel1).Include(c => c.Nivel2).Include(c => c.RefArt).Include(c => c.Marca);
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
            ViewBag.activo = "ACTIVO";
            ViewBag.inactivo = "INACTIVO";
            return View(comision);
        }

        // GET: Comisiones/Create
        public ActionResult Create()
        {
            ViewBag.CodRefArt = new SelectList(db.Marcas, "CodRefArt", "DesEleRefArt");
            ViewBag.CodNivArt1 = new SelectList(db.Rubros, "CodNivArt1", "DesNivArt1");
            ViewBag.CodNivArt1 = new SelectList(db.SubRubros, "CodNivArt1", "DesNivArt2");
            ViewBag.CodRefArt = new SelectList(db.RefArts, "CodRefArt", "DesEleRefArt");
            return View();
        }

        // POST: Comisiones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdComi,DesComi,FecVigDesComi,FecVigHasComi,CodNivArt1,CodNivArt2,CodNivArt3,CodRefArt,CodeleRefArt,ArtIncComi,ArtExcComi,VendeComi,ImpComi,PorComi,RestoComi,ImpRestoComi,PorRestoComi,Inactivo,IdFuncion")] Comision comision)
        {
            if (ModelState.IsValid)
            {
                db.Comisiones.Add(comision);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodRefArt = new SelectList(db.Marcas, "CodRefArt", "DesEleRefArt", comision.CodRefArt);
            ViewBag.CodNivArt1 = new SelectList(db.Rubros, "CodNivArt1", "DesNivArt1", comision.CodNivArt1);
            ViewBag.CodNivArt1 = new SelectList(db.SubRubros, "CodNivArt1", "DesNivArt2", comision.CodNivArt1);
            ViewBag.CodRefArt = new SelectList(db.RefArts, "CodRefArt", "DesEleRefArt", comision.CodRefArt);
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
            ViewBag.CodRefArt = new SelectList(db.Marcas, "CodRefArt", "DesEleRefArt", comision.CodRefArt);
            ViewBag.CodNivArt1 = new SelectList(db.Rubros, "CodNivArt1", "DesNivArt1", comision.CodNivArt1);
            ViewBag.CodNivArt1 = new SelectList(db.SubRubros, "CodNivArt1", "DesNivArt2", comision.CodNivArt1);
            ViewBag.CodRefArt = new SelectList(db.RefArts, "CodRefArt", "DesEleRefArt", comision.CodRefArt);
            return View(comision);
        }

        // POST: Comisiones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdComi,DesComi,FecVigDesComi,FecVigHasComi,CodNivArt1,CodNivArt2,CodNivArt3,CodRefArt,CodeleRefArt,ArtIncComi,ArtExcComi,VendeComi,ImpComi,PorComi,RestoComi,ImpRestoComi,PorRestoComi,Inactivo,IdFuncion")] Comision comision)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comision).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodRefArt = new SelectList(db.Marcas, "CodRefArt", "DesEleRefArt", comision.CodRefArt);
            ViewBag.CodNivArt1 = new SelectList(db.Rubros, "CodNivArt1", "DesNivArt1", comision.CodNivArt1);
            ViewBag.CodNivArt1 = new SelectList(db.SubRubros, "CodNivArt1", "DesNivArt2", comision.CodNivArt1);
            ViewBag.CodRefArt = new SelectList(db.RefArts, "CodRefArt", "DesEleRefArt", comision.CodRefArt);
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
