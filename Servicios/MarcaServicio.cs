using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class MarcaServicio : BaseServicio<MarcaRepositorio, Marca>
    {
        public MarcaServicio(Entities contexto) : base(contexto)
        {
         
        }
    }
}
