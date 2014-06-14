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
    public class ImportadorController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Importador/
        public ActionResult Index()
        {
            var importadores = db.Importadores.OrderBy(i => i.Nome);
            return View(importadores.ToList());
        }

        // GET: /Importador/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Importador importador = db.Importadores.Find(id);
            if (importador == null)
            {
                return HttpNotFound();
            }
            return View(importador);
        }

        // GET: /Importador/Create
        public ActionResult Create()
        {
            ViewBag.CriadoPorUserId = new SelectList(db.Users, "Id", "UserName");
            ViewBag.ModificadoPorUserId = new SelectList(db.Users, "Id", "UserName");
            return View();
        }

        // POST: /Importador/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nome,CNPJ,Endereco,Telefone,Email,CriadoPorUserId,CriadoEm,ModificadoPorUserId,ModificadoEm")] Importador importador)
        {
            if (ModelState.IsValid)
            {
                db.Importadores.Add(importador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CriadoPorUserId = new SelectList(db.Users, "Id", "UserName", importador.CriadoPorUserId);
            ViewBag.ModificadoPorUserId = new SelectList(db.Users, "Id", "UserName", importador.ModificadoPorUserId);
            return View(importador);
        }

        // GET: /Importador/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Importador importador = db.Importadores.Find(id);
            if (importador == null)
            {
                return HttpNotFound();
            }
            ViewBag.CriadoPorUserId = new SelectList(db.Users, "Id", "UserName", importador.CriadoPorUserId);
            ViewBag.ModificadoPorUserId = new SelectList(db.Users, "Id", "UserName", importador.ModificadoPorUserId);
            return View(importador);
        }

        // POST: /Importador/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nome,CNPJ,Endereco,Telefone,Email,CriadoPorUserId,CriadoEm,ModificadoPorUserId,ModificadoEm")] Importador importador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(importador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CriadoPorUserId = new SelectList(db.Users, "Id", "UserName", importador.CriadoPorUserId);
            ViewBag.ModificadoPorUserId = new SelectList(db.Users, "Id", "UserName", importador.ModificadoPorUserId);
            return View(importador);
        }

        // GET: /Importador/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Importador importador = db.Importadores.Find(id);
            if (importador == null)
            {
                return HttpNotFound();
            }
            return View(importador);
        }

        // POST: /Importador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Importador importador = db.Importadores.Find(id);
            db.Importadores.Remove(importador);
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
