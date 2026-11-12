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
    public class datEmpleado
    {
        private static readonly datEmpleado _instancia = new datEmpleado();
        public static datEmpleado Instancia
        {
            get { return datEmpleado._instancia; }
        }

        

        
        public List<entEmpleado> ListarEmpleado()
        {
            List<entEmpleado> lista = new List<entEmpleado>();
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            using (SqlCommand cmd = new SqlCommand("spListarEmpleado", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entEmpleado o = new entEmpleado();
                        o.idEmpleado = Convert.ToInt32(dr["idEmpleado"]);
                        o.nombres = dr["nombres"].ToString();
                        o.apellidos = dr["apellidos"].ToString();
                        o.dni = dr["dni"].ToString();
                        o.telefono = dr["telefono"].ToString();
                        o.cargo = dr["cargo"].ToString();
                        o.fecContratacion = Convert.ToDateTime(dr["fecContratacion"]);
                        o.estEmpleado = Convert.ToBoolean(dr["estEmpleado"]);
                        lista.Add(o);
                    }
                }
            }
            return lista;
        }

       
        public Boolean InsertarEmpleado(entEmpleado o)
        {
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            using (SqlCommand cmd = new SqlCommand("spInsertarEmpleado", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombres", (object)o.nombres ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@apellidos", (object)o.apellidos ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@dni", (object)o.dni ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@telefono", (object)o.telefono ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@cargo", (object)o.cargo ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@fecContratacion", o.fecContratacion);
                cmd.Parameters.AddWithValue("@estEmpleado", o.estEmpleado);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        
        public Boolean EditarEmpleado(entEmpleado o)
        {
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            using (SqlCommand cmd = new SqlCommand("spEditarEmpleado", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idEmpleado", o.idEmpleado);
                cmd.Parameters.AddWithValue("@nombres", (object)o.nombres ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@apellidos", (object)o.apellidos ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@dni", (object)o.dni ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@telefono", (object)o.telefono ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@cargo", (object)o.cargo ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@fecContratacion", o.fecContratacion);
                cmd.Parameters.AddWithValue("@estEmpleado", o.estEmpleado);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        
        public Boolean DeshabilitarEmpleado(entEmpleado o)
        {
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            using (SqlCommand cmd = new SqlCommand("spDeshabilitarEmpleado", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idEmpleado", o.idEmpleado);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }


    }
}
