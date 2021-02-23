using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MGP.CI.SEGURIDAD.Presentacion.ViewModels;

namespace MGP.CI.SEGURIDAD.Presentacion.Controllers
{
    public class LoginController : Controller
    {
        [Route("index")]
        public ActionResult Index()
        {

            return View(new LoginViewModel());
        }

        [HttpPost]
        public ActionResult Log_in(LoginViewModel vm)
        {
            if (Session["objsesion"] != null) return RedirectToAction("index", "Usuario");
            SesionViewModel sesionVM = vm.ValidarLogin();
            if (vm.ErrorSMS.Length == 0)
            {
                Session["objsesion"] = sesionVM;
                return RedirectToAction("index", "XP1003");
            }
            else
                return View("index", vm);
        }
        [HttpGet]
        public ActionResult Log_out()
        {
            LoginViewModel vm = new LoginViewModel();
            SesionViewModel sesionVM = (SesionViewModel)Session["objsesion"];

            vm.LogOut(sesionVM.UsuarioId, 1, sesionVM.Login);

            Session["objsesion"] = null;
            return RedirectToAction("index");
        }

    }
}