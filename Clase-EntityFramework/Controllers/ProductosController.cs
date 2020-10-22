﻿using DAL;
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
        ProductoServicio prodServicio;
        MarcaServicio marcaServicio;


        public ProductosController()
        {
            Entities contexto = new Entities();
            prodServicio = new ProductoServicio(contexto);
            marcaServicio = new MarcaServicio(contexto);
        }

        // GET: Productos
        public ActionResult Lista()
        {
            List<Producto> productos = prodServicio.ObtenerTodos();
            return View(productos);
        }

        public ActionResult Alta()
        {
            return View(new Producto());
        }

        [HttpPost]
        public ActionResult Alta(Producto p)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Marca m1 = marcaServicio.ObtenerTodos().FirstOrDefault();
            p.Marca = m1;

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
    }
}