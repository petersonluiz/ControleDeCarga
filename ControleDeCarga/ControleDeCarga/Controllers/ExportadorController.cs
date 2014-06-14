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
    public class ExportadorController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Exportador/
        public ActionResult Index()
        {
            var exportadores = db.Exportadores.OrderBy(e => e.Nome);
            return View(exportadores.ToList());
        }

        // GET: /Exportador/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exportador exportador = db.Exportadores.Find(id);
            if (exportador == null)
            {
                return HttpNotFound();
            }
            return View(exportador);
        }

        // GET: /Exportador/Create
        public ActionResult Create()
        {
            ViewBag.CriadoPorUserId = new SelectList(db.Users, "Id", "UserName");
            ViewBag.ModificadoPorUserId = new SelectList(db.Users, "Id", "UserName");
            return View();
        }

        // POST: /Exportador/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nome,CriadoPorUserId,CriadoEm,ModificadoPorUserId,ModificadoEm")] Exportador exportador)
        {
            if (ModelState.IsValid)
            {
                db.Exportadores.Add(exportador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CriadoPorUserId = new SelectList(db.Users, "Id", "UserName", exportador.CriadoPorUserId);
            ViewBag.ModificadoPorUserId = new SelectList(db.Users, "Id", "UserName", exportador.ModificadoPorUserId);
            return View(exportador);
        }

        // GET: /Exportador/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exportador exportador = db.Exportadores.Find(id);
            if (exportador == null)
            {
                return HttpNotFound();
            }
            ViewBag.CriadoPorUserId = new SelectList(db.Users, "Id", "UserName", exportador.CriadoPorUserId);
            ViewBag.ModificadoPorUserId = new SelectList(db.Users, "Id", "UserName", exportador.ModificadoPorUserId);
            return View(exportador);
        }

        // POST: /Exportador/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nome,CriadoPorUserId,CriadoEm,ModificadoPorUserId,ModificadoEm")] Exportador exportador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exportador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CriadoPorUserId = new SelectList(db.Users, "Id", "UserName", exportador.CriadoPorUserId);
            ViewBag.ModificadoPorUserId = new SelectList(db.Users, "Id", "UserName", exportador.ModificadoPorUserId);
            return View(exportador);
        }

        // GET: /Exportador/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exportador exportador = db.Exportadores.Find(id);
            if (exportador == null)
            {
                return HttpNotFound();
            }
            return View(exportador);
        }

        // POST: /Exportador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Exportador exportador = db.Exportadores.Find(id);
            db.Exportadores.Remove(exportador);
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
