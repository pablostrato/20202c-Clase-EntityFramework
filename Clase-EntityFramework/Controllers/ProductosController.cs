using DAL;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;

namespace Clase_EntityFramework.Controllers
{
    public class ProductosController : Controller
    {
        ProductoServicio prodServicio;
        MarcaServicio marcaServicio;


        public ProductosController()
        {
            Entities contexto = new Entities();
            prodServicio = new ProductoServicio(contexto);
            marcaServicio = new MarcaServicio(contexto);
        }

        // GET: Productos
        public ActionResult Lista(int? id)
        {
            List<Producto> productos;
            CargarMarcasEnViewBag();
            if (id.HasValue)
            {
                ViewBag.IdMarcaElegida = id.Value;
                productos = prodServicio.ObtenerPorMarca(id);
            }
            else
            {
                productos = prodServicio.ObtenerTodos();
            }

            return View(productos);
        }

        [HttpPost]
        public ActionResult ListaPost(int? idMarca)
        {
            return Redirect($"/productos/lista/{idMarca}");
        }

        public ActionResult Alta()
        {
            CargarMarcasEnViewBag();

            return View();
        }

        private void CargarMarcasEnViewBag()
        {
            List<Marca> marcas = marcaServicio.ObtenerTodos();
            ViewBag.Marcas = marcas;
        }

        [HttpPost]
        public ActionResult Alta(Producto p, string otraMarca)
        {
            if (!ModelState.IsValid)
            {
                CargarMarcasEnViewBag();
                return View();
            }

            if (!string.IsNullOrEmpty(otraMarca))
            {
                Marca marca = new Marca();
                marca.Nombre = otraMarca;
                marcaServicio.Alta(marca);

                p.Marca = marca;
            }

            prodServicio.Alta(p);
            return Redirect("/productos/lista");
        }

        public ActionResult Cancelar()
        {
            return Redirect("/productos/lista");
        }

        public ActionResult Eliminar(int id)
        {
            Producto p = prodServicio.ObtenerPorId(id);
            return View(p);
        }

        [HttpPost]
        public ActionResult Eliminar(Producto p, string accion)
        {
            switch (accion)
            {
                case "Eliminar":
                    prodServicio.Eliminar(p.IdProducto);
                    return Redirect("/productos/lista");

                case "Cancelar":
                    return Redirect("/productos/lista");
            }
            return View();
        }

        public ActionResult Modificar(int id)
        {
            Producto prod = prodServicio.ObtenerPorId(id);
            if (prod == null)
            {
                TempData["Message"] = "El producto elegido no existe";
                return Redirect("/productos/lista");
            }

            CargarMarcasEnViewBag();
            return View(prod);
        }

        [HttpPost]
        public ActionResult Modificar(Producto prod)
        {
            if (!ModelState.IsValid)
            {
                CargarMarcasEnViewBag();
                return View(prod);
            }

            prodServicio.Modificar(prod);

            return Redirect("/productos/lista");
        }
    }
}