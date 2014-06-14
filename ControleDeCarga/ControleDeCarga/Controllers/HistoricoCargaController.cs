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
    public class HistoricoCargaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /HistoricoCarga/
        public ActionResult Index()
        {
            var historicocargas = db.HistoricoCargas.Include(h => h.Evento).Include(h => h.Motorista).Include(h => h.Veiculo).OrderBy(h => h.Data);
            return PartialView(historicocargas.ToList());
        }

        // GET: /HistoricoCarga/Details/5
        public ActionResult Details(int? id, string Tela)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoricoCarga historicocarga = db.HistoricoCargas.Find(id);
            if (historicocarga == null)
            {
                return HttpNotFound();
            }
            ViewBag.Tela = Tela;
            return View(historicocarga);
        }

        // GET: /HistoricoCarga/Create
        public ActionResult Create(int? Id)
        {
            HistoricoCarga hcarga = new HistoricoCarga { CargaId = Id };

            ViewBag.cargaId = Id;
            ViewBag.EventoId = new SelectList(db.Evento, "Id", "Nome");            
            ViewBag.MotoristaId = new SelectList(db.Motoristas, "Id", "Nome");
            ViewBag.VeiculoId = new SelectList(db.Veiculos, "Id", "Placa");
            
            return PartialView(hcarga);
        }

        // POST: /HistoricoCarga/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,EventoId,Data,MotoristaId,VeiculoId,Observacoes,CargaId,CriadoPorUserId,CriadoEm,ModificadoPorUserId,ModificadoEm")] HistoricoCarga historicocarga)
        {
            
            if (ModelState.IsValid)
            {
                db.HistoricoCargas.Add(historicocarga);
                historicocarga.AtualizaStatusDaCarga(db);

                db.SaveChanges();
                return RedirectToAction("Index","Carga");
            }
                        
            ViewBag.EventoId = new SelectList(db.Evento, "Id", "Nome", historicocarga.EventoId);            
            ViewBag.MotoristaId = new SelectList(db.Motoristas, "Id", "Nome", historicocarga.MotoristaId);
            ViewBag.VeiculoId = new SelectList(db.Veiculos, "Id", "Placa", historicocarga.VeiculoId);
            return View(historicocarga);
        }

        // GET: /HistoricoCarga/Edit/5
        public ActionResult Edit(int? id, string Tela)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoricoCarga historicocarga = db.HistoricoCargas.Find(id);
            if (historicocarga == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventoId = new SelectList(db.Evento, "Id", "Nome", historicocarga.EventoId);
            ViewBag.MotoristaId = new SelectList(db.Motoristas, "Id", "Nome", historicocarga.MotoristaId);
            ViewBag.VeiculoId = new SelectList(db.Veiculos, "Id", "Placa", historicocarga.VeiculoId);
            ViewBag.Tela = Tela;
            return PartialView(historicocarga);
        }

        // POST: /HistoricoCarga/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,EventoId,Data,MotoristaId,VeiculoId,Observacoes,CargaId,CriadoPorUserId,CriadoEm,ModificadoPorUserId,ModificadoEm")] HistoricoCarga historicocarga, string telaAnterior)
        {
            if (ModelState.IsValid)
            {

                db.Entry(historicocarga).State = EntityState.Modified;
                db.SaveChanges();

                if (telaAnterior == "Edit")
                    return RedirectToAction("Edit", "Carga", new { id = historicocarga.CargaId });
                else if (telaAnterior == "Details")
                    return RedirectToAction("Details", "Carga", new { id = historicocarga.CargaId });
            }
            
            return View(historicocarga);
        }

        // GET: /HistoricoCarga/Delete/5
        public ActionResult Delete(int? id, string Tela)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoricoCarga historicocarga = db.HistoricoCargas.Find(id);
            if (historicocarga == null)
            {
                return HttpNotFound();
            }
            ViewBag.Tela = Tela;
            return PartialView(historicocarga);
        }

        // POST: /HistoricoCarga/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, string telaAnterior)
        {
            HistoricoCarga historicocarga = db.HistoricoCargas.Find(id);
            int? cargaId = historicocarga.CargaId;
            db.HistoricoCargas.Remove(historicocarga);
            db.SaveChanges();
            
            if (telaAnterior == "Edit")
                return RedirectToAction("Edit", "Carga", new { id = cargaId });
            else if (telaAnterior == "Details")
                return RedirectToAction("Details", "Carga", new { id = cargaId });

            return View(historicocarga);
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
