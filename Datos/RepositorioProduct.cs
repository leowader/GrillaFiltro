using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class RepositorioProduct:Archivo
    {
        public RepositorioProduct()
        {
            ruta = "productos.txt";
        }
        public string guardar(Producto producto)
        {
            try
            {
                StreamWriter streamWriter = new StreamWriter(ruta,true);
                streamWriter.WriteLine(producto.ToString());
                streamWriter.Close();   
                return $"producto: {producto.nombreProducto} guardado";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
            
        }
        public List<Producto> leer()
        {
            List<Producto> lista = new List<Producto>();
            StreamReader reader = new StreamReader(ruta);
            while (!reader.EndOfStream)
            {
                lista.Add(maper(reader.ReadLine()));
            }
            reader.Close();
            return lista;
        }
        public Producto maper(string linea)
        {
            Producto producto = new Producto();
            producto.idProducto = int.Parse (linea.Split(';')[0]);
            producto.nombreProducto = linea.Split(';')[1];
            producto.precio = double.Parse(linea.Split(';')[2]);
            producto.tienda=BuscarTienda(int.Parse(linea.Split(';')[3]));
            return producto;
        }
        RepositorioTienda RepositorioTienda = new RepositorioTienda();
        public Tienda BuscarTienda(int nit)
        {
            var tienda = new Tienda();  
            foreach (var item in RepositorioTienda.leer())
            {
                if (item.nitTienda.Equals(nit))
                {
                    tienda=item;
                }
            }
            return tienda;
        }
    }
}
