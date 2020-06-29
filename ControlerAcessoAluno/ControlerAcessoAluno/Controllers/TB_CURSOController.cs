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
    public class TB_CURSOController : Controller
    {
        private CONTROLEACESSOEntities db = new CONTROLEACESSOEntities();

        // GET: TB_CURSO
        public ActionResult Index()
        {
            return View(db.TB_CURSO.ToList());
        }

        // GET: TB_CURSO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_CURSO tB_CURSO = db.TB_CURSO.Find(id);
            if (tB_CURSO == null)
            {
                return HttpNotFound();
            }
            return View(tB_CURSO);
        }

        // GET: TB_CURSO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TB_CURSO/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_CURSO,NOME_CURSO")] TB_CURSO tB_CURSO)
        {
            if (ModelState.IsValid)
            {
                db.TB_CURSO.Add(tB_CURSO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tB_CURSO);
        }

        // GET: TB_CURSO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_CURSO tB_CURSO = db.TB_CURSO.Find(id);
            if (tB_CURSO == null)
            {
                return HttpNotFound();
            }
            return View(tB_CURSO);
        }

        // POST: TB_CURSO/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_CURSO,NOME_CURSO")] TB_CURSO tB_CURSO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_CURSO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tB_CURSO);
        }

        // GET: TB_CURSO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_CURSO tB_CURSO = db.TB_CURSO.Find(id);
            if (tB_CURSO == null)
            {
                return HttpNotFound();
            }
            return View(tB_CURSO);
        }

        // POST: TB_CURSO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TB_CURSO tB_CURSO = db.TB_CURSO.Find(id);
            db.TB_CURSO.Remove(tB_CURSO);
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
