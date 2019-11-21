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
    public class grupo2Controller : Controller
    {
        private GHBbdEntities db = new GHBbdEntities();

        // GET: grupo2
        public ActionResult Index()
        {
            return View(db.grupo2.ToList());
        }

        // GET: grupo2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            grupo2 grupo2 = db.grupo2.Find(id);
            if (grupo2 == null)
            {
                return HttpNotFound();
            }
            return View(grupo2);
        }

        // GET: grupo2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: grupo2/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre_del_estudiante,Materias,Cuatrimestres_cursados")] grupo2 grupo2)
        {
            if (ModelState.IsValid)
            {
                db.grupo2.Add(grupo2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(grupo2);
        }

        // GET: grupo2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            grupo2 grupo2 = db.grupo2.Find(id);
            if (grupo2 == null)
            {
                return HttpNotFound();
            }
            return View(grupo2);
        }

        // POST: grupo2/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre_del_estudiante,Materias,Cuatrimestres_cursados")] grupo2 grupo2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grupo2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(grupo2);
        }

        // GET: grupo2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            grupo2 grupo2 = db.grupo2.Find(id);
            if (grupo2 == null)
            {
                return HttpNotFound();
            }
            return View(grupo2);
        }

        // POST: grupo2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            grupo2 grupo2 = db.grupo2.Find(id);
            db.grupo2.Remove(grupo2);
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
