using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class ServicoProduct
    {
        List<Producto> listProduct;
        RepositorioProduct RepositorioProduct = new RepositorioProduct();
        public ServicoProduct()
        {
            listProduct = RepositorioProduct.leer();
        }
        public void actualizarList()
        {
            listProduct = RepositorioProduct.leer();
        }
        public string guardar(Producto producto)
        {
            try
            {
                var men=RepositorioProduct.guardar(producto);
                return men;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public List<Producto> Mostrar()
        {
            actualizarList();
            return listProduct;
        }
    }
}
