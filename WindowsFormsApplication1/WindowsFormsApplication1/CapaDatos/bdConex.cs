using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class bdConex
    {
        SqlDataAdapter adaptador;
        SqlCommand comm;
        SqlConnection conexion = new SqlConnection();
        SqlCommand comando;
        public SqlDataAdapter da;

        String cadenaConex = "Data Source=.;Initial Catalog=Facturacion_PGRII;Integrated Security=True";

        public SqlConnection Conexion
        {
            get { return conexion; }
            set { conexion = value; }
        }

        public bool Conectar() {
            bool conn = false;
            try
            {
                conexion.ConnectionString = cadenaConex;
                conexion.Open();
                conn = true;
            }
            catch (Exception ex){
                conn = false;
            }
            return conn;
        }

        public void Desconectar() {
            conexion.Close();
        }

        public void consultaSQL(String consulta) {
            string mensaje = "";
            try {
                comando = new SqlCommand(consulta, conexion);
                comando.ExecuteNonQuery();
                mensaje = "Correctamente";
            }
            catch (Exception ex) {
                mensaje = "Error!!";
            }
        }

        public void mostrarSQL(String consulta) {
            String mensaje = "";
            try {
                comando = new SqlCommand(consulta, conexion);
            }
            catch (Exception ex) {
                mensaje = "Error!!";
            }
        }
    }
}
