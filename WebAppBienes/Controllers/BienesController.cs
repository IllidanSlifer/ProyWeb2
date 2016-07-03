using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IdentitySample.Models;
using WebAppBienes.Models;

namespace WebAppBienes.Controllers
{
    public class BienesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Bienes
        public ActionResult Index()
        {
            return View(db.Bienes.ToList());
        }

        // GET: Bienes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BienesModel bienesModel = db.Bienes.Find(id);
            if (bienesModel == null)
            {
                return HttpNotFound();
            }
            return View(bienesModel);
        }

        // GET: Bienes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bienes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FolioReal,AreaTerreno,Ubicacion,Precio,Financiamiento,FrenteTerreno,FondoTerreno,TopografiaTerreno,UsoSuelo,Descripcion,AreaConstrucción")] BienesModel bienesModel)
        {
            if (ModelState.IsValid)
            {
                db.Bienes.Add(bienesModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bienesModel);
        }

        // GET: Bienes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BienesModel bienesModel = db.Bienes.Find(id);
            if (bienesModel == null)
            {
                return HttpNotFound();
            }
            return View(bienesModel);
        }

        // POST: Bienes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FolioReal,AreaTerreno,Ubicacion,Precio,Financiamiento,FrenteTerreno,FondoTerreno,TopografiaTerreno,UsoSuelo,Descripcion,AreaConstrucción")] BienesModel bienesModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bienesModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bienesModel);
        }

        // GET: Bienes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BienesModel bienesModel = db.Bienes.Find(id);
            if (bienesModel == null)
            {
                return HttpNotFound();
            }
            return View(bienesModel);
        }

        // POST: Bienes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BienesModel bienesModel = db.Bienes.Find(id);
            db.Bienes.Remove(bienesModel);
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
