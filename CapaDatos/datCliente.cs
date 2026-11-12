using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaIdentidad;

namespace CapaDatos
{
    public class datCliente
    {

        #region sigleton
        
        private static readonly datCliente _instancia = new datCliente();
        
        public static datCliente Instancia
        {
            get
            {
                return datCliente._instancia;
            }
        }
        #endregion singleton

        #region metodos
        
        public List<entCliente> ListarCliente()
        {
            List<entCliente> lista = new List<entCliente>();
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            using (SqlCommand cmd = new SqlCommand("spListarCliente", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entCliente o = new entCliente();
                        o.idCliente = Convert.ToInt32(dr["idCliente"]);
                        o.razonSocial = dr["razonSocial"].ToString();
                        o.documento = dr["documento"].ToString();
                        o.telefono = dr["telefono"].ToString();
                        o.direccion = dr["direccion"].ToString();
                        o.email = dr["email"].ToString();
                        o.fecRegCliente = Convert.ToDateTime(dr["fecRegCliente"]);
                        o.estCliente = Convert.ToBoolean(dr["estCliente"]);
                        lista.Add(o);
                    }
                }
            }
            return lista;
        }

       
        public Boolean InsertarCliente(entCliente o)
        {
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            using (SqlCommand cmd = new SqlCommand("spInsertarCliente", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@razonSocial", (object)o.razonSocial ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@documento", (object)o.documento ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@telefono", (object)o.telefono ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@direccion", (object)o.direccion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@email", (object)o.email ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@fecRegCliente", o.fecRegCliente);
                cmd.Parameters.AddWithValue("@estCliente", o.estCliente);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        
        public Boolean EditarCliente(entCliente o)
        {
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            using (SqlCommand cmd = new SqlCommand("spEditarCliente", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCliente", o.idCliente);
                cmd.Parameters.AddWithValue("@razonSocial", (object)o.razonSocial ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@documento", (object)o.documento ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@telefono", (object)o.telefono ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@direccion", (object)o.direccion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@email", (object)o.email ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@fecRegCliente", o.fecRegCliente);
                cmd.Parameters.AddWithValue("@estCliente", o.estCliente);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        
        public Boolean DeshabilitarCliente(entCliente o)
        {
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            using (SqlCommand cmd = new SqlCommand("spDeshabilitarCliente", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCliente", o.idCliente);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        #endregion metodos
    }
}
