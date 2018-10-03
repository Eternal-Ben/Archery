﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Archery.Data;
using Archery.Models;

namespace Archery.Areas.BackOffice.Controllers
{
    public class TournamentsController : Controller
    {
        private ArcheryDbContext db = new ArcheryDbContext();

        // GET: BackOffice/Tournaments
        public ActionResult Index()
        {
            return View(db.Tournaments.ToList());
        }

        // GET: BackOffice/Tournaments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tournament tournament = db.Tournaments.Include("Weapons").SingleOrDefault (SelectList<Weapon>ID); // à reprendre sur le git, puis faire la même chose pour la partie "edite"
            if (tournament == null)
            {
                return HttpNotFound();
            }
            return View(tournament);
        }

        // GET: BackOffice/Tournaments/Create
        public ActionResult Create()
        {
            MultiSelectList weaponsValues = new MultiSelectList(db.Weapons, "ID", "Name");
            ViewBag.Weapons = weaponsValues;
            return View();
        }

        // POST: BackOffice/Tournaments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,StartDate,EndDate,ArcherCount,Price,Description")] Tournament tournament, int [] WeaponsID)
        {
            if (ModelState.IsValid)
            {
                //tournament.Weapons = new List<Weapon>();
                //foreach (var item in WeaponsID)
                //{
                //    tournament.Weapons.Add(db.Weapons.Find(item));
                //}
                if (WeaponsID.Count()>0)
                    tournament XXXXXX
                db.Tournaments.Add(tournament);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tournament);
        }

        // GET: BackOffice/Tournaments/Edit/5
        public ActionResult Edit(int? id)
        { // a completer pour l'edition
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MultiSelectList weaponsValues = new MultiSelectList(db.Weapons, "ID", "Name");
            ViewBag.Weapons = weaponsValues;
            return View();

            Tournament tournament = db.Tournaments.Include("Weapons").SingleOrDefault(x => x.ID == id); // XXX
            if (tournament == null)
            {
                return HttpNotFound();
            }
            return View(tournament);
        }

        // POST: BackOffice/Tournaments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,StartDate,EndDate,ArcherCount,Price,Description")] Tournament tournament, int[] weaponsID)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tournament).State = EntityState.Modified;
                db.Tournaments.Include("Weapons").SingleOrDefault(x => x.ID == tournament.ID);

                if (weaponsID != null)
                {
                    tournament.Weapons = db.Weapons.Where(x => weaponsID.Contains(weaponsID, id ); // reprendre la suite sur git hub
                } else
                    tournament.Weapons.Clear();

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            MultiSelectList weaponsValues = new MultiSelectList(db.Weapons, "ID", "Name", tournament,); // reprendre la suite sur git hub
            ViewBag.Weapons = weaponsValues;
            return View(tournament);
        }


        // GET: BackOffice/Tournaments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tournament tournament = db.Tournaments.Find(id);
            if (tournament == null)
            {
                return HttpNotFound();
            }
            return View(tournament);
        }

        // POST: BackOffice/Tournaments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tournament tournament = db.Tournaments.Include("Weapons").SingleOrDefault(x => x.ID == id);
            tournament.Weapons.Clear();

            var shooters = db.Shooters.Where(x => x.TournamentID == id);
            foreach (var item in shooters)
            {
                db.Entry(item).State = EntityState.Deleted;
            }
            db.Tournaments.Remove(tournament);

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
