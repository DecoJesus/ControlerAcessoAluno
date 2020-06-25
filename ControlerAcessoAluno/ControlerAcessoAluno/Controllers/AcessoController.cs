using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ControlerAcessoAluno.Models;

namespace ControlerAcessoAluno.Controllers
{
    public class AcessoController : Controller
    {
        private CONTROLEACESSOEntities db = new CONTROLEACESSOEntities();

        // GET: Acesso
        public ActionResult Index()
        {
            var tB_ACESSO = db.TB_ACESSO.Include(t => t.TB_ALUNO);
            return View(tB_ACESSO.ToList());
        }

        // GET: Acesso/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_ACESSO tB_ACESSO = db.TB_ACESSO.Find(id);
            if (tB_ACESSO == null)
            {
                return HttpNotFound();
            }
            return View(tB_ACESSO);
        }

        // GET: Acesso/Create
        public ActionResult Create()
        {
            ViewBag.COD_ALUNO = new SelectList(db.TB_ALUNO, "COD_ALUNO", "NOME");
            return View();
        }

        // POST: Acesso/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_ACESSO,DATA,HORA_ENTRADA,HORA_SAIDA,COD_ALUNO")] TB_ACESSO tB_ACESSO)
        {
            if (ModelState.IsValid)
            {
                db.TB_ACESSO.Add(tB_ACESSO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COD_ALUNO = new SelectList(db.TB_ALUNO, "COD_ALUNO", "NOME", tB_ACESSO.COD_ALUNO);
            return View(tB_ACESSO);
        }

        // GET: Acesso/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_ACESSO tB_ACESSO = db.TB_ACESSO.Find(id);
            if (tB_ACESSO == null)
            {
                return HttpNotFound();
            }
            ViewBag.COD_ALUNO = new SelectList(db.TB_ALUNO, "COD_ALUNO", "NOME", tB_ACESSO.COD_ALUNO);
            return View(tB_ACESSO);
        }

        // POST: Acesso/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_ACESSO,DATA,HORA_ENTRADA,HORA_SAIDA,COD_ALUNO")] TB_ACESSO tB_ACESSO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_ACESSO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COD_ALUNO = new SelectList(db.TB_ALUNO, "COD_ALUNO", "NOME", tB_ACESSO.COD_ALUNO);
            return View(tB_ACESSO);
        }

        // GET: Acesso/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_ACESSO tB_ACESSO = db.TB_ACESSO.Find(id);
            if (tB_ACESSO == null)
            {
                return HttpNotFound();
            }
            return View(tB_ACESSO);
        }

        // POST: Acesso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TB_ACESSO tB_ACESSO = db.TB_ACESSO.Find(id);
            db.TB_ACESSO.Remove(tB_ACESSO);
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
