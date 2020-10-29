using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class CategoriaServicio : BaseServicio<CategoriaRepositorio, Categoria>
    {
        public CategoriaServicio(Entities contexto) : base(contexto)
        {
            
        }

        public List<Categoria> ObtenerPorIds(int[] ids)
        {
            return repo.ObtenerPorIds(ids);
        }
    }
}
