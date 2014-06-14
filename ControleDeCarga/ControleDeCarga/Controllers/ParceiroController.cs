using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ControleDeCarga.Models;

namespace ControleDeCarga.Controllers
{
    [Authorize]
    public class ParceiroController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Parceiro/
        public ActionResult Index()
        {
            var parceiros = db.Parceiros.OrderBy(p => p.Nome);
            return View(parceiros.ToList());
        }

        // GET: /Parceiro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parceiro parceiro = db.Parceiros.Find(id);
            if (parceiro == null)
            {
                return HttpNotFound();
            }
            return View(parceiro);
        }

        // GET: /Parceiro/Create
        public ActionResult Create()
        {
            ViewBag.CriadoPorUserId = new SelectList(db.Users, "Id", "UserName");
            ViewBag.ModificadoPorUserId = new SelectList(db.Users, "Id", "UserName");
            return View();
        }

        // POST: /Parceiro/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nome,Telefone,CriadoPorUserId,CriadoEm,ModificadoPorUserId,ModificadoEm")] Parceiro parceiro)
        {
            if (ModelState.IsValid)
            {
                db.Parceiros.Add(parceiro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CriadoPorUserId = new SelectList(db.Users, "Id", "UserName", parceiro.CriadoPorUserId);
            ViewBag.ModificadoPorUserId = new SelectList(db.Users, "Id", "UserName", parceiro.ModificadoPorUserId);
            return View(parceiro);
        }

        // GET: /Parceiro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parceiro parceiro = db.Parceiros.Find(id);
            if (parceiro == null)
            {
                return HttpNotFound();
            }
            ViewBag.CriadoPorUserId = new SelectList(db.Users, "Id", "UserName", parceiro.CriadoPorUserId);
            ViewBag.ModificadoPorUserId = new SelectList(db.Users, "Id", "UserName", parceiro.ModificadoPorUserId);
            return View(parceiro);
        }

        // POST: /Parceiro/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nome,Telefone,CriadoPorUserId,CriadoEm,ModificadoPorUserId,ModificadoEm")] Parceiro parceiro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parceiro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CriadoPorUserId = new SelectList(db.Users, "Id", "UserName", parceiro.CriadoPorUserId);
            ViewBag.ModificadoPorUserId = new SelectList(db.Users, "Id", "UserName", parceiro.ModificadoPorUserId);
            return View(parceiro);
        }

        // GET: /Parceiro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parceiro parceiro = db.Parceiros.Find(id);
            if (parceiro == null)
            {
                return HttpNotFound();
            }
            return View(parceiro);
        }

        // POST: /Parceiro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Parceiro parceiro = db.Parceiros.Find(id);
            db.Parceiros.Remove(parceiro);
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
