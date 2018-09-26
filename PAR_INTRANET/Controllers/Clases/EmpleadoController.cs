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
    public class EmpleadoController : Controller
    {
        private CentralDBContexto db = new CentralDBContexto();

        // GET: Empleado
        public ActionResult Index()
        {
                ViewBag.Zona = 41;
                var empleados = db.Empleados;//.Include(e => e.FPrincipal);
                return View(empleados.ToList());

        }

        // GET: Empleado/Details/5
        public ActionResult Details(int id)
        {

            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleados.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.activo = "ACTIVO";
            ViewBag.inactivo = "INACTIVO";
            return View(empleado);

        }

        // GET: Empleado/Create
        public ActionResult Create()
        {
            ViewBag.CodSuc = new SelectList(db.Sucursales, "CodSuc", "dessuc");
            ViewBag.FuncionP = new SelectList(db.Funciones, "id", "descripcion");
            ViewBag.FuncionS = new SelectList(db.Funciones, "id", "descripcion");

            return View();
        }

        // POST: Empleado/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
               
                db.Empleados.Add(empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodSuc = new SelectList(db.Sucursales, "CodSuc", "dessuc", empleado.CodSuc);
            ViewBag.FuncionP = new SelectList(db.Funciones, "id", "descripcion", empleado.FuncionP);
            ViewBag.FuncionS = new SelectList(db.Funciones, "id", "descripcion", empleado.FuncionS);
            return View(empleado);
        }

        // GET: Empleado/Edit/5
        public ActionResult Edit(int id)
        {

            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleados.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }

            ViewBag.CodSuc = new SelectList(db.Sucursales, "CodSuc", "dessuc", empleado.CodSuc);
            ViewBag.FuncionP = new SelectList(db.Funciones, "id", "descripcion", empleado.FuncionP);
            ViewBag.FuncionS = new SelectList(db.Funciones, "id", "descripcion", empleado.FuncionS);
            return View(empleado);
                 
        }

        // POST: Empleado/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Legajo,Email,Nombre,Cuil,FuncionP,FuncionS,CodVen,CodSuc,Inactivo")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {

                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodSuc = new SelectList(db.Sucursales, "CodSuc", "dessuc", empleado.CodSuc);
            ViewBag.FuncionP = new SelectList(db.Funciones, "id", "descripcion", empleado.FuncionP);
            ViewBag.FuncionS = new SelectList(db.Funciones, "id", "descripcion", empleado.FuncionS);
            return View(empleado);
        }

        // GET: Empleado/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleados.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.activo = "ACTIVO";
            ViewBag.inactivo = "INACTIVO";
            return View(empleado);
            
        }

        // POST: Empleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleado empleado = db.Empleados.Find(id);
            db.Empleados.Remove(empleado);
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