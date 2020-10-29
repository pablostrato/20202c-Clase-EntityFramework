using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAL
{
    public class MarcaRepositorio : BaseRepository<Marca>
    {
        public MarcaRepositorio(Entities contexto) : base(contexto)
        {
           
        }

        public override void Eliminar(int idMarca)
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

        public override void Modificar(Marca m)
        {
            Marca prodActual = ObtenerPorId(m.IdMarca);
            prodActual.Nombre = m.Nombre;

            ctx.SaveChanges();
        }

    }
}
