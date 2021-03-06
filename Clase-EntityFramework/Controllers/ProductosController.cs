﻿using DAL;
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
        CategoriaServicio catServicio;
        Entities contexto;


        public ProductosController()
        {
            contexto = new Entities();
            prodServicio = new ProductoServicio(contexto);
            marcaServicio = new MarcaServicio(contexto);
            catServicio = new CategoriaServicio(contexto);
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
            CargarListasEnViewBag();

            return View();
        }

        private void CargarListasEnViewBag()
        {
            CargarMarcasEnViewBag();
            CargarCategoriasEnViewBag();
        }

        private void CargarMarcasEnViewBag()
        {
            List<Marca> marcas = marcaServicio.ObtenerTodos();
            ViewBag.Marcas = marcas;
        }

        private void CargarCategoriasEnViewBag()
        {
            List<Categoria> categorias = catServicio.ObtenerTodos();
            ViewBag.Categorias = categorias;
        }

        [HttpPost]
        public ActionResult Alta(Producto p, string otraMarca, int[] idCategoria)
        {
            if (!ModelState.IsValid)
            {
                CargarListasEnViewBag();
                return View();
            }

            if (!string.IsNullOrEmpty(otraMarca))
            {
                Marca marca = new Marca();
                marca.Nombre = otraMarca;
                marcaServicio.Alta(marca);

                p.Marca = marca;
            }

            if (idCategoria.Length > 0)
            {
                List<Categoria> categoriasElegidas = catServicio.ObtenerPorIds(idCategoria);
                p.Categorias = categoriasElegidas;
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

            CargarListasEnViewBag();
            return View(prod);
        }

        [HttpPost]
        public ActionResult Modificar(Producto prod, int[] idCategoria)
        {
            if (!ModelState.IsValid)
            {
                CargarMarcasEnViewBag();
                return View(prod);
            }

            if (idCategoria.Length > 0)
            {
                List<Categoria> categoriasElegidas = catServicio.ObtenerPorIds(idCategoria);
                prod.Categorias = categoriasElegidas;
            }

            prodServicio.Modificar(prod);

            return Redirect("/productos/lista");
        }

        public ActionResult ProductosSinCategoria()
        {
            List<DAL.Producto> productosSinCat = contexto.ObtenerProductosSinCategoria().ToList();
            return View(productosSinCat);
        }
    }
}