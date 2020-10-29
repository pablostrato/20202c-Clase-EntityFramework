using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAL
{
    public class CategoriaRepositorio : BaseRepository<Categoria>
    {
        public CategoriaRepositorio(Entities contexto) : base(contexto)
        {
           
        }

        public override void Modificar(Categoria m)
        {
            Categoria catActual = ObtenerPorId(m.IdCategoria);
            catActual.Nombre = m.Nombre;

            ctx.SaveChanges();
        }

        public List<Categoria> ObtenerPorIds(int[] ids)
        {
            return ctx.Categorias.Where(o => ids.Contains(o.IdCategoria)).ToList();
;        }
    }
}
