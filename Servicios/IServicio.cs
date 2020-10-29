using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    interface IServicio<T>
    {
        void Alta(T p);

        List<T> ObtenerTodos();

        T ObtenerPorId(int id);

        void Eliminar(int id);

        void Modificar(T p);
    }
}
