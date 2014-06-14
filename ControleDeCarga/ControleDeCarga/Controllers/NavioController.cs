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
    public class NavioController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Navio/
        public ActionResult Index()
        {
            var navios = db.Navios.OrderBy(n => n.Nome);
            return View(navios.ToList());
        }

        // GET: /Navio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Navio navio = db.Navios.Find(id);
            if (navio == null)
            {
                return HttpNotFound();
            }
            return View(navio);
        }

        // GET: /Navio/Create
        public ActionResult Create()
        {
            ViewBag.CriadoPorUserId = new SelectList(db.Users, "Id", "UserName");
            ViewBag.ModificadoPorUserId = new SelectList(db.Users, "Id", "UserName");
            return View();
        }

        // POST: /Navio/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nome,Descricao,CriadoPorUserId,CriadoEm,ModificadoPorUserId,ModificadoEm")] Navio navio)
        {
            if (ModelState.IsValid)
            {
                db.Navios.Add(navio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CriadoPorUserId = new SelectList(db.Users, "Id", "UserName", navio.CriadoPorUserId);
            ViewBag.ModificadoPorUserId = new SelectList(db.Users, "Id", "UserName", navio.ModificadoPorUserId);
            return View(navio);
        }

        // GET: /Navio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Navio navio = db.Navios.Find(id);
            if (navio == null)
            {
                return HttpNotFound();
            }
            ViewBag.CriadoPorUserId = new SelectList(db.Users, "Id", "UserName", navio.CriadoPorUserId);
            ViewBag.ModificadoPorUserId = new SelectList(db.Users, "Id", "UserName", navio.ModificadoPorUserId);
            return View(navio);
        }

        // POST: /Navio/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nome,Descricao,CriadoPorUserId,CriadoEm,ModificadoPorUserId,ModificadoEm")] Navio navio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(navio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CriadoPorUserId = new SelectList(db.Users, "Id", "UserName", navio.CriadoPorUserId);
            ViewBag.ModificadoPorUserId = new SelectList(db.Users, "Id", "UserName", navio.ModificadoPorUserId);
            return View(navio);
        }

        // GET: /Navio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Navio navio = db.Navios.Find(id);
            if (navio == null)
            {
                return HttpNotFound();
            }
            return View(navio);
        }

        // POST: /Navio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Navio navio = db.Navios.Find(id);
            db.Navios.Remove(navio);
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
