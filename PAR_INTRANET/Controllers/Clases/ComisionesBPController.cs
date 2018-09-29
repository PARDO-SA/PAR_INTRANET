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
using PAR_INTRANET.Models.Vistas;

namespace PAR_INTRANET.Controllers
{
    public class ComisionesBPController : Controller
    {
        private CentralDBContexto db = new CentralDBContexto();

        // GET: ComisionesBP
        public ActionResult Resumen(string periodo, string sucursal)
        {
            if (Session["Codusr"] != null)
            {
                var context = new CentralDBContexto();
                var query = @"SELECT sucursal = CONVERT(int, x.codsuc), x.nombre, x.email, puntos = ROUND(SUM(puntos),0)
FROM (
    SELECT c.codsuc, e.codven, e.email, e.nombre, puntos = SUM(c.comisionven)
    FROM PAR_ComisionesBP c
    LEFT JOIN PAR_Emple e ON e.codven = c.codven
    WHERE c.periodo = @p0
    AND e.inactivo = 0
    AND e.funcionp = 'Vendedor'
    GROUP BY e.email, e.nombre, c.codsuc, e.codven
    UNION
    SELECT c.codsuc, e.codven, e.email, e.nombre, puntos = SUM(c.comisionsuc / ce.cantidad)
    FROM PAR_ComisionesBP c
    LEFT JOIN PAR_Emple e ON e.codsuc = c.codsuc
    LEFT JOIN(SELECT codsuc, cantidad = SUM(CASE WHEN rtrim(funcionp) <> 'Vendedor' OR(rtrim(funcionp) = 'Vendedor' AND rtrim(funcions) <> '') THEN 1 ELSE 0 END) FROM PAR_Emple WHERE inactivo = 0 GROUP BY codsuc) ce ON ce.codsuc = c.codsuc
    WHERE c.periodo = @p0
    AND e.inactivo = 0
    AND(rtrim(e.funcionp) <> 'Vendedor' OR(rtrim(e.funcionp) = 'Vendedor' AND rtrim(e.funcions) <> ''))
    GROUP BY e.email, e.nombre, c.codsuc, e.codven
) x
GROUP BY x.codsuc, x.nombre, x.email
ORDER BY x.codsuc, x.nombre";

                var querysuc = @"SELECT sucursal = CONVERT(int, x.codsuc), x.nombre, x.email, puntos = ROUND(SUM(puntos),0)
FROM (
    SELECT c.codsuc, e.codven, e.email, e.nombre, puntos = SUM(c.comisionven)
    FROM PAR_ComisionesBP c
    LEFT JOIN PAR_Emple e ON e.codven = c.codven
    WHERE c.periodo = @p0
    AND c.codsuc = @p1
    AND e.inactivo = 0
    AND e.funcionp = 'Vendedor'
    GROUP BY e.email, e.nombre, c.codsuc, e.codven
    UNION
    SELECT c.codsuc, e.codven, e.email, e.nombre, puntos = SUM(c.comisionsuc / ce.cantidad)
    FROM PAR_ComisionesBP c
    LEFT JOIN PAR_Emple e ON e.codsuc = c.codsuc
    LEFT JOIN(SELECT codsuc, cantidad = SUM(CASE WHEN rtrim(funcionp) <> 'Vendedor' OR(rtrim(funcionp) = 'Vendedor' AND rtrim(funcions) <> '') THEN 1 ELSE 0 END) FROM PAR_Emple WHERE inactivo = 0 GROUP BY codsuc) ce ON ce.codsuc = c.codsuc
    WHERE c.periodo = @p0
    AND c.codsuc = @p1
    AND e.inactivo = 0
    AND(rtrim(e.funcionp) <> 'Vendedor' OR(rtrim(e.funcionp) = 'Vendedor' AND rtrim(e.funcions) <> ''))
    GROUP BY e.email, e.nombre, c.codsuc, e.codven
) x
GROUP BY x.codsuc, x.nombre, x.email
ORDER BY x.codsuc, x.nombre";

                var PeriodoLst = new List<string>();
                var PeriodoQry = from p in db.ComisionesBPs orderby p.Periodo select p.Periodo;

                PeriodoLst.AddRange(PeriodoQry.Distinct());
                ViewBag.periodo = new SelectList(PeriodoLst);

                var SucursalLst = new List<string>();
                var SucursalQry = from e in db.Empleados orderby e.CodSuc select e.CodSuc;

                SucursalLst.AddRange(SucursalQry.Distinct());
                ViewBag.sucursal = new SelectList(SucursalLst);

                var resumenComisiones = new List<ViewResumenComisionesBP>();

                ViewBag.Total = 0;

                if (!string.IsNullOrEmpty(periodo))
                {
                    if (!string.IsNullOrEmpty(sucursal))
                    {
                        resumenComisiones = context.Database.SqlQuery<ViewResumenComisionesBP>(querysuc, periodo, sucursal).ToList();
                    }
                    else
                    {
                        resumenComisiones = context.Database.SqlQuery<ViewResumenComisionesBP>(query, periodo).ToList();
                    }
                    ViewBag.Total = resumenComisiones.Sum(x => x.Puntos);
                }

                return View(resumenComisiones);

            }
            else
            {
                return RedirectToAction("Logueo", "Login", null);
            }
           
        }

        // GET: ComisionesBP
        public ActionResult Index()
        {
            return View(db.ComisionesBPs.ToList());
        }

        // GET: ComisionesBP/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComisionesBP comisionesBP = db.ComisionesBPs.Find(id);
            if (comisionesBP == null)
            {
                return HttpNotFound();
            }
            return View(comisionesBP);
        }

        // GET: ComisionesBP/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ComisionesBP/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodSuc,CodVen,Recibo,Comprobante,Cuota,CodArt,Vendedor,FechaRec,ImporteRec,CodCli,DesArt,Porcentaje,ImporteArt,ComisionVen,ComisionSuc,Periodo")] ComisionesBP comisionesBP)
        {
            if (ModelState.IsValid)
            {
                db.ComisionesBPs.Add(comisionesBP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(comisionesBP);
        }

        // GET: ComisionesBP/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComisionesBP comisionesBP = db.ComisionesBPs.Find(id);
            if (comisionesBP == null)
            {
                return HttpNotFound();
            }
            return View(comisionesBP);
        }

        // POST: ComisionesBP/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodSuc,CodVen,Recibo,Comprobante,Cuota,CodArt,Vendedor,FechaRec,ImporteRec,CodCli,DesArt,Porcentaje,ImporteArt,ComisionVen,ComisionSuc,Periodo")] ComisionesBP comisionesBP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comisionesBP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(comisionesBP);
        }

        // GET: ComisionesBP/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComisionesBP comisionesBP = db.ComisionesBPs.Find(id);
            if (comisionesBP == null)
            {
                return HttpNotFound();
            }
            return View(comisionesBP);
        }

        // POST: ComisionesBP/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ComisionesBP comisionesBP = db.ComisionesBPs.Find(id);
            db.ComisionesBPs.Remove(comisionesBP);
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
