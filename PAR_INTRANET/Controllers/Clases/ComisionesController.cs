using PAR_INTRANET.Models;
using PAR_INTRANET.Models.Clases;
using PAR_INTRANET.Models.Clases.Tablas;
using PAR_INTRANET.Models.Contexto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace PAR_INTRANET.Controllers.Clases
{
    public class ComisionesController : Controller
    {
        private readonly CentralDBContexto db = new CentralDBContexto();
        private List<SelectListItem> _rubrosItems;
        public class ResumenComisionesQry
        {
            public string Sucursal { get; set; }
            public string Nombre { get; set; }
            public decimal Puntos { get; set; }
            public string Descripcion { get; set; }
        }
        public class ResumenComisionesCobQry
        {
            public string Sucursal { get; set; }
            public string Funcion { get; set; }
            public string Nombre { get; set; }
            public decimal Cobrado { get; set; }
            public decimal Comision_Ven { get; set; }
            public decimal Comision_Suc { get; set; }
            public decimal A_Cobrar_del_Mes { get; set; }
            public decimal Resta_Cobrar_del_Mes { get; set; }
        }

        // GET: Comisiones
        public ActionResult Index()
        {
            var comisiones = db.Comisiones.Include(c => c.Nivel1).Include(c => c.Nivel2).Include(c => c.RefArt).Include(c => c.Marca).Include(c => c.Articulos).Include(c => c.FuncionComi);
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
            var model = new Comision();

            ViewBag.FuncionComi = new SelectList(db.FuncionesComisiones, "IdFuncion", "DesFuncion");
            ViewBag.CodeleRefArt = new SelectList(db.Marcas, "CodeleRefArt", "DesEleRefArt");
            ViewBag.CodRefArt = new SelectList(db.RefArts, 1, "DesRefArt");

            // CARGAMOS EL DropDownList DE REGIONES
            var rubros = db.Rubros.ToList();
            _rubrosItems = new List<SelectListItem>();
            foreach (var item in rubros)
            {
                _rubrosItems.Add(new SelectListItem
                {
                    Text = item.DesNivArt1,
                    Value = item.CodNivArt1
                });
            }
            ViewBag.rubros = _rubrosItems;

            return View(model);
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

            ViewBag.CodeleRefArt = new SelectList(db.Marcas, "CodRefArt", "DesEleRefArt", comision.CodRefArt);
            ViewBag.CodNivArt1 = new SelectList(db.Rubros, "CodNivArt1", "DesNivArt1", comision.CodNivArt1);
            ViewBag.CodNivArt2 = new SelectList(db.SubRubros, "CodNivArt2", "DesNivArt2", comision.CodNivArt2);
            ViewBag.CodRefArt = new SelectList(db.RefArts, "CodRefArt", "DesRefArt", comision.CodRefArt);
            ViewBag.FuncionComi = new SelectList(db.FuncionesComisiones, "IdFuncion", "DesFuncion", comision.IdFuncion);

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
            ViewBag.CodRefArt = new SelectList(db.RefArts, "CodRefArt", "DesRefArt", comision.CodRefArt);
            ViewBag.FuncionComi = new SelectList(db.FuncionesComisiones, "IdFuncion", "DesFuncion", comision.IdFuncion);

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
            ViewBag.CodRefArt = new SelectList(db.RefArts, "CodRefArt", "DesRefArt", comision.CodRefArt);
            ViewBag.FuncionComi = new SelectList(db.FuncionesComisiones, "IdFuncion", "DesFuncion", comision.IdFuncion);

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

        public ActionResult Resumen(string anio, string mes)
        {
            if (mes == null || anio == null)
            {
                anio = DateTime.Now.Year.ToString();
                mes = DateTime.Now.Month.ToString().PadLeft(2, '0');
            }

            var meses = new List<SelectListItem>
            {
                new SelectListItem() { Value = "01", Text = "Enero" },
                new SelectListItem() { Value = "02", Text = "Febrero" },
                new SelectListItem() { Value = "03", Text = "Marzo" },
                new SelectListItem() { Value = "04", Text = "Abril" },
                new SelectListItem() { Value = "05", Text = "Mayo" },
                new SelectListItem() { Value = "06", Text = "Junio" },
                new SelectListItem() { Value = "07", Text = "Julio" },
                new SelectListItem() { Value = "08", Text = "Agosto" },
                new SelectListItem() { Value = "09", Text = "Septiembre" },
                new SelectListItem() { Value = "10", Text = "Octubre" },
                new SelectListItem() { Value = "11", Text = "Noviembre" },
                new SelectListItem() { Value = "12", Text = "Diciembre" }
            };

            var anios = new List<SelectListItem>();
            for (int i = 2018; i <= DateTime.Now.Year; i++)
            {
                anios.Add(new SelectListItem() { Value = i.ToString(), Text = i.ToString() });
            }

            ViewBag.lstmes = new SelectList(meses, "Value", "Text", mes);
            ViewBag.lstanio = new SelectList(anios, "Value", "Text", anio);

            var data = db.Database.SqlQuery<ResumenComisionesQry>("EXECUTE [dbo].[PAR_ViewComisiones] @anio, @mes", new SqlParameter("@anio", anio), new SqlParameter("@mes", mes)).ToArray();

            ViewData["PivotDataTable"] = data.ToPivotTableMultiple(
                          item => item.Descripcion,
                          item => new { item.Sucursal, item.Nombre },
                          items => items.Any() ? items.Sum(x => x.Puntos) : 0);

            return View();
        }

        public ActionResult ResumenCob(string anio, string mes)
        {
            if (mes == null || anio == null)
            {
                anio = DateTime.Now.Year.ToString();
                mes = DateTime.Now.Month.ToString().PadLeft(2, '0');
            }

            var meses = new List<SelectListItem>
            {
                new SelectListItem() { Value = "01", Text = "Enero" },
                new SelectListItem() { Value = "02", Text = "Febrero" },
                new SelectListItem() { Value = "03", Text = "Marzo" },
                new SelectListItem() { Value = "04", Text = "Abril" },
                new SelectListItem() { Value = "05", Text = "Mayo" },
                new SelectListItem() { Value = "06", Text = "Junio" },
                new SelectListItem() { Value = "07", Text = "Julio" },
                new SelectListItem() { Value = "08", Text = "Agosto" },
                new SelectListItem() { Value = "09", Text = "Septiembre" },
                new SelectListItem() { Value = "10", Text = "Octubre" },
                new SelectListItem() { Value = "11", Text = "Noviembre" },
                new SelectListItem() { Value = "12", Text = "Diciembre" }
            };

            var anios = new List<SelectListItem>();
            for (int i = 2018; i <= DateTime.Now.Year; i++)
            {
                anios.Add(new SelectListItem() { Value = i.ToString(), Text = i.ToString() });
            }

            ViewBag.lstmes = new SelectList(meses, "Value", "Text", mes);
            ViewBag.lstanio = new SelectList(anios, "Value", "Text", anio);

            var data = db.Database.SqlQuery<ResumenComisionesCobQry>("EXECUTE [dbo].[PAR_ViewComisionesCob] @anio, @mes", new SqlParameter("@anio", anio), new SqlParameter("@mes", mes)).ToArray();

            //ViewData["PivotDataTable"] = data.ToList();

            return View(data.ToList());
        }

        public JsonResult GetSubRubrosList(string rubro)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<SubRubro> subrubros = db.SubRubros.Where(x => x.CodNivArt1 == rubro).ToList();
            return Json(subrubros, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Procesar()
        {
            return View();
        }


        // GET: Comisiones/Edit/5
        public ActionResult AddArticulo(string tipo)
        {
            if (tipo == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComisionArticulo model = new ComisionArticulo
            {
                Tipo = tipo
            };

            return PartialView("AddArticulo", model);

        }
    }
}
