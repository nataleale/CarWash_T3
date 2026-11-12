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
    public class datMaterial
    {

        #region sigleton

        private static readonly datMaterial _instancia = new datMaterial();

        public static datMaterial Instancia
        {
            get
            {
                return datMaterial._instancia;
            }
        }
        #endregion singleton

        #region metodos
        
        public List<entMaterial> ListarMaterial()
        {
            List<entMaterial> lista = new List<entMaterial>();
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            using (SqlCommand cmd = new SqlCommand("spListarMaterial", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entMaterial o = new entMaterial();
                        o.idMaterial = Convert.ToInt32(dr["idMaterial"]);
                        o.descripcion = dr["descripcion"].ToString();
                        o.stock = Convert.ToDecimal(dr["stock"]);
                        o.precio = Convert.ToDecimal(dr["precio"]);
                        o.fecRegMaterial = Convert.ToDateTime(dr["fecRegMaterial"]);
                        o.estMaterial = Convert.ToBoolean(dr["estMaterial"]);
                        lista.Add(o);
                    }
                }
            }
            return lista;
        }

        
        public Boolean InsertarMaterial(entMaterial o)
        {
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            using (SqlCommand cmd = new SqlCommand("spInsertarMaterial", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@descripcion", (object)o.descripcion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@stock", o.stock);
                cmd.Parameters.AddWithValue("@precio", o.precio);
                cmd.Parameters.AddWithValue("@fecRegMaterial", o.fecRegMaterial);
                cmd.Parameters.AddWithValue("@estMaterial", o.estMaterial);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        
        public Boolean EditarMaterial(entMaterial o)
        {
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            using (SqlCommand cmd = new SqlCommand("spEditarMaterial", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idMaterial", o.idMaterial);
                cmd.Parameters.AddWithValue("@descripcion", (object)o.descripcion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@stock", o.stock);
                cmd.Parameters.AddWithValue("@precio", o.precio);
                cmd.Parameters.AddWithValue("@fecRegMaterial", o.fecRegMaterial);
                cmd.Parameters.AddWithValue("@estMaterial", o.estMaterial);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

       
        public Boolean DeshabilitarMaterial(entMaterial o)
        {
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            using (SqlCommand cmd = new SqlCommand("spDeshabilitarMaterial", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idMaterial", o.idMaterial);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        #endregion metodos
    }
}