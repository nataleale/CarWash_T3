using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaIdentidad;

namespace CapaDatos
{
    public class datProveedor
    {

        #region singleton
        // Patrón Singleton
        private static readonly datProveedor _instancia = new datProveedor();
        public static datProveedor Instancia
        {
            get { return datProveedor._instancia; }
        }
        #endregion singleton

        #region metodos

        ////////////////////// Listado
        public List<entProveedor> ListarProveedor()
        {
            List<entProveedor> lista = new List<entProveedor>();
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            using (SqlCommand cmd = new SqlCommand("spListarProveedor", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entProveedor o = new entProveedor();
                        o.idProveedor = Convert.ToInt32(dr["idProveedor"]);
                        o.razonSocial = dr["razonSocial"].ToString();
                        o.ruc = dr["ruc"].ToString();
                        o.telefono = dr["telefono"].ToString();
                        o.direccion = dr["direccion"].ToString();
                        o.email = dr["email"].ToString();
                        o.estProveedor = Convert.ToBoolean(dr["estProveedor"]);
                        lista.Add(o);
                    }
                }
            }
            return lista;
        }

        ////////////////////// Insertar
        public Boolean InsertarProveedor(entProveedor o)
        {
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            using (SqlCommand cmd = new SqlCommand("spInsertarProveedor", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@razonSocial", (object)o.razonSocial ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ruc", (object)o.ruc ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@telefono", (object)o.telefono ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@direccion", (object)o.direccion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@email", (object)o.email ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@estProveedor", o.estProveedor);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        ////////////////////// Editar
        public Boolean EditarProveedor(entProveedor o)
        {
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            using (SqlCommand cmd = new SqlCommand("spEditarProveedor", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idProveedor", o.idProveedor);
                cmd.Parameters.AddWithValue("@razonSocial", (object)o.razonSocial ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ruc", (object)o.ruc ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@telefono", (object)o.telefono ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@direccion", (object)o.direccion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@email", (object)o.email ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@estProveedor", o.estProveedor);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        ////////////////////// Deshabilitar (eliminado lógico)
        public Boolean DeshabilitarProveedor(entProveedor o)
        {
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            using (SqlCommand cmd = new SqlCommand("spDeshabilitarProveedor", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idProveedor", o.idProveedor);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        #endregion metodos
    }
}
