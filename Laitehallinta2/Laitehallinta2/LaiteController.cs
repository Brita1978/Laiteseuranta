﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Laitehallinta2
{
    public class LaiteController : Controller
    {
        private SeurantaEntities db = new SeurantaEntities();

        // GET: Laite
        public ActionResult Index()
        {
            return View(db.Laitteet.ToList());
        }

        // GET: Laite/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Laitteet laitteet = db.Laitteet.Find(id);
            if (laitteet == null)
            {
                return HttpNotFound();
            }
            return View(laitteet);
        }

        // GET: Laite/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Laite/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LaiteID,Sarjanumero,Merkki,Malli,Muuta")] Laitteet laitteet)
        {
            if (ModelState.IsValid)
            {
                db.Laitteet.Add(laitteet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(laitteet);
        }

        // GET: Laite/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Laitteet laitteet = db.Laitteet.Find(id);
            if (laitteet == null)
            {
                return HttpNotFound();
            }
            return View(laitteet);
        }

        // POST: Laite/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LaiteID,Sarjanumero,Merkki,Malli,Muuta")] Laitteet laitteet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(laitteet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(laitteet);
        }

        // GET: Laite/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Laitteet laitteet = db.Laitteet.Find(id);
            if (laitteet == null)
            {
                return HttpNotFound();
            }
            return View(laitteet);
        }

        // POST: Laite/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Laitteet laitteet = db.Laitteet.Find(id);
            db.Laitteet.Remove(laitteet);
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
