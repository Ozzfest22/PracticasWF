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
    public class JugadoresDatos
    {
        SqlConnection cn = ConexionBD.Conectar("ProyEquipos");
        Jugador jug = new Jugador();

        public DataTable ListarJugadores_BC()
        {
            DataSet dts = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_LISTAR_JUGADORES", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@equipo", "Barcelona");

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dts,"Jugador");
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }

            return dts.Tables["Jugador"];
        }

        public DataTable ListarJugadores_RM()
        {
            DataSet dts = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_LISTAR_JUGADORES", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@equipo", "Real Madrid");

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dts, "Jugador");
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }

            return dts.Tables["Jugador"];
        }

        public DataTable BusquedaJugador_BC(string valor)
        {
            DataSet dts = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_BUSQUEDA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@valor", valor);
                cmd.Parameters.AddWithValue("@equipo", "Barcelona");

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dts, "Jugador");
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }

            return dts.Tables["Jugador"];
        }

        public DataTable BusquedaJugador_RM(string valor)
        {
            DataSet dts = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_BUSQUEDA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@valor", valor);
                cmd.Parameters.AddWithValue("@equipo", "Real Madrid");

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dts, "Jugador");
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }

            return dts.Tables["Jugador"];
        }

        public DataTable LlenarCombo(string op)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_LISTAR_COMBOS", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@op", op);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }

            return dt;
        }

        public bool InsertarJugador(Jugador jug)
        {
            bool insert;
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_INSERTAR_JUGADOR", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DniJugador", jug.DniJugador);
                cmd.Parameters.AddWithValue("@NomJugador", jug.NomJugador);
                cmd.Parameters.AddWithValue("@ApePatJugador", jug.ApePatJugador);
                cmd.Parameters.AddWithValue("@ApeMatJugador", jug.ApeMatJugador);
                cmd.Parameters.AddWithValue("@EdadJugador", jug.EdadJugador);
                cmd.Parameters.AddWithValue("@IdEquipo", jug.IdEquipo);

                cmd.ExecuteNonQuery();

                insert = true;
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }

            return insert;
        }

        public bool ActualizarJugador(Jugador jug)
        {
            bool update;
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_ACTUALIZAR_JUGADOR", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdJugador", jug.IdJugador);
                cmd.Parameters.AddWithValue("@DniJugador", jug.DniJugador);
                cmd.Parameters.AddWithValue("@NomJugador", jug.NomJugador);
                cmd.Parameters.AddWithValue("@ApePatJugador", jug.ApePatJugador);
                cmd.Parameters.AddWithValue("@ApeMatJugador", jug.ApeMatJugador);
                cmd.Parameters.AddWithValue("@EdadJugador", jug.EdadJugador);
                cmd.Parameters.AddWithValue("@IdEquipo", jug.IdEquipo);

                cmd.ExecuteNonQuery();

                update = true;
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }

            return update;
        }

        public Jugador ConsultarJugador(int codigo)
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_CONSULTAR_JUGADOR", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdJugador", codigo);

                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.HasRows == true)
                {
                    sdr.Read();

                    jug.DniJugador = sdr["DniJugador"].ToString();
                    jug.NomJugador = sdr["NomJugador"].ToString();
                    jug.ApePatJugador = sdr["ApePatJugador"].ToString();
                    jug.ApeMatJugador = sdr["ApeMatJugador"].ToString();
                    jug.EdadJugador = int.Parse(sdr["EdadJugador"].ToString());
                    jug.IdEquipo = int.Parse(sdr["IdEquipo"].ToString());

                }
                cn.Close();
                return jug;
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
        }

    }
}
