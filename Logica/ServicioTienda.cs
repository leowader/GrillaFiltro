using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class ServicioTienda
    {
        RepositorioTienda RepositorioTienda = new RepositorioTienda();
        public List<Tienda> Mostrar()
        {
            return RepositorioTienda.leer();
        }
        public Tienda buscarTienda(string name)
        {
            Tienda tienda = new Tienda();
            foreach (var item in RepositorioTienda.leer())
            {
                if (item.nombreTienda.Equals(name))
                {
                    tienda = item;
                }
                
            }
            return tienda;
        }
    }
}
