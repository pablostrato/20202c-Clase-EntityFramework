using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ProductoServicio : BaseServicio<ProductoRepositorio, Producto>
    {
        public ProductoServicio(Entities contexto) : base(contexto)
        {
            
        }
        
        public List<Producto> ObtenerPorMarca(int? idMarca)
        {
            return repo.ObtenerPorMarca(idMarca);
        }
    }
}
