using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class BaseServicio<T, J> : IServicio<J> where T : BaseRepository<J> where J : class
    {
        protected T repo;
        public BaseServicio(Entities contexto)
        {
            Entities ctx = contexto;
            repo = Activator.CreateInstance(typeof(T), new object[] { contexto }) as T; 
        }

        public void Alta(J p)
        {
            repo.Alta(p);
        }

        public void Eliminar(int id)
        {
            repo.Eliminar(id);
        }

        public void Modificar(J p)
        {
            repo.Modificar(p);
        }

        public J ObtenerPorId(int id)
        {
            return repo.ObtenerPorId(id);
        }

        public List<J> ObtenerTodos()
        {
            return repo.ObtenerTodos();
        }
    }
}
