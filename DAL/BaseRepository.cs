using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public abstract class BaseRepository<T> : IRepositorio<T> where T : class
    {
        protected Entities ctx;
        DbSet<T> dbSet;

        public BaseRepository(Entities contexto)
        {
            ctx = contexto;
            dbSet = ctx.Set<T>();
        }

        public virtual void Alta(T m)
        {
            dbSet.Add(m);
            ctx.SaveChanges();
        }

        public virtual List<T> ObtenerTodos()
        {
            return dbSet.ToList();
        }

        public virtual T ObtenerPorId(int id)
        {
            T p = dbSet.Find(id);

            return p;
        }

        public virtual void Eliminar(int id)
        {
            T m = ObtenerPorId(id);

            if (m != null)
            {
                dbSet.Remove(m);
            }

            ctx.SaveChanges();
        }

        public abstract void Modificar(T m);

    }
}
