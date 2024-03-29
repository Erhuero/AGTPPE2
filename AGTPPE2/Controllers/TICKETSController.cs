﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AGTPPE2;

namespace AGTPPE2.Controllers
{
    public class TICKETSController : Controller
    {
        private BDDKNEntities db = new BDDKNEntities();

        // GET: TICKETS
        public ActionResult Index()
        {
            var tICKETS = db.TICKETS.Include(t => t.CELLULE).Include(t => t.MATERIEL).Include(t => t.STATUT).Include(t => t.UTILISATEUR);
            return View(tICKETS.ToList());
        }

        // GET: TICKETS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TICKETS tICKETS = db.TICKETS.Find(id);
            if (tICKETS == null)
            {
                return HttpNotFound();
            }
            return View(tICKETS);
        }

        // GET: TICKETS/Create
        public ActionResult Create()
        {
            ViewBag.nomCellule = new SelectList(db.CELLULE, "nomCellule", "nomCellule");
            ViewBag.numeroSerieMateriel = new SelectList(db.MATERIEL, "numeroSerieMateriel", "emplacementMateriel");
            ViewBag.etatStatut = new SelectList(db.STATUT, "etatStatut", "etatStatut");
            ViewBag.idUtilisateur = new SelectList(db.UTILISATEUR, "idUtilisateur", "nomUtilisateur");
            return View();
        }

        // POST: TICKETS/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTicket,emplacementMaterielTicket,typeMaterielTicket,descriptionIncident,dateCreationIncident,dateClotureIncident,idUtilisateur,numeroSerieMateriel,nomCellule,etatStatut")] TICKETS tICKETS)
        {
            if (ModelState.IsValid)
            {
                db.TICKETS.Add(tICKETS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.nomCellule = new SelectList(db.CELLULE, "nomCellule", "nomCellule", tICKETS.nomCellule);
            ViewBag.numeroSerieMateriel = new SelectList(db.MATERIEL, "numeroSerieMateriel", "emplacementMateriel", tICKETS.numeroSerieMateriel);
            ViewBag.etatStatut = new SelectList(db.STATUT, "etatStatut", "etatStatut", tICKETS.etatStatut);
            ViewBag.idUtilisateur = new SelectList(db.UTILISATEUR, "idUtilisateur", "nomUtilisateur", tICKETS.idUtilisateur);
            return View(tICKETS);
        }

        // GET: TICKETS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TICKETS tICKETS = db.TICKETS.Find(id);
            if (tICKETS == null)
            {
                return HttpNotFound();
            }
            ViewBag.nomCellule = new SelectList(db.CELLULE, "nomCellule", "nomCellule", tICKETS.nomCellule);
            ViewBag.numeroSerieMateriel = new SelectList(db.MATERIEL, "numeroSerieMateriel", "emplacementMateriel", tICKETS.numeroSerieMateriel);
            ViewBag.etatStatut = new SelectList(db.STATUT, "etatStatut", "etatStatut", tICKETS.etatStatut);
            ViewBag.idUtilisateur = new SelectList(db.UTILISATEUR, "idUtilisateur", "nomUtilisateur", tICKETS.idUtilisateur);
            return View(tICKETS);
        }

        // POST: TICKETS/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTicket,emplacementMaterielTicket,typeMaterielTicket,descriptionIncident,dateCreationIncident,dateClotureIncident,idUtilisateur,numeroSerieMateriel,nomCellule,etatStatut")] TICKETS tICKETS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tICKETS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.nomCellule = new SelectList(db.CELLULE, "nomCellule", "nomCellule", tICKETS.nomCellule);
            ViewBag.numeroSerieMateriel = new SelectList(db.MATERIEL, "numeroSerieMateriel", "emplacementMateriel", tICKETS.numeroSerieMateriel);
            ViewBag.etatStatut = new SelectList(db.STATUT, "etatStatut", "etatStatut", tICKETS.etatStatut);
            ViewBag.idUtilisateur = new SelectList(db.UTILISATEUR, "idUtilisateur", "nomUtilisateur", tICKETS.idUtilisateur);
            return View(tICKETS);
        }

        // GET: TICKETS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TICKETS tICKETS = db.TICKETS.Find(id);
            if (tICKETS == null)
            {
                return HttpNotFound();
            }
            return View(tICKETS);
        }

        // POST: TICKETS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TICKETS tICKETS = db.TICKETS.Find(id);
            db.TICKETS.Remove(tICKETS);
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
