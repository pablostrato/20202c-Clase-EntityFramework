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
            Marca p = ObtenerPorId(idMarca);
            if (p != null)
            {
                ctx.Marcas.Remove(p);
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
