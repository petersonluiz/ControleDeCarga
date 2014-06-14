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
    public class LocalDeEntregaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /LocalDeEntrega/
        public ActionResult Index()
        {
            var locaisdeentrega = db.LocaisDeEntrega.Include(l => l.Uf).OrderBy(l => l.Cidade);
            return View(locaisdeentrega.ToList());
        }

        // GET: /LocalDeEntrega/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocalDeEntrega localdeentrega = db.LocaisDeEntrega.Find(id);
            if (localdeentrega == null)
            {
                return HttpNotFound();
            }
            return View(localdeentrega);
        }

        // GET: /LocalDeEntrega/Create
        public ActionResult Create()
        {
            ViewBag.CriadoPorUserId = new SelectList(db.Users, "Id", "UserName");
            ViewBag.ModificadoPorUserId = new SelectList(db.Users, "Id", "UserName");
            ViewBag.UfId = new SelectList(db.UFs, "Id", "Sigla");
            return View();
        }

        // POST: /LocalDeEntrega/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Cidade,UfId,CriadoPorUserId,CriadoEm,ModificadoPorUserId,ModificadoEm")] LocalDeEntrega localdeentrega)
        {
            if (ModelState.IsValid)
            {
                db.LocaisDeEntrega.Add(localdeentrega);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CriadoPorUserId = new SelectList(db.Users, "Id", "UserName", localdeentrega.CriadoPorUserId);
            ViewBag.ModificadoPorUserId = new SelectList(db.Users, "Id", "UserName", localdeentrega.ModificadoPorUserId);
            ViewBag.UfId = new SelectList(db.UFs, "Id", "Sigla", localdeentrega.UfId);
            return View(localdeentrega);
        }

        // GET: /LocalDeEntrega/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocalDeEntrega localdeentrega = db.LocaisDeEntrega.Find(id);
            if (localdeentrega == null)
            {
                return HttpNotFound();
            }
            ViewBag.CriadoPorUserId = new SelectList(db.Users, "Id", "UserName", localdeentrega.CriadoPorUserId);
            ViewBag.ModificadoPorUserId = new SelectList(db.Users, "Id", "UserName", localdeentrega.ModificadoPorUserId);
            ViewBag.UfId = new SelectList(db.UFs, "Id", "Sigla", localdeentrega.UfId);
            return View(localdeentrega);
        }

        // POST: /LocalDeEntrega/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Cidade,UfId,CriadoPorUserId,CriadoEm,ModificadoPorUserId,ModificadoEm")] LocalDeEntrega localdeentrega)
        {
            if (ModelState.IsValid)
            {
                db.Entry(localdeentrega).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CriadoPorUserId = new SelectList(db.Users, "Id", "UserName", localdeentrega.CriadoPorUserId);
            ViewBag.ModificadoPorUserId = new SelectList(db.Users, "Id", "UserName", localdeentrega.ModificadoPorUserId);
            ViewBag.UfId = new SelectList(db.UFs, "Id", "Sigla", localdeentrega.UfId);
            return View(localdeentrega);
        }

        // GET: /LocalDeEntrega/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocalDeEntrega localdeentrega = db.LocaisDeEntrega.Find(id);
            if (localdeentrega == null)
            {
                return HttpNotFound();
            }
            return View(localdeentrega);
        }

        // POST: /LocalDeEntrega/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LocalDeEntrega localdeentrega = db.LocaisDeEntrega.Find(id);
            db.LocaisDeEntrega.Remove(localdeentrega);
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
