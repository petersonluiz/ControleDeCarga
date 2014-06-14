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
    public class ArmadorController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Armador/
        public ActionResult Index()
        {
            var armadores = db.Armadores.OrderBy(a => a.Nome);
            return View(armadores.ToList());
        }

        // GET: /Armador/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Armador armador = db.Armadores.Find(id);
            if (armador == null)
            {
                return HttpNotFound();
            }
            return View(armador);
        }

        // GET: /Armador/Create
        public ActionResult Create()
        {
            ViewBag.CriadoPorUserId = new SelectList(db.Users, "Id", "UserName");
            ViewBag.ModificadoPorUserId = new SelectList(db.Users, "Id", "UserName");
            return View();
        }

        // POST: /Armador/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nome,PessoaContato,Telefone,Email,CriadoPorUserId,CriadoEm,ModificadoPorUserId,ModificadoEm")] Armador armador)
        {
            if (ModelState.IsValid)
            {
                db.Armadores.Add(armador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CriadoPorUserId = new SelectList(db.Users, "Id", "UserName", armador.CriadoPorUserId);
            ViewBag.ModificadoPorUserId = new SelectList(db.Users, "Id", "UserName", armador.ModificadoPorUserId);
            return View(armador);
        }

        // GET: /Armador/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Armador armador = db.Armadores.Find(id);
            if (armador == null)
            {
                return HttpNotFound();
            }
            ViewBag.CriadoPorUserId = new SelectList(db.Users, "Id", "UserName", armador.CriadoPorUserId);
            ViewBag.ModificadoPorUserId = new SelectList(db.Users, "Id", "UserName", armador.ModificadoPorUserId);
            return View(armador);
        }

        // POST: /Armador/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nome,PessoaContato,Telefone,Email,CriadoPorUserId,CriadoEm,ModificadoPorUserId,ModificadoEm")] Armador armador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(armador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CriadoPorUserId = new SelectList(db.Users, "Id", "UserName", armador.CriadoPorUserId);
            ViewBag.ModificadoPorUserId = new SelectList(db.Users, "Id", "UserName", armador.ModificadoPorUserId);
            return View(armador);
        }

        // GET: /Armador/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Armador armador = db.Armadores.Find(id);
            if (armador == null)
            {
                return HttpNotFound();
            }
            return View(armador);
        }

        // POST: /Armador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Armador armador = db.Armadores.Find(id);
            db.Armadores.Remove(armador);
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
