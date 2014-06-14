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
    public class MercadoriaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Mercadoria/
        public ActionResult Index()
        {
            var mercadorias = db.Mercadorias.OrderBy(m => m.Nome);
            return View(mercadorias.ToList());
        }

        // GET: /Mercadoria/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mercadoria mercadoria = db.Mercadorias.Find(id);
            if (mercadoria == null)
            {
                return HttpNotFound();
            }
            return View(mercadoria);
        }

        // GET: /Mercadoria/Create
        public ActionResult Create()
        {
            ViewBag.CriadoPorUserId = new SelectList(db.Users, "Id", "UserName");
            ViewBag.ModificadoPorUserId = new SelectList(db.Users, "Id", "UserName");
            return View();
        }

        // POST: /Mercadoria/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nome,Descricao,CriadoPorUserId,CriadoEm,ModificadoPorUserId,ModificadoEm")] Mercadoria mercadoria)
        {
            if (ModelState.IsValid)
            {
                db.Mercadorias.Add(mercadoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CriadoPorUserId = new SelectList(db.Users, "Id", "UserName", mercadoria.CriadoPorUserId);
            ViewBag.ModificadoPorUserId = new SelectList(db.Users, "Id", "UserName", mercadoria.ModificadoPorUserId);
            return View(mercadoria);
        }

        // GET: /Mercadoria/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mercadoria mercadoria = db.Mercadorias.Find(id);
            if (mercadoria == null)
            {
                return HttpNotFound();
            }
            ViewBag.CriadoPorUserId = new SelectList(db.Users, "Id", "UserName", mercadoria.CriadoPorUserId);
            ViewBag.ModificadoPorUserId = new SelectList(db.Users, "Id", "UserName", mercadoria.ModificadoPorUserId);
            return View(mercadoria);
        }

        // POST: /Mercadoria/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nome,Descricao,CriadoPorUserId,CriadoEm,ModificadoPorUserId,ModificadoEm")] Mercadoria mercadoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mercadoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CriadoPorUserId = new SelectList(db.Users, "Id", "UserName", mercadoria.CriadoPorUserId);
            ViewBag.ModificadoPorUserId = new SelectList(db.Users, "Id", "UserName", mercadoria.ModificadoPorUserId);
            return View(mercadoria);
        }

        // GET: /Mercadoria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mercadoria mercadoria = db.Mercadorias.Find(id);
            if (mercadoria == null)
            {
                return HttpNotFound();
            }
            return View(mercadoria);
        }

        // POST: /Mercadoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mercadoria mercadoria = db.Mercadorias.Find(id);
            db.Mercadorias.Remove(mercadoria);
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
