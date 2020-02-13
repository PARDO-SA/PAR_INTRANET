using PAR_INTRANET.Models.Clases.Vtex;
using PAR_INTRANET.Models.Contexto;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace PAR_INTRANET.Controllers.Clases
{
    public class VtexOrdersController : Controller
    {
        private DepositoDBContexto db = new DepositoDBContexto();

        // GET: VtexOrders
        public ActionResult Index()
        {
            return View(db.VtexOrders.ToList());
        }

        // GET: VtexOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VtexOrder vtexOrder = db.VtexOrders.Find(id);
            if (vtexOrder == null)
            {
                return HttpNotFound();
            }
            return View(vtexOrder);
        }

        // GET: VtexOrders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VtexOrders/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VTexOrderId,OrderId,OrderDate,CodTipDoc,DocumentType,NroDocCli,NomCli,NomCliWeb,DomCli,DomCliEnv,IVASujeto,Email,CodLocCli,CodPosCli,Tel1Cli,CodPosEnv,CodLocEnv,ImpTotCbt,ImpTotFle,CourierID,CourierName,CodSuc,CodAlm,DownloadDate,Json,CSIDNotVen,CSIDVta,Status,InvoiceNotificationStatus,InvoiceNotificationDate,TrackingUrl,DesLocCli,DesProvCli,DesLocEnv,DesProvEnv")] VtexOrder vtexOrder)
        {
            if (ModelState.IsValid)
            {
                db.VtexOrders.Add(vtexOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vtexOrder);
        }

        // GET: VtexOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VtexOrder vtexOrder = db.VtexOrders.Find(id);
            if (vtexOrder == null)
            {
                return HttpNotFound();
            }
            return View(vtexOrder);
        }

        // POST: VtexOrders/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VTexOrderId,OrderId,OrderDate,CodTipDoc,DocumentType,NroDocCli,NomCli,NomCliWeb,DomCli,DomCliEnv,IVASujeto,Email,CodLocCli,CodPosCli,Tel1Cli,CodPosEnv,CodLocEnv,ImpTotCbt,ImpTotFle,CourierID,CourierName,CodSuc,CodAlm,DownloadDate,Json,CSIDNotVen,CSIDVta,Status,InvoiceNotificationStatus,InvoiceNotificationDate,TrackingUrl,DesLocCli,DesProvCli,DesLocEnv,DesProvEnv")] VtexOrder vtexOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vtexOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vtexOrder);
        }

        // GET: VtexOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VtexOrder vtexOrder = db.VtexOrders.Find(id);
            if (vtexOrder == null)
            {
                return HttpNotFound();
            }
            return View(vtexOrder);
        }

        // POST: VtexOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VtexOrder vtexOrder = db.VtexOrders.Find(id);
            db.VtexOrders.Remove(vtexOrder);
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
