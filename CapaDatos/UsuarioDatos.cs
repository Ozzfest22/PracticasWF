using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public class UsuarioDatos
    {
        SqlConnection cn = ConexionBD.Conectar("ProyEquipos");

        public DataTable IngresoUsuario(Usuarios usu)
        {
            DataSet dts = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_INGRESO", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmailUsuario", usu.EmailUsuario);
                cmd.Parameters.AddWithValue("@Contraseña", usu.Contraseña);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dts,"Usuarios");
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }

            return dts.Tables["Usuarios"];
        }
    }
}
