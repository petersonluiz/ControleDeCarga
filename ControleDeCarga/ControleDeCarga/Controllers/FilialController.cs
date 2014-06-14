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
    public class FilialController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Filial/
        public ActionResult Index()
        {
            var filiais = db.Filiais.Include(f => f.Uf).OrderBy(f => f.Nome);
            return View(filiais.ToList());
        }

        // GET: /Filial/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filial filial = db.Filiais.Find(id);
            if (filial == null)
            {
                return HttpNotFound();
            }
            return View(filial);
        }

        // GET: /Filial/Create
        public ActionResult Create()
        {
            ViewBag.CriadoPorUserId = new SelectList(db.Users, "Id", "UserName");
            ViewBag.ModificadoPorUserId = new SelectList(db.Users, "Id", "UserName");
            ViewBag.UfId = new SelectList(db.UFs, "Id", "Sigla");
            return View();
        }

        // POST: /Filial/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nome,Cidade,UfId,Endereco,Telefone,Radio,Email,Contato,CriadoPorUserId,CriadoEm,ModificadoPorUserId,ModificadoEm")] Filial filial)
        {
            if (ModelState.IsValid)
            {
                db.Filiais.Add(filial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CriadoPorUserId = new SelectList(db.Users, "Id", "UserName", filial.CriadoPorUserId);
            ViewBag.ModificadoPorUserId = new SelectList(db.Users, "Id", "UserName", filial.ModificadoPorUserId);
            ViewBag.UfId = new SelectList(db.UFs, "Id", "Sigla", filial.UfId);
            return View(filial);
        }

        // GET: /Filial/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filial filial = db.Filiais.Find(id);
            if (filial == null)
            {
                return HttpNotFound();
            }
            ViewBag.CriadoPorUserId = new SelectList(db.Users, "Id", "UserName", filial.CriadoPorUserId);
            ViewBag.ModificadoPorUserId = new SelectList(db.Users, "Id", "UserName", filial.ModificadoPorUserId);
            ViewBag.UfId = new SelectList(db.UFs, "Id", "Sigla", filial.UfId);
            return View(filial);
        }

        // POST: /Filial/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nome,Cidade,UfId,Endereco,Telefone,Radio,Email,Contato,CriadoPorUserId,CriadoEm,ModificadoPorUserId,ModificadoEm")] Filial filial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(filial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CriadoPorUserId = new SelectList(db.Users, "Id", "UserName", filial.CriadoPorUserId);
            ViewBag.ModificadoPorUserId = new SelectList(db.Users, "Id", "UserName", filial.ModificadoPorUserId);
            ViewBag.UfId = new SelectList(db.UFs, "Id", "Sigla", filial.UfId);
            return View(filial);
        }

        // GET: /Filial/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filial filial = db.Filiais.Find(id);
            if (filial == null)
            {
                return HttpNotFound();
            }
            return View(filial);
        }

        // POST: /Filial/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Filial filial = db.Filiais.Find(id);
            db.Filiais.Remove(filial);
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
