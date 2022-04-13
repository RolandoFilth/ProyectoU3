using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taqueria.Linq.Data.Entity
{
    public partial class TipoProducto
    {
        public override string ToString()
        {
            return this.Nombre;
        }
    }
}
