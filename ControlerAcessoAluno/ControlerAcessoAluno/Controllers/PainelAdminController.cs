using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlerAcessoAluno.Controllers
{
    public class PainelAdminController : Controller
    {
        // GET: PainelAdmin
        public ActionResult Index()
        {
            return View();
        }
    }
}