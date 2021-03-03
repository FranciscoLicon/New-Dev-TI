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

        public ActionResult Buscar(string nombreMascota)
        {
            try
            {
                List<EntMascota> ls = business.Obtener(nombreMascota);
                return View("Index",ls);
            }
            catch (Exception ex)
            {

                TempData["error"] = ex.Message;
                return View("Index",new List<EntMascota>());
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
                TempData["mensaje"] = "Se agregó correctamente a " + m.NombreRazaEspecie;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("Agregar");
            }
        }

        public ActionResult Editar(int id)
        {
            try
            {
                EntMascota m = business.Obtener(id);
                return View(m);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("Index", business.Obtener());
            }
        }

        [HttpPost]
        public ActionResult Editar(EntMascota m)
        {
            try
            {
                business.ValidarNombreRepetidoEditar(m);
                business.Editar(m);
                TempData["mensaje"] = "Se editó correctamente a " + m.NombreRazaEspecie;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                
                TempData["error"] = ex.Message;
                return View("Editar",m);
            }
        }

        public ActionResult Borrar(int id)
        {
            EntMascota m = business.Obtener(id);
            business.Borrar(m);
            return View("Index", business.Obtener());
        }

        public ActionResult Prueba()
        {
            return View();
        }
    }
}