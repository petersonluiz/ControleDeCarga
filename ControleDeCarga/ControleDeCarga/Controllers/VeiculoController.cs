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
    public class VeiculoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Veiculo/
        public ActionResult Index()
        {
            var veiculos = db.Veiculos.Include(v => v.TipoVeiculo).OrderBy(v => v.Placa);
            return View(veiculos.ToList());
        }

        // GET: /Veiculo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veiculo veiculo = db.Veiculos.Find(id);
            if (veiculo == null)
            {
                return HttpNotFound();
            }
            return View(veiculo);
        }

        // GET: /Veiculo/Create
        public ActionResult Create()
        {
            ViewBag.CriadoPorUserId = new SelectList(db.Users, "Id", "UserName");
            ViewBag.ModificadoPorUserId = new SelectList(db.Users, "Id", "UserName");
            ViewBag.TipoVeiculoId = new SelectList(db.TipoVeiculos, "id", "Nome");
            return View();
        }

        // POST: /Veiculo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Placa,TipoVeiculoId,CriadoPorUserId,CriadoEm,ModificadoPorUserId,ModificadoEm")] Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                db.Veiculos.Add(veiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CriadoPorUserId = new SelectList(db.Users, "Id", "UserName", veiculo.CriadoPorUserId);
            ViewBag.ModificadoPorUserId = new SelectList(db.Users, "Id", "UserName", veiculo.ModificadoPorUserId);
            ViewBag.TipoVeiculoId = new SelectList(db.TipoVeiculos, "id", "Nome", veiculo.TipoVeiculoId);
            return View(veiculo);
        }

        // GET: /Veiculo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veiculo veiculo = db.Veiculos.Find(id);
            if (veiculo == null)
            {
                return HttpNotFound();
            }
            ViewBag.CriadoPorUserId = new SelectList(db.Users, "Id", "UserName", veiculo.CriadoPorUserId);
            ViewBag.ModificadoPorUserId = new SelectList(db.Users, "Id", "UserName", veiculo.ModificadoPorUserId);
            ViewBag.TipoVeiculoId = new SelectList(db.TipoVeiculos, "id", "Nome", veiculo.TipoVeiculoId);
            return View(veiculo);
        }

        // POST: /Veiculo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Placa,TipoVeiculoId,CriadoPorUserId,CriadoEm,ModificadoPorUserId,ModificadoEm")] Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(veiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CriadoPorUserId = new SelectList(db.Users, "Id", "UserName", veiculo.CriadoPorUserId);
            ViewBag.ModificadoPorUserId = new SelectList(db.Users, "Id", "UserName", veiculo.ModificadoPorUserId);
            ViewBag.TipoVeiculoId = new SelectList(db.TipoVeiculos, "id", "Nome", veiculo.TipoVeiculoId);
            return View(veiculo);
        }

        // GET: /Veiculo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veiculo veiculo = db.Veiculos.Find(id);
            if (veiculo == null)
            {
                return HttpNotFound();
            }
            return View(veiculo);
        }

        // POST: /Veiculo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Veiculo veiculo = db.Veiculos.Find(id);
            db.Veiculos.Remove(veiculo);
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
