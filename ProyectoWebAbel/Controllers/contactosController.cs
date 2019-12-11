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
    public class contactosController : Controller
    {
        private abelwebEntities db = new abelwebEntities();

        // GET: contactos
        public ActionResult Index()
        {
            return View(db.contactos.ToList());
        }

        // GET: contactos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contactos contactos = db.contactos.Find(id);
            if (contactos == null)
            {
                return HttpNotFound();
            }
            return View(contactos);
        }

        // GET: contactos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: contactos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "contactoId,nombre,apellido,identidad,fecha_creacion")] contactos contactos)
        {
            if (ModelState.IsValid)
            {
                db.contactos.Add(contactos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contactos);
        }

        // GET: contactos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contactos contactos = db.contactos.Find(id);
            if (contactos == null)
            {
                return HttpNotFound();
            }
            return View(contactos);
        }

        // POST: contactos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "contactoId,nombre,apellido,identidad,fecha_creacion")] contactos contactos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contactos);
        }

        // GET: contactos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contactos contactos = db.contactos.Find(id);
            if (contactos == null)
            {
                return HttpNotFound();
            }
            return View(contactos);
        }

        // POST: contactos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            contactos contactos = db.contactos.Find(id);
            db.contactos.Remove(contactos);
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
