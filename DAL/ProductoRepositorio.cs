using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductoRepositorio
    {
        Entities ctx;

        public ProductoRepositorio(Entities contexto)
        {
            ctx = contexto;
        }
        //Eliminar
        //ObtenerTodos
        //ObtenerPorId
        //Modificar

        public void Alta(Producto p)
        {
            ctx.Productoes.Add(p);
            ctx.SaveChanges();
        }

        public List<Producto> ObtenerTodos()
        {
            return ctx.Productoes.ToList();
        }

        public Producto ObtenerPorId(int idProducto)
        {
            Producto p;
            //LinQ
            p = (from prod in ctx.Productoes
                 where prod.IdProducto == idProducto
                 select prod).FirstOrDefault();

            //Expresions Lambda
            p = ctx.Productoes.FirstOrDefault(p1 => p1.IdProducto == idProducto);
            
            //Find
            p = ctx.Productoes.Find(idProducto);

            return p;
        }

        public void Eliminar(int idProducto)
        {
            Producto p = ObtenerPorId(idProducto);
            if (p != null)
            {
                ctx.Productoes.Remove(p);
            }

            ctx.SaveChanges();
        }

        public void Modificar(Producto p)
        {
            Producto prodActual = ObtenerPorId(p.IdProducto);
            prodActual.Nombre = p.Nombre;
            prodActual.Precio = p.Precio;

            ctx.SaveChanges();
        }

    }
}
