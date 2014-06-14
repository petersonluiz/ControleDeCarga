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
    public class CargaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Carga/
        public ActionResult Index()
        {
            var cargas = db.Cargas.Include(c => c.Filial).Include(c => c.Especie).Include(c => c.Exportador).Include(c => c.Importador).
                Include(c => c.Mercadoria).Include(c => c.StatusCarga).OrderBy(c => c.CriadoEm);

            ViewBag.statusId = new SelectList(db.StatusCarga, "Id", "Status");
            return View(cargas.ToList());
        }

        

        // GET: /Carga/
        public ActionResult Filter(string filtro, int statusId)
        {
            //var cargas = new List<Carga>();
            //if (statusId > 0 && !string.IsNullOrEmpty(filtro))
            //{
            //    cargas = db.Cargas.Include(c => c.Filial).Include(c => c.Especie).Include(c => c.Exportador).
            //    Include(c => c.Importador).Include(c => c.Mercadoria).Include(c => c.StatusCarga).
            //    OrderBy(c => c.CriadoEm).Where(c => (c.Exportador.Nome == filtro || c.Importador.Nome == filtro
            //    || c.Filial.Nome == filtro || c.DTA == filtro || c.DI_DSI == filtro
            //    || c.Mercadoria.Nome == filtro || c.Especie.Nome == filtro || c.Container == filtro)
            //    && c.StatusCargaId == statusId).ToList();
            //}
            //else if (statusId == 0 )
            //{
            //    cargas = db.Cargas.Include(c => c.Filial).Include(c => c.Especie).Include(c => c.Exportador).
            //    Include(c => c.Importador).Include(c => c.Mercadoria).Include(c => c.StatusCarga).
            //    OrderBy(c => c.CriadoEm).Where(c => c.Exportador.Nome == filtro || c.Importador.Nome == filtro
            //    || c.Filial.Nome == filtro || c.DTA == filtro || c.DI_DSI == filtro
            //    || c.Mercadoria.Nome == filtro || c.Especie.Nome == filtro || c.Container == filtro).ToList();
            //}
            //else
            //{
            //    cargas = db.Cargas.Include(c => c.Filial).Include(c => c.Especie).Include(c => c.Exportador).
            //    Include(c => c.Importador).Include(c => c.Mercadoria).Include(c => c.StatusCarga).
            //    OrderBy(c => c.CriadoEm).Where(c =>  c.StatusCargaId == statusId).ToList();
            //}
                           
            
            return PartialView("_List");
        }

        // GET: /Carga/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carga carga = db.Cargas.Find(id);

            if (carga == null)
            {
                return HttpNotFound();
            }
            return View(carga);
        }

        // GET: /Carga/Create
        public ActionResult Create()
        {
            ViewBag.ArmadorId = new SelectList(db.Armadores, "Id", "Nome");            
            ViewBag.EspecieId = new SelectList(db.Especies, "Id", "Nome");
            ViewBag.ExportadorId = new SelectList(db.Exportadores, "Id", "Nome");
            ViewBag.ImportadorId = new SelectList(db.Importadores, "Id", "Nome");
            ViewBag.LocalDeDevolucaoId = new SelectList(db.LocaisDeDevolucao, "Id", "Nome");
            ViewBag.LocalDeEntregaId = new SelectList(db.LocaisDeEntrega, "Id", "Cidade");
            ViewBag.MercadoriaId = new SelectList(db.Mercadorias, "Id", "Nome");            
            ViewBag.NavioId = new SelectList(db.Navios, "Id", "Nome");
            ViewBag.PortoSecoId = new SelectList(db.PortosSecos, "Id", "Nome");
            ViewBag.StatusCargaId = new SelectList(db.StatusCarga, "Id", "Status");
            ViewBag.FilialId = new SelectList(db.Filiais, "Id", "Nome");

            return View();
        }

        //get
        public ActionResult CreateCargaSimples()
        {            
            ViewBag.EspecieId = new SelectList(db.Especies, "Id", "Nome");
            ViewBag.ExportadorId = new SelectList(db.Exportadores, "Id", "Nome");
            ViewBag.ImportadorId = new SelectList(db.Importadores, "Id", "Nome");          
            ViewBag.LocalDeEntregaId = new SelectList(db.LocaisDeEntrega, "Id", "Cidade");
            ViewBag.MercadoriaId = new SelectList(db.Mercadorias, "Id", "Nome");
            ViewBag.FilialId = new SelectList(db.Filiais, "Id", "Nome");

            return View("CreateCargaSimples");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCargaSimples(CargaSimples carga)
        {

            if (ModelState.IsValid)            
            {
                carga.EspecieId = 1;
                db.Cargas.Add(carga);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            // ViewBag.ArmadorId = new SelectList(db.Armadores, "Id", "Nome", carga.ArmadorId);
            ViewBag.EspecieId = new SelectList(db.Especies, "Id", "Nome", carga.EspecieId);
            ViewBag.ExportadorId = new SelectList(db.Exportadores, "Id", "Nome", carga.ExportadorId);
            ViewBag.ImportadorId = new SelectList(db.Importadores, "Id", "Nome", carga.ImportadorId);
            ViewBag.LocalDeEntregaId = new SelectList(db.LocaisDeEntrega, "Id", "Cidade", carga.LocalDeEntregaId);
            ViewBag.MercadoriaId = new SelectList(db.Mercadorias, "Id", "Nome", carga.MercadoriaId);
            ViewBag.StatusCargaId = new SelectList(db.StatusCarga, "Id", "Status", carga.StatusCargaId);
            ViewBag.FilialId = new SelectList(db.Filiais, "Id", "Nome");

            return View(carga);
        }

        //get
        public ActionResult CreateCargaContainer()
        {
            ViewBag.ArmadorId = new SelectList(db.Armadores, "Id", "Nome");
            ViewBag.ExportadorId = new SelectList(db.Exportadores, "Id", "Nome");
            ViewBag.ImportadorId = new SelectList(db.Importadores, "Id", "Nome");
            ViewBag.LocalDeDevolucaoId = new SelectList(db.LocaisDeDevolucao, "Id", "Nome");
            ViewBag.LocalDeEntregaId = new SelectList(db.LocaisDeEntrega, "Id", "Cidade");
            ViewBag.MercadoriaId = new SelectList(db.Mercadorias, "Id", "Nome");
            ViewBag.NavioId = new SelectList(db.Navios, "Id", "Nome");
            ViewBag.PortoSecoId = new SelectList(db.PortosSecos, "Id", "Nome");            
            ViewBag.FilialId = new SelectList(db.Filiais, "Id", "Nome");

            return View("CreateCargaContainer");
        }

        // POST: /Carga/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCargaContainer(CargaContainer carga, List<string>Container, List<string>TipoContainer)
        {
            
            if (ModelState.IsValid)
            {
                carga.EspecieId = 2;
                db.Cargas.Add(carga);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArmadorId = new SelectList(db.Armadores, "Id", "Nome", carga.ArmadorId);
            ViewBag.ExportadorId = new SelectList(db.Exportadores, "Id", "Nome", carga.ExportadorId);
            ViewBag.ImportadorId = new SelectList(db.Importadores, "Id", "Nome", carga.ImportadorId);
            ViewBag.LocalDeDevolucaoId = new SelectList(db.LocaisDeDevolucao, "Id", "Nome", carga.LocalDeDevolucaoId);
            ViewBag.LocalDeEntregaId = new SelectList(db.LocaisDeEntrega, "Id", "Cidade", carga.LocalDeEntregaId);
            ViewBag.MercadoriaId = new SelectList(db.Mercadorias, "Id", "Nome", carga.MercadoriaId);
            ViewBag.NavioId = new SelectList(db.Navios, "Id", "Nome", carga.NavioId);
            ViewBag.PortoSecoId = new SelectList(db.PortosSecos, "Id", "Nome", carga.PortoSecoId);
            ViewBag.StatusCargaId = new SelectList(db.StatusCarga, "Id", "Status", carga.StatusCargaId);
            ViewBag.FilialId = new SelectList(db.Filiais, "Id", "Nome");

            return View("CreateCargaContainer", carga);
        }

        // GET: /Carga/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carga carga = db.Cargas.Include("HistoricoCarga").Single(c => c.Id == id);
            if (carga == null)
            {
                return HttpNotFound();
            }
            //ViewBag.ArmadorId = new SelectList(db.Armadores, "Id", "Nome", carga.ArmadorId);            
            ViewBag.EspecieId = new SelectList(db.Especies, "Id", "Nome", carga.EspecieId);
            ViewBag.ExportadorId = new SelectList(db.Exportadores, "Id", "Nome", carga.ExportadorId);
            ViewBag.ImportadorId = new SelectList(db.Importadores, "Id", "Nome", carga.ImportadorId);
            //ViewBag.LocalDeDevolucaoId = new SelectList(db.LocaisDeDevolucao, "Id", "Nome", carga.LocalDeDevolucaoId);
            ViewBag.LocalDeEntregaId = new SelectList(db.LocaisDeEntrega, "Id", "Cidade", carga.LocalDeEntregaId);
            ViewBag.MercadoriaId = new SelectList(db.Mercadorias, "Id", "Nome", carga.MercadoriaId);            
            //ViewBag.NavioId = new SelectList(db.Navios, "Id", "Nome", carga.NavioId);
            //ViewBag.PortoSecoId = new SelectList(db.PortosSecos, "Id", "Nome", carga.PortoSecoId);
            ViewBag.StatusCargaId = new SelectList(db.StatusCarga, "Id", "Status", carga.StatusCargaId);
            ViewBag.FilialId = new SelectList(db.Filiais, "Id", "Nome");
            
            return View(carga);
        }

        // POST: /Carga/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Carga carga)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carga).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.ArmadorId = new SelectList(db.Armadores, "Id", "Nome", carga.ArmadorId);
            ViewBag.CriadoPorUserId = new SelectList(db.Users, "Id", "UserName", carga.CriadoPorUserId);
            ViewBag.EspecieId = new SelectList(db.Especies, "Id", "Nome", carga.EspecieId);
            ViewBag.ExportadorId = new SelectList(db.Exportadores, "Id", "Nome", carga.ExportadorId);
            ViewBag.ImportadorId = new SelectList(db.Importadores, "Id", "Nome", carga.ImportadorId);
            //ViewBag.LocalDeDevolucaoId = new SelectList(db.LocaisDeDevolucao, "Id", "Nome", carga.LocalDeDevolucaoId);
            ViewBag.LocalDeEntregaId = new SelectList(db.LocaisDeEntrega, "Id", "Cidade", carga.LocalDeEntregaId);
            ViewBag.MercadoriaId = new SelectList(db.Mercadorias, "Id", "Nome", carga.MercadoriaId);
            ViewBag.ModificadoPorUserId = new SelectList(db.Users, "Id", "UserName", carga.ModificadoPorUserId);
            //ViewBag.NavioId = new SelectList(db.Navios, "Id", "Nome", carga.NavioId);
            //ViewBag.PortoSecoId = new SelectList(db.PortosSecos, "Id", "Nome", carga.PortoSecoId);
            ViewBag.StatusCargaId = new SelectList(db.StatusCarga, "Id", "Status", carga.StatusCargaId);
            return View(carga);
        }

        // GET: /Carga/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carga carga = db.Cargas.Find(id);
            if (carga == null)
            {
                return HttpNotFound();
            }
            return View(carga);
        }

        // POST: /Carga/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Carga carga = db.Cargas.Find(id);
            db.Cargas.Remove(carga);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CreateContainer()
        {
            return PartialView("_CreateContainer");

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
