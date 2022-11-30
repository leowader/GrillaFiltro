using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Filtro
    {
        RepositorioProduct RepositorioProduct = new RepositorioProduct();
        public List<Producto> FiltroGeneral(string name)
        {
            List<Producto> listFiltro = new List<Producto>();
            foreach (var item in RepositorioProduct.leer())
            {
                string id=Convert.ToString(item.idProducto);
                string precio = Convert.ToString(item.precio);
                string nombreTienda = item.tienda.nombreTienda;
                if (item.nombreProducto.StartsWith(name)||id.StartsWith(name)
                    ||precio.StartsWith(name)||nombreTienda.StartsWith(name))
                {
                    listFiltro.Add(item);
                }
            }
            return listFiltro;
        }
    }
}
