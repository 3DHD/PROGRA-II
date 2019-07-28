using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class MantenimientoProductos : Form
    {
        manttoProductos manProd = new manttoProductos();

        public MantenimientoProductos()
        {
            InitializeComponent();

            //Iniciar el datagrid lleno
            manProd.dataProducto.Clear();
            dataGridView1.Refresh();
            manProd.mostrarProducto();
            dataGridView1.DataSource = manProd.dataProducto;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //Limpiar controles
        public void limpiar()
        {
            txtCodigoProducto.Text = "";
            txtDescripcion.Text = "";
            txtCosto.Text = "";
            txtPrecio.Text = "";
            txtExistencia.Text = "";

        }

        //Actualizar el datagrid despues de eliminar, actualizar o guardar
        public void cargar()
        {
            manProd.dataProducto.Clear();
            dataGridView1.Refresh();
            manProd.mostrarProducto();
            dataGridView1.DataSource = manProd.dataProducto;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtCodigoProducto.Text.Equals("") || txtDescripcion.Text.Equals(""))
            {
                DialogResult result = MessageBox.Show("Codigo y Nombre de producto son necesarios", "Informacion", MessageBoxButtons.OK);
            }
            else
            {
                manProd.ProductoId = int.Parse(txtCodigoProducto.Text);
                manProd.Descripcion = txtDescripcion.Text;
                manProd.Costo = double.Parse(txtCosto.Text);
                manProd.Precio = double.Parse(txtPrecio.Text);
                manProd.Existencia = int.Parse(txtExistencia.Text);

                DialogResult result = MessageBox.Show("Registro almacenado", "Guardar", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    manProd.insertarProducto();
                    limpiar();
                    cargar();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtCodigoProducto.Text.Equals(""))
            {
                DialogResult result = MessageBox.Show("Indique el codigo a eliminar", "Informacion", MessageBoxButtons.OK);
            }
            else
            {
                manProd.ProductoId = int.Parse(txtCodigoProducto.Text);

                DialogResult result = MessageBox.Show("Seguro que desea eliminar?", "Eliminar", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    manProd.deleteProducto();
                    limpiar();
                    cargar();
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (txtCodigoProducto.Text.Equals("") || txtDescripcion.Text.Equals(""))
            {
                DialogResult result = MessageBox.Show("Codigo y Nombre son necesarios", "Informacion", MessageBoxButtons.OK);
            }
            else
            {
                manProd.ProductoId = int.Parse(txtCodigoProducto.Text);
                manProd.Descripcion = txtDescripcion.Text;
                manProd.Costo = double.Parse(txtCosto.Text);
                manProd.Precio = double.Parse(txtPrecio.Text);
                manProd.Existencia = int.Parse(txtExistencia.Text);

                manProd.updateProducto();
                limpiar();
                cargar();
            }
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                String productoId = dataGridView1.SelectedRows[0].Cells[0].Value + String.Empty;
                String descripcion = dataGridView1.SelectedRows[0].Cells[2].Value + String.Empty;
                String costo = dataGridView1.SelectedRows[0].Cells[3].Value + String.Empty;
                String precio = dataGridView1.SelectedRows[0].Cells[4].Value + String.Empty;
                String existencias = dataGridView1.SelectedRows[0].Cells[5].Value + String.Empty;




                txtCodigoProducto.Text = productoId;
                txtDescripcion.Text = descripcion;
                txtCosto.Text = costo;
                txtPrecio.Text = precio;
                txtExistencia.Text = existencias;

            }
        }
    }
}
