using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaIdentidad;

namespace CapaDatos
{
    public class datMetodoPago
    {
        #region singleton
        // Patrón Singleton
        private static readonly datMetodoPago _instancia = new datMetodoPago();
        public static datMetodoPago Instancia
        {
            get { return datMetodoPago._instancia; }
        }
        #endregion singleton

        #region metodos

        ////////////////////// Listado
        public List<entMetodoPago> ListarMetodoPago()
        {
            List<entMetodoPago> lista = new List<entMetodoPago>();
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            using (SqlCommand cmd = new SqlCommand("spListarMetodoPago", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entMetodoPago o = new entMetodoPago();
                        o.idMetodoPago = Convert.ToInt32(dr["idMetodoPago"]);
                        o.nombre = dr["nombre"].ToString();
                        o.descripcion = dr["descripcion"].ToString();
                        o.estMetodoPago = Convert.ToBoolean(dr["estMetodoPago"]);
                        lista.Add(o);
                    }
                }
            }
            return lista;
        }

        ////////////////////// Insertar
        public Boolean InsertarMetodoPago(entMetodoPago o)
        {
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            using (SqlCommand cmd = new SqlCommand("spInsertarMetodoPago", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", (object)o.nombre ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@descripcion", (object)o.descripcion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@estMetodoPago", o.estMetodoPago);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        ////////////////////// Editar
        public Boolean EditarMetodoPago(entMetodoPago o)
        {
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            using (SqlCommand cmd = new SqlCommand("spEditarMetodoPago", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idMetodoPago", o.idMetodoPago);
                cmd.Parameters.AddWithValue("@nombre", (object)o.nombre ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@descripcion", (object)o.descripcion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@estMetodoPago", o.estMetodoPago);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        ////////////////////// Deshabilitar (eliminado lógico)
        public Boolean DeshabilitarMetodoPago(entMetodoPago o)
        {
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            using (SqlCommand cmd = new SqlCommand("spDeshabilitarMetodoPago", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idMetodoPago", o.idMetodoPago);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        #endregion metodos
    }
}