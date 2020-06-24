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
    public class AlunoController : Controller
    {
        private CONTROLEACESSOEntities db = new CONTROLEACESSOEntities();

        // GET: Aluno
        public ActionResult Index()
        {
            return View(db.TB_ALUNO.ToList());
        }

        // GET: Aluno/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_ALUNO tB_ALUNO = db.TB_ALUNO.Find(id);
            if (tB_ALUNO == null)
            {
                return HttpNotFound();
            }
            return View(tB_ALUNO);
        }

        // GET: Aluno/Create
        public ActionResult Create()
        {
            //Aqui está montando o conteúdo a ser apresentado
            //no combobox de turma. Value é o valor que será submetido
            //caso o item seja selecionado e Text é o valor que será 
            //apresentado no campo.
            //Seria muito se eu tivesse adicionado "Turma"(A, B, C, D e etc) por exemplo.
            //Acho que estám faltando isso no seu modelo  

            var Turmas = db.TB_TURMA.Select(t => new SelectListItem
            {
                Value = t.COD_TURMA + "",
                Text = t.TB_CURSO.NOME_CURSO.Substring(0, 3) + t.SERIE + t.PERIODO.Substring(0, 1)
            });
            ViewBag.Turmas = Turmas;

            return View();
        }

        // POST: Aluno/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "COD_ALUNO,NOME,RM,DATA_NASCIENTO,SEXO")] TB_ALUNO tB_ALUNO)
        public ActionResult Create(MatriculaAluno matricula)//vai pegar os dados que estão inseridos na classe MatriculaAluno
        {

            TB_ALUNO tB_ALUNO = matricula.TB_ALUNO;

            if (ModelState.IsValid)
            {
                db.TB_ALUNO.Add(tB_ALUNO);
                db.SaveChanges();

                TB_TURMA tB_TURMA = db.TB_TURMA.Find(matricula.COD_TURMA);
                TB_ALUNO_TURMA tB_ALUNO_TURMA = new TB_ALUNO_TURMA
                {
                    ANO = DateTime.Today.Year + "",
                    COD_ALUNO = tB_ALUNO.COD_ALUNO,
                    COD_TURMA = tB_TURMA.COD_TURMA,
                    SEMESTRE = "1", //obs: Precisa ver de onde vai tirar essa informacao. 
                    //Acredito que o semestre deveria estar acessível através da turma, 
                    //mas turma não tem essa informação, entao, acho que está faltando...

                };
                db.TB_ALUNO_TURMA.Add(tB_ALUNO_TURMA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tB_ALUNO);
        }

        // GET: Aluno/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_ALUNO tB_ALUNO = db.TB_ALUNO.Find(id);
            if (tB_ALUNO == null)
            {
                return HttpNotFound();
            }
            return View(tB_ALUNO);
        }

        // POST: Aluno/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_ALUNO,NOME,RM,DATA_NASCIMENTO,SEXO")] TB_ALUNO tB_ALUNO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_ALUNO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tB_ALUNO);
        }

        // GET: Aluno/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_ALUNO tB_ALUNO = db.TB_ALUNO.Find(id);
            if (tB_ALUNO == null)
            {
                return HttpNotFound();
            }
            return View(tB_ALUNO);
        }

        // POST: Aluno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TB_ALUNO tB_ALUNO = db.TB_ALUNO.Find(id);
            db.TB_ALUNO.Remove(tB_ALUNO);
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
