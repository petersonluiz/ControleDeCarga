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
    public class PortoSecoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /PortoSeco/
        public ActionResult Index()
        {
            var portossecos = db.PortosSecos.Include(p => p.Uf).OrderBy(p => p.Nome);
            return View(portossecos.ToList());
        }

        // GET: /PortoSeco/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PortoSeco portoseco = db.PortosSecos.Find(id);
            if (portoseco == null)
            {
                return HttpNotFound();
            }
            return View(portoseco);
        }

        // GET: /PortoSeco/Create
        public ActionResult Create()
        {
            ViewBag.CriadoPorUserId = new SelectList(db.Users, "Id", "UserName");
            ViewBag.ModificadoPorUserId = new SelectList(db.Users, "Id", "UserName");
            ViewBag.UfId = new SelectList(db.UFs, "Id", "Sigla");
            return View();
        }

        // POST: /PortoSeco/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nome,UfId,CriadoPorUserId,CriadoEm,ModificadoPorUserId,ModificadoEm")] PortoSeco portoseco)
        {
            if (ModelState.IsValid)
            {
                db.PortosSecos.Add(portoseco);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CriadoPorUserId = new SelectList(db.Users, "Id", "UserName", portoseco.CriadoPorUserId);
            ViewBag.ModificadoPorUserId = new SelectList(db.Users, "Id", "UserName", portoseco.ModificadoPorUserId);
            ViewBag.UfId = new SelectList(db.UFs, "Id", "Sigla", portoseco.UfId);
            return View(portoseco);
        }

        // GET: /PortoSeco/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PortoSeco portoseco = db.PortosSecos.Find(id);
            if (portoseco == null)
            {
                return HttpNotFound();
            }
            ViewBag.CriadoPorUserId = new SelectList(db.Users, "Id", "UserName", portoseco.CriadoPorUserId);
            ViewBag.ModificadoPorUserId = new SelectList(db.Users, "Id", "UserName", portoseco.ModificadoPorUserId);
            ViewBag.UfId = new SelectList(db.UFs, "Id", "Sigla", portoseco.UfId);
            return View(portoseco);
        }

        // POST: /PortoSeco/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nome,UfId,CriadoPorUserId,CriadoEm,ModificadoPorUserId,ModificadoEm")] PortoSeco portoseco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(portoseco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CriadoPorUserId = new SelectList(db.Users, "Id", "UserName", portoseco.CriadoPorUserId);
            ViewBag.ModificadoPorUserId = new SelectList(db.Users, "Id", "UserName", portoseco.ModificadoPorUserId);
            ViewBag.UfId = new SelectList(db.UFs, "Id", "Sigla", portoseco.UfId);
            return View(portoseco);
        }

        // GET: /PortoSeco/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PortoSeco portoseco = db.PortosSecos.Find(id);
            if (portoseco == null)
            {
                return HttpNotFound();
            }
            return View(portoseco);
        }

        // POST: /PortoSeco/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PortoSeco portoseco = db.PortosSecos.Find(id);
            db.PortosSecos.Remove(portoseco);
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
