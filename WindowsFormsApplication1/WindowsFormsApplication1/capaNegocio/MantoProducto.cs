using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace capaNegocio
{
    public class MantoProducto
    {
        bdConex test = new bdConex();
        public String prueba(){
            String mensaje;
            if (test.Conectar() == true)
            {
                test.Desconectar();
                mensaje = "Conexion Realizada";
            }
            else {
                test.Desconectar();
                mensaje = "Conexion no Realizada"; 
            }
            return mensaje;
        }


    }
}
