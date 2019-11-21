using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GitHub.Models;

namespace GitHub.Controllers
{
    public class grupo1Controller : Controller
    {
        private GHBbdEntities db = new GHBbdEntities();

        // GET: grupo1
        public ActionResult Index()
        {
            return View(db.grupo1.ToList());
        }

        // GET: grupo1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            grupo1 grupo1 = db.grupo1.Find(id);
            if (grupo1 == null)
            {
                return HttpNotFound();
            }
            return View(grupo1);
        }

        // GET: grupo1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: grupo1/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre_del_estudiante,Materias,Cuatromestres_cursados")] grupo1 grupo1)
        {
            if (ModelState.IsValid)
            {
                db.grupo1.Add(grupo1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(grupo1);
        }

        // GET: grupo1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            grupo1 grupo1 = db.grupo1.Find(id);
            if (grupo1 == null)
            {
                return HttpNotFound();
            }
            return View(grupo1);
        }

        // POST: grupo1/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre_del_estudiante,Materias,Cuatromestres_cursados")] grupo1 grupo1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grupo1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(grupo1);
        }

        // GET: grupo1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            grupo1 grupo1 = db.grupo1.Find(id);
            if (grupo1 == null)
            {
                return HttpNotFound();
            }
            return View(grupo1);
        }

        // POST: grupo1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            grupo1 grupo1 = db.grupo1.Find(id);
            db.grupo1.Remove(grupo1);
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
