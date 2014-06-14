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
    public class LocalDeDevolucaoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /LocalDeDevolucao/
        public ActionResult Index()
        {
            var locaisdedevolucao = db.LocaisDeDevolucao.OrderBy(l => l.Nome);
            return View(locaisdedevolucao.ToList());
        }

        // GET: /LocalDeDevolucao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocalDeDevolucao localdedevolucao = db.LocaisDeDevolucao.Find(id);
            if (localdedevolucao == null)
            {
                return HttpNotFound();
            }
            return View(localdedevolucao);
        }

        // GET: /LocalDeDevolucao/Create
        public ActionResult Create()
        {
            ViewBag.CriadoPorUserId = new SelectList(db.Users, "Id", "UserName");
            ViewBag.ModificadoPorUserId = new SelectList(db.Users, "Id", "UserName");
            return View();
        }

        // POST: /LocalDeDevolucao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nome,CriadoPorUserId,CriadoEm,ModificadoPorUserId,ModificadoEm")] LocalDeDevolucao localdedevolucao)
        {
            if (ModelState.IsValid)
            {
                db.LocaisDeDevolucao.Add(localdedevolucao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CriadoPorUserId = new SelectList(db.Users, "Id", "UserName", localdedevolucao.CriadoPorUserId);
            ViewBag.ModificadoPorUserId = new SelectList(db.Users, "Id", "UserName", localdedevolucao.ModificadoPorUserId);
            return View(localdedevolucao);
        }

        // GET: /LocalDeDevolucao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocalDeDevolucao localdedevolucao = db.LocaisDeDevolucao.Find(id);
            if (localdedevolucao == null)
            {
                return HttpNotFound();
            }
            ViewBag.CriadoPorUserId = new SelectList(db.Users, "Id", "UserName", localdedevolucao.CriadoPorUserId);
            ViewBag.ModificadoPorUserId = new SelectList(db.Users, "Id", "UserName", localdedevolucao.ModificadoPorUserId);
            return View(localdedevolucao);
        }

        // POST: /LocalDeDevolucao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nome,CriadoPorUserId,CriadoEm,ModificadoPorUserId,ModificadoEm")] LocalDeDevolucao localdedevolucao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(localdedevolucao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CriadoPorUserId = new SelectList(db.Users, "Id", "UserName", localdedevolucao.CriadoPorUserId);
            ViewBag.ModificadoPorUserId = new SelectList(db.Users, "Id", "UserName", localdedevolucao.ModificadoPorUserId);
            return View(localdedevolucao);
        }

        // GET: /LocalDeDevolucao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocalDeDevolucao localdedevolucao = db.LocaisDeDevolucao.Find(id);
            if (localdedevolucao == null)
            {
                return HttpNotFound();
            }
            return View(localdedevolucao);
        }

        // POST: /LocalDeDevolucao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LocalDeDevolucao localdedevolucao = db.LocaisDeDevolucao.Find(id);
            db.LocaisDeDevolucao.Remove(localdedevolucao);
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
