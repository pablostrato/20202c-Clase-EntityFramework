using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAL
{
    public class MarcaRepositorio
    {
        Entities ctx;

        public MarcaRepositorio(Entities contexto)
        {
            ctx = contexto;
        }

        //Eliminar
        //ObtenerTodos
        //ObtenerPorId
        //Modificar

        public void Alta(Marca m)
        {
            ctx.Marcas.Add(m);
            ctx.SaveChanges();
        }

        public List<Marca> ObtenerTodos()
        {
            return ctx.Marcas.ToList();
        }

        public Marca ObtenerPorId(int idMarca)
        {
            Marca p;
            
            //Find
            p = ctx.Marcas.Find(idMarca);

            return p;
        }

        public void Eliminar(int idMarca)
        {
            ProductoRepositorio prodRepositorio = new ProductoRepositorio(ctx);

            Marca m = ObtenerPorId(idMarca);

            //opcion para que los productos ahora tengan idmarca = null
            //m.Productoes.Clear();


            //eliminar cada producto de la marca
            foreach (Producto p in m.Productoes.ToList())
            {
                prodRepositorio.Eliminar(p.IdProducto);    
            }

            if (m != null)
            {
                ctx.Marcas.Remove(m);
            }

            ctx.SaveChanges();
        }

        public void Modificar(Marca m)
        {
            Marca prodActual = ObtenerPorId(m.IdMarca);
            prodActual.Nombre = m.Nombre;

            ctx.SaveChanges();
        }

    }
}
