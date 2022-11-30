using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Producto
    {
        public int idProducto { get; set; }
        public string nombreProducto { get; set; }
        public double precio { get; set; }
        public Tienda tienda { get; set; }
        public override string ToString()
        {
            return $"{idProducto};{nombreProducto};{precio};{tienda.nitTienda}"; 
        }
    }
}
