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
    public class eventosSetsController : Controller
    {
        private GHBbdEntities db = new GHBbdEntities();

        // GET: eventosSets
        public ActionResult Index()
        {
            return View(db.eventosSet.ToList());
        }

        // GET: eventosSets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            eventosSet eventosSet = db.eventosSet.Find(id);
            if (eventosSet == null)
            {
                return HttpNotFound();
            }
            return View(eventosSet);
        }

        // GET: eventosSets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: eventosSets/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Ideventos,evento,hora,fecha")] eventosSet eventosSet)
        {
            if (ModelState.IsValid)
            {
                db.eventosSet.Add(eventosSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eventosSet);
        }

        // GET: eventosSets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            eventosSet eventosSet = db.eventosSet.Find(id);
            if (eventosSet == null)
            {
                return HttpNotFound();
            }
            return View(eventosSet);
        }

        // POST: eventosSets/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Ideventos,evento,hora,fecha")] eventosSet eventosSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventosSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eventosSet);
        }

        // GET: eventosSets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            eventosSet eventosSet = db.eventosSet.Find(id);
            if (eventosSet == null)
            {
                return HttpNotFound();
            }
            return View(eventosSet);
        }

        // POST: eventosSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            eventosSet eventosSet = db.eventosSet.Find(id);
            db.eventosSet.Remove(eventosSet);
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
