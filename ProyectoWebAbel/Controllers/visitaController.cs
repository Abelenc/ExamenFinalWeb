using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoWebAbel;

namespace ProyectoWebAbel.Controllers
{
    public class visitaController : Controller
    {
        private abelwebEntities db = new abelwebEntities();

        // GET: visita
        public ActionResult Index()
        {
            var visita = db.visita.Include(v => v.contactos);
            return View(visita.ToList());
        }

        // GET: visita/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            visita visita = db.visita.Find(id);
            if (visita == null)
            {
                return HttpNotFound();
            }
            return View(visita);
        }

        // GET: visita/Create
        public ActionResult Create()
        {
            ViewBag.contacto_id = new SelectList(db.contactos, "contactoId", "nombre");
            return View();
        }

        // POST: visita/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "visitaId,contacto_id,motivo,Fecha,Hora_entrada,Hora_salida,Nombre_completo")] visita visita)
        {
            if (ModelState.IsValid)
            {
                db.visita.Add(visita);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.contacto_id = new SelectList(db.contactos, "contactoId", "nombre", visita.contacto_id);
            return View(visita);
        }

        // GET: visita/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            visita visita = db.visita.Find(id);
            if (visita == null)
            {
                return HttpNotFound();
            }
            ViewBag.contacto_id = new SelectList(db.contactos, "contactoId", "nombre", visita.contacto_id);
            return View(visita);
        }

        // POST: visita/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "visitaId,contacto_id,motivo,Fecha,Hora_entrada,Hora_salida,Nombre_completo")] visita visita)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visita).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.contacto_id = new SelectList(db.contactos, "contactoId", "nombre", visita.contacto_id);
            return View(visita);
        }

        // GET: visita/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            visita visita = db.visita.Find(id);
            if (visita == null)
            {
                return HttpNotFound();
            }
            return View(visita);
        }

        // POST: visita/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            visita visita = db.visita.Find(id);
            db.visita.Remove(visita);
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
