using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ProductoServicio
    {
        ProductoRepositorio repo;

        public ProductoServicio(Entities contexto)
        {
            Entities ctx = contexto;
            repo = new ProductoRepositorio(ctx);
        }

        public void Alta(Producto p)
        {
            repo.Alta(p);  
        }

        public List<Producto> ObtenerTodos()
        {
            return repo.ObtenerTodos();
        }

        public Producto ObtenerPorId(int idProducto)
        {
            return repo.ObtenerPorId(idProducto);
        }

        public void Eliminar(int idProducto)
        {
             repo.Eliminar(idProducto);
        }

        public void Modificar(Producto p)
        {
             repo.Modificar(p);
        }
    }
}
