using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class RepositorioTienda:Archivo
    {
        public RepositorioTienda()
        {
            ruta = "tienda.txt";
        }
        public List<Tienda> leer()
        {
            List<Tienda> lista = new List<Tienda>();
            StreamReader reader = new StreamReader(ruta);
            while (!reader.EndOfStream)
            {
                lista.Add(mapear(reader.ReadLine()));
            }
            return lista;
        }
        public Tienda mapear(string linea)
        {
            Tienda tienda = new Tienda();
            tienda.nitTienda = int.Parse(linea.Trim().Split(';')[0]);
            tienda.nombreTienda = linea.Trim().Split(';')[1];
            return tienda;
        }
    }
}
