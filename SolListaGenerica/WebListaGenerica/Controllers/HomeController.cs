using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebListaGenerica.Models.Business;
using WebListaGenerica.Models.Business.Entitys;

namespace WebListaGenerica.Controllers
{
    public class HomeController : Controller
    {
        BusMascota business = new BusMascota();
        public ActionResult Index()
        {
            try
            {
                List<EntMascota> ls = business.Obtener();
                return View(ls);
            }
            catch (Exception ex)
            {

                TempData["error"] = ex.Message;
                return View(new List<EntMascota>());
            }
        }

        [HttpGet]
        public ActionResult Agregar()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("Index", business.Obtener());
            }
        }

        [HttpPost]
        public ActionResult Agregar(EntMascota m)
        {
            try
            {
                business.ValidarNombreRepetidoAgregar(m);
                business.Agregar(m);
                TempData["mensaje"] = "Se agrego correctamente a " + m.NombreRazaEspecie;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("Agregar");
            }
        }

        public ActionResult Prueba()
        {
            return View();
        }
    }
}