using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ConexionBD
    {
        public static SqlConnection Conectar(string connStr)
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["ProyEquipos"].ConnectionString;
                SqlConnection cn = new SqlConnection(conn);

                return cn;
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
        }
    }
}
