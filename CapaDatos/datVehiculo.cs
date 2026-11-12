using CapaEntidad;
using CapaIdentidad;
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
    public class datVehiculo
    {
        #region singleton
        // Patrón Singleton
        private static readonly datVehiculo _instancia = new datVehiculo();
        public static datVehiculo Instancia
        {
            get { return datVehiculo._instancia; }
        }
        #endregion singleton

        #region metodos

        ////////////////////// Listado
        public List<entVehiculo> ListarVehiculo()
        {
            List<entVehiculo> lista = new List<entVehiculo>();
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            using (SqlCommand cmd = new SqlCommand("spListarVehiculo", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entVehiculo o = new entVehiculo();
                        o.idVehiculo = Convert.ToInt32(dr["idVehiculo"]);
                        o.placa = dr["placa"].ToString();
                        o.marca = dr["marca"].ToString();
                        o.modelo = dr["modelo"].ToString();
                        o.color = dr["color"].ToString();
                        o.anio = Convert.ToInt32(dr["anio"]);
                        o.tipoVehiculo = dr["tipoVehiculo"].ToString();
                        o.idCliente = Convert.ToInt32(dr["idCliente"]);
                        o.estVehiculo = Convert.ToBoolean(dr["estVehiculo"]);
                        o.clienteNombre = dr["clienteNombre"].ToString();
                        lista.Add(o);
                    }
                }
            }
            return lista;
        }

        ////////////////////// Insertar
        public Boolean InsertarVehiculo(entVehiculo o)
        {
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            using (SqlCommand cmd = new SqlCommand("spInsertarVehiculo", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@placa", (object)o.placa ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@marca", (object)o.marca ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@modelo", (object)o.modelo ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@color", (object)o.color ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@anio", o.anio);
                cmd.Parameters.AddWithValue("@tipoVehiculo", (object)o.tipoVehiculo ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@idCliente", o.idCliente);
                cmd.Parameters.AddWithValue("@estVehiculo", o.estVehiculo);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        ////////////////////// Editar
        public Boolean EditarVehiculo(entVehiculo o)
        {
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            using (SqlCommand cmd = new SqlCommand("spEditarVehiculo", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idVehiculo", o.idVehiculo);
                cmd.Parameters.AddWithValue("@placa", (object)o.placa ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@marca", (object)o.marca ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@modelo", (object)o.modelo ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@color", (object)o.color ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@anio", o.anio);
                cmd.Parameters.AddWithValue("@tipoVehiculo", (object)o.tipoVehiculo ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@idCliente", o.idCliente);
                cmd.Parameters.AddWithValue("@estVehiculo", o.estVehiculo);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        ////////////////////// Deshabilitar (eliminado lógico)
        public Boolean DeshabilitarVehiculo(entVehiculo o)
        {
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            using (SqlCommand cmd = new SqlCommand("spDeshabilitarVehiculo", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idVehiculo", o.idVehiculo);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        #endregion metodos
    }
}
