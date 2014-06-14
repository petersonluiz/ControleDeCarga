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
    public class DespachanteController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Despachante/
        public ActionResult Index()
        {
            var despachantes = db.Despachantes.OrderBy(d => d.Nome);
            return View(despachantes.ToList());
        }

        // GET: /Despachante/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Despachante despachante = db.Despachantes.Find(id);
            if (despachante == null)
            {
                return HttpNotFound();
            }
            return View(despachante);
        }

        // GET: /Despachante/Create
        public ActionResult Create()
        {
            ViewBag.CriadoPorUserId = new SelectList(db.Users, "Id", "UserName");
            ViewBag.ModificadoPorUserId = new SelectList(db.Users, "Id", "UserName");
            return View();
        }

        // POST: /Despachante/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nome,Telefone,Email,CriadoPorUserId,CriadoEm,ModificadoPorUserId,ModificadoEm")] Despachante despachante)
        {
            if (ModelState.IsValid)
            {
                db.Despachantes.Add(despachante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CriadoPorUserId = new SelectList(db.Users, "Id", "UserName", despachante.CriadoPorUserId);
            ViewBag.ModificadoPorUserId = new SelectList(db.Users, "Id", "UserName", despachante.ModificadoPorUserId);
            return View(despachante);
        }

        // GET: /Despachante/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Despachante despachante = db.Despachantes.Find(id);
            if (despachante == null)
            {
                return HttpNotFound();
            }
            ViewBag.CriadoPorUserId = new SelectList(db.Users, "Id", "UserName", despachante.CriadoPorUserId);
            ViewBag.ModificadoPorUserId = new SelectList(db.Users, "Id", "UserName", despachante.ModificadoPorUserId);
            return View(despachante);
        }

        // POST: /Despachante/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nome,Telefone,Email,CriadoPorUserId,CriadoEm,ModificadoPorUserId,ModificadoEm")] Despachante despachante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(despachante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CriadoPorUserId = new SelectList(db.Users, "Id", "UserName", despachante.CriadoPorUserId);
            ViewBag.ModificadoPorUserId = new SelectList(db.Users, "Id", "UserName", despachante.ModificadoPorUserId);
            return View(despachante);
        }

        // GET: /Despachante/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Despachante despachante = db.Despachantes.Find(id);
            if (despachante == null)
            {
                return HttpNotFound();
            }
            return View(despachante);
        }

        // POST: /Despachante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Despachante despachante = db.Despachantes.Find(id);
            db.Despachantes.Remove(despachante);
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
