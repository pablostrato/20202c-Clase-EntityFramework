using DAL;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clase_EntityFramework.Controllers
{
    public class MarcasController : Controller
    {
        MarcaServicio marcaServicio;

        public MarcasController()
        {
            Entities contexto = new Entities();
            marcaServicio = new MarcaServicio(contexto);
        }

        public ActionResult Lista()
        {
            List<Marca> marcas = marcaServicio.ObtenerTodos();
            return View(marcas);
        }

        public ActionResult Eliminar(int id)
        {
            Marca m = marcaServicio.ObtenerPorId(id);
            return View(m);
        }

        [HttpPost]
        public ActionResult Eliminar(Marca m)
        {
            marcaServicio.Eliminar(m.IdMarca);
            return Redirect("/marcas/lista");
        }


        public ActionResult Cancelar()
        {
            return Redirect("/marcas/lista");
        }
    }
}