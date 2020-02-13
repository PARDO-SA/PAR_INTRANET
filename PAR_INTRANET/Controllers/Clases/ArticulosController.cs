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

namespace PAR_INTRANET.Controllers.Clases
{
    public class ArticulosController : Controller
    {
        private readonly CentralDBContexto db = new CentralDBContexto();

        //// GET: Articulos
        //public ActionResult Index()
        //{
        //    var articuloes = db.Articuloes.Include(a => a.Nivel1).Include(a => a.Nivel2);
        //    return View(articuloes.ToList());
        //}

        // GET: Articulos
        public ActionResult Search(string Search_Type, string Search_String)
        {
            if (Search_String == null)
            {
                var articulos = db.Articulos.Include(a => a.Nivel1).Include(a => a.Nivel2);
                return PartialView(articulos.ToList());
            }
            else
            {
                if (Search_Type == "CodArt")
                {
                    var articulos = db.Articulos.Include(a => a.Nivel1).Include(a => a.Nivel2).Include(a => a.Marca).Where(a => a.CodArt == Search_String);
                    return PartialView(articulos.ToList());
                }
                else if (Search_Type == "DesArt")
                {
                    //var accounts = db.Accounts
                    //.Include(a => a.Account_Type)
                    //.Include(a => a.Account_Person)
                    //.Where(b => b.Account_Person.Any(c => c.Person.Last_Name.StartsWith(Search_String)))
                    //.Include(a => a.Account_Contact)
                    //.Include(a => a.Account_Address);
                    //return PartialView(accounts.ToList());
                    var articulos = db.Articulos.Include(a => a.Nivel1).Include(a => a.Nivel2).Include(a => a.Marca).Where(a => a.DesArt.Contains(Search_String));
                    return PartialView(articulos.ToList());
                }
                //else if (Search_Type == "Nivel1")
                //{
                //    var accounts = db.Articulos
                //    .Include(a => a.Nivel1)
                //    .Where(b => b.CodNivArt1.Any(c => c.))
                //    .Include(a => a.Account_Person)
                //    .Include(a => a.Account_Contact)
                //    .Where(b => b.Account_Contact.Any(c => c.Contact.Value == Search_String && c.Contact.Contact_Type.Name.Contains("Phone")))
                //    .Include(a => a.Account_Address);
                //    return PartialView(accounts.ToList());
                //}
                else
                {
                    var articulos = db.Articulos.Include(a => a.Nivel1).Include(a => a.Nivel2).Include(a => a.Marca);
                    return PartialView(articulos.ToList());
                }
            }
        }

        // GET: Articulos/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articulo articulo = db.Articulos.Find(id);
            if (articulo == null)
            {
                return HttpNotFound();
            }
            return View(articulo);
        }

        //// GET: Articulos/Create
        //public ActionResult Create()
        //{
        //    ViewBag.CodNivArt1 = new SelectList(db.Rubroes, "CodNivArt1", "DesNivArt1");
        //    ViewBag.CodNivArt1 = new SelectList(db.SubRubroes, "CodNivArt1", "DesNivArt2");
        //    return View();
        //}

        //// POST: Articulos/Create
        //// Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        //// más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "CodArt,DesArt,CodNivArt1,CodNivArt2,CodEleRefArt")] Articulo articulo)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Articuloes.Add(articulo);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.CodNivArt1 = new SelectList(db.Rubroes, "CodNivArt1", "DesNivArt1", articulo.CodNivArt1);
        //    ViewBag.CodNivArt1 = new SelectList(db.SubRubroes, "CodNivArt1", "DesNivArt2", articulo.CodNivArt1);
        //    return View(articulo);
        //}

        //// GET: Articulos/Edit/5
        //public ActionResult Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Articulo articulo = db.Articuloes.Find(id);
        //    if (articulo == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.CodNivArt1 = new SelectList(db.Rubroes, "CodNivArt1", "DesNivArt1", articulo.CodNivArt1);
        //    ViewBag.CodNivArt1 = new SelectList(db.SubRubroes, "CodNivArt1", "DesNivArt2", articulo.CodNivArt1);
        //    return View(articulo);
        //}

        //// POST: Articulos/Edit/5
        //// Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        //// más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "CodArt,DesArt,CodNivArt1,CodNivArt2,CodEleRefArt")] Articulo articulo)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(articulo).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.CodNivArt1 = new SelectList(db.Rubroes, "CodNivArt1", "DesNivArt1", articulo.CodNivArt1);
        //    ViewBag.CodNivArt1 = new SelectList(db.SubRubroes, "CodNivArt1", "DesNivArt2", articulo.CodNivArt1);
        //    return View(articulo);
        //}

        //// GET: Articulos/Delete/5
        //public ActionResult Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Articulo articulo = db.Articuloes.Find(id);
        //    if (articulo == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(articulo);
        //}

        //// POST: Articulos/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    Articulo articulo = db.Articuloes.Find(id);
        //    db.Articuloes.Remove(articulo);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
