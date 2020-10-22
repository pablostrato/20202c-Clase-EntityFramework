using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class MarcaServicio
    {
        MarcaRepositorio repo;

        public MarcaServicio(Entities contexto)
        {
            Entities ctx = contexto;
            repo = new MarcaRepositorio(ctx);
        }

        public void Alta(Marca p)
        {
            repo.Alta(p);
        }

        public List<Marca> ObtenerTodos()
        {
            return repo.ObtenerTodos();
        }

        public Marca ObtenerPorId(int idMarca)
        {
            return repo.ObtenerPorId(idMarca);
        }

        public void Eliminar(int idMarca)
        {
            repo.Eliminar(idMarca);
        }

        public void Modificar(Marca p)
        {
            repo.Modificar(p);
        }
    }
}
