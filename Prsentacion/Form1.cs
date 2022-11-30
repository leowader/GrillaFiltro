using Entidades;
using Logica;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prsentacion
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
            cargarCb();
        }
        ServicioTienda ServicioTienda = new ServicioTienda();
        void cargarCb()
        {
            var lista = ServicioTienda.Mostrar();
            foreach (var item in lista)
            {
                CbTienda.Items.Add(item.nombreTienda);
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            guardar();
            cargargrilla();
        }
        Logica.ServicoProduct ServicoProduct = new Logica.ServicoProduct();
        Filtro Filtros = new Filtro();
        void guardar()
        {
            try
            {
                var producto = new Producto();
                producto.idProducto = int.Parse(txtId.Text);
                producto.nombreProducto = txtNombre.Text;
                producto.precio = double.Parse(txtPrecio.Text);
                producto.tienda = ServicioTienda.buscarTienda(CbTienda.SelectedItem.ToString());
                var men = ServicoProduct.guardar(producto);
                MessageBox.Show(men);
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }
        void cargargrilla()
        {
            var lista = ServicoProduct.Mostrar();
            foreach (var item in lista)
            {
                GrillaProducto.Rows.Add(item.idProducto,item.nombreProducto,
                item.precio,item.tienda.nombreTienda);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargargrilla();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            buscar(txtBuscar.Text);
        }
        void buscar(string name)
        {
            GrillaProducto.Rows.Clear();
            var lista=Filtros.FiltroGeneral(name);
            //GrillaProducto.ClearSelection();
            //GrillaProducto.DataSource = lista;
            foreach (var item in lista)
            {
                GrillaProducto.Rows.Add(item.idProducto, item.nombreProducto,
                item.precio, item.tienda.nombreTienda);
            }
        }
        void limpiar()
        {
            txtId.Clear();
            txtNombre.Clear();
            txtPrecio.Clear();
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("TROLLEADO PUTOOO","TROLL",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }
    }
}
