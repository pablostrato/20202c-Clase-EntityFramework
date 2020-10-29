using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductoRepositorio : BaseRepository<Producto>
    {
        public ProductoRepositorio(Entities contexto) : base(contexto)
        {
        }
    
        public override Producto ObtenerPorId(int idProducto)
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

        public List<Producto> ObtenerPorMarca(int? idMarca)
        {
            return ctx.Productoes.Where(o => o.IdMarca == idMarca).ToList();
        }

        public override void Modificar(Producto p)
        {
            Producto prodActual = ObtenerPorId(p.IdProducto);
            prodActual.Nombre = p.Nombre;
            prodActual.Precio = p.Precio;
            prodActual.IdMarca = p.IdMarca;

            prodActual.Categorias.Clear();

            prodActual.Categorias = p.Categorias;

            ctx.SaveChanges();
        }

    }
}
