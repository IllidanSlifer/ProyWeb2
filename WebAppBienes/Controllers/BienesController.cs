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
using System.Web.Helpers;

namespace WebAppBienes.Controllers
{
    public class BienesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Bienes
        [Authorize]
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
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bienes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FolioReal,AreaTerreno,Ubicacion,Precio,Financiamiento,FrenteTerreno,FondoTerreno,TopografiaTerreno,UsoSuelo,Descripcion,AreaConstrucción,Image")] BienesModel bienesModel)
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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

        public ActionResult Enviar(int? id, string folioReal, double areaTerreno, string ubicacion, double precio, string financiamiento, string frenteTerreno, string fondoTerreno, string topografiaTerreno, string usoSuelo, string descripcion, double areaConstruccion)
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
            //Dim ElUser As MembershipUser;
            //ElUser = Membership.GetUser();
            //Men.Text = ElUser.UserName;
            string userName = HttpContext.User.Identity.Name;
            var eMailSent = true;
            var eMailSubject = folioReal + ", " + ubicacion + ", " + areaTerreno + "m2";
            if (eMailSubject == null)
            {
                eMailSubject = "Asunto vacío";
            }
            var eMailMessage = "Area del Terreno: " + areaTerreno + " m2" + Environment.NewLine + "Ubicacion: " + ubicacion + Environment.NewLine + "Precio: " + precio + Environment.NewLine + "Financiamiento: " + financiamiento + Environment.NewLine + "Frente del Terreno: " + frenteTerreno + " m2" + Environment.NewLine + "Fondo del terreno: " + fondoTerreno + " m2" + Environment.NewLine + "Topografia del terreno" + topografiaTerreno + Environment.NewLine + "Uso del suelo: " + usoSuelo + Environment.NewLine + "Descripcion: " + descripcion + Environment.NewLine + "Area de construccion: " + areaConstruccion + " m2" + Environment.NewLine;
            if (eMailMessage == null)
            {
                eMailMessage = "Mensaje vacío";
            }

            WebMail.SmtpServer = "smtp.live.com";
            WebMail.SmtpPort = 587;
            WebMail.EnableSsl = true;
            WebMail.UserName = "chacon9595@hotmail.com";
            WebMail.From = "KeroSellS@NoReplays.com";
            WebMail.Password = "Rtchacon";
            WebMail.Send(to: userName, subject: eMailSubject, body: eMailMessage);
            return View(bienesModel);
        }
    }
}
