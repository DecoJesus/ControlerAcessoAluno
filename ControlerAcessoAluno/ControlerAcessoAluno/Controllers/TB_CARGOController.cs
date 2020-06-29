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
    public class TB_CARGOController : Controller
    {
        private CONTROLEACESSOEntities db = new CONTROLEACESSOEntities();

        // GET: TB_CARGO
        public ActionResult Index()
        {
            return View(db.TB_CARGO.ToList());
        }

        // GET: TB_CARGO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_CARGO tB_CARGO = db.TB_CARGO.Find(id);
            if (tB_CARGO == null)
            {
                return HttpNotFound();
            }
            return View(tB_CARGO);
        }

        // GET: TB_CARGO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TB_CARGO/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_CARGO,CARGO")] TB_CARGO tB_CARGO)
        {
            if (ModelState.IsValid)
            {
                db.TB_CARGO.Add(tB_CARGO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tB_CARGO);
        }

        // GET: TB_CARGO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_CARGO tB_CARGO = db.TB_CARGO.Find(id);
            if (tB_CARGO == null)
            {
                return HttpNotFound();
            }
            return View(tB_CARGO);
        }

        // POST: TB_CARGO/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_CARGO,CARGO")] TB_CARGO tB_CARGO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_CARGO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tB_CARGO);
        }

        // GET: TB_CARGO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_CARGO tB_CARGO = db.TB_CARGO.Find(id);
            if (tB_CARGO == null)
            {
                return HttpNotFound();
            }
            return View(tB_CARGO);
        }

        // POST: TB_CARGO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TB_CARGO tB_CARGO = db.TB_CARGO.Find(id);
            db.TB_CARGO.Remove(tB_CARGO);
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
