using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class manttoProductos
    {
        BDConex conn = new BDConex();

        public DataTable dataProducto = new DataTable();

        private int productoId, existencia;
        private String descripcion;
        private double costo, precio;

        #region GET Y SET

        public int Existencia
        {
            get { return existencia; }
            set { existencia = value; }
        }

        public int ProductoId
        {
            get { return productoId; }
            set { productoId = value; }
        }

        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public double Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        public double Costo
        {
            get { return costo; }
            set { costo = value; }
        }
        #endregion

        public void insertarProducto()
        {
            try
            {
                String insert = "INSERT INTO Productos(ProductoId, Descripcion, Costo, Precio, Existencia) VALUES ("
                    + productoId + ", '" + descripcion + "', " + costo + ", " + precio + ", " + existencia + ")";
                conn.Conectar();
                conn.consultaSQL(insert);
                conn.Desconectar();
            }
            catch
            {
            }
        }

        public void deleteProducto()
        {
            try
            {
                String delete = "DELETE FROM Productos WHERE ProductoId = " + productoId + "";
                conn.Conectar();
                conn.consultaSQL(delete);
                conn.Desconectar();
            }
            catch
            {
            }
        }

        public void updateProducto()
        {
            try
            {
                String update = "UPDATE Productos SET Descripcion = '" + descripcion + "', Costo = " + costo + ", Existencia = " + existencia + ", Precio = "
                    + precio + " where ProductoId = " + productoId + "";

                conn.Conectar();
                conn.consultaSQL(update);
                conn.Desconectar();
            }
            catch
            {
            }
        }

        //Llenar el DataGridView
        public void mostrarProducto()
        {
            try
            {
                String consulta = "select * from Productos";
                conn.Conectar();
                conn.mostrarSQL(consulta);
                conn.da.Fill(dataProducto);
                conn.Desconectar();
            }
            catch
            {
            }
        }
    }
}
