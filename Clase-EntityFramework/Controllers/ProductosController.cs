using DAL;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clase_EntityFramework.Controllers
{
    public class ProductosController : Controller
    {
        // GET: Productos
        public ActionResult Lista()
        {
            ProductoServicio prodServicio = new ProductoServicio();
            List<Producto> productos = prodServicio.ObtenerTodos();
            return View(productos);
        }
    }
}