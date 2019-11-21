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
    public class estudiantesSetsController : Controller
    {
        private GHBbdEntities db = new GHBbdEntities();

        // GET: estudiantesSets
        public ActionResult Index()
        {
            return View(db.estudiantesSet.ToList());
        }

        // GET: estudiantesSets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            estudiantesSet estudiantesSet = db.estudiantesSet.Find(id);
            if (estudiantesSet == null)
            {
                return HttpNotFound();
            }
            return View(estudiantesSet);
        }

        // GET: estudiantesSets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: estudiantesSets/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Idestudiantes,materia,nombre")] estudiantesSet estudiantesSet)
        {
            if (ModelState.IsValid)
            {
                db.estudiantesSet.Add(estudiantesSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estudiantesSet);
        }

        // GET: estudiantesSets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            estudiantesSet estudiantesSet = db.estudiantesSet.Find(id);
            if (estudiantesSet == null)
            {
                return HttpNotFound();
            }
            return View(estudiantesSet);
        }

        // POST: estudiantesSets/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Idestudiantes,materia,nombre")] estudiantesSet estudiantesSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estudiantesSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estudiantesSet);
        }

        // GET: estudiantesSets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            estudiantesSet estudiantesSet = db.estudiantesSet.Find(id);
            if (estudiantesSet == null)
            {
                return HttpNotFound();
            }
            return View(estudiantesSet);
        }

        // POST: estudiantesSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            estudiantesSet estudiantesSet = db.estudiantesSet.Find(id);
            db.estudiantesSet.Remove(estudiantesSet);
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
