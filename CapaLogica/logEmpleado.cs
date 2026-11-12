using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaIdentidad;
using CapaDatos;


namespace CapaLogica
{
    public class logEmpleado
    {
        
        private static readonly logEmpleado _instancia = new logEmpleado();
        public static logEmpleado Instancia
        {
            get { return logEmpleado._instancia; }

        }

        
        public List<entEmpleado> ListarEmpleado()
        {
            return datEmpleado.Instancia.ListarEmpleado();
        }
        
        public Boolean InsertaEmpleado(entEmpleado o)
        {
            return datEmpleado.Instancia.InsertarEmpleado(o);
        }
        
        public Boolean EditaEmpleado(entEmpleado o)
        {
            return datEmpleado.Instancia.EditarEmpleado(o);
        }
        
        public Boolean DeshabilitarEmpleado(entEmpleado o)
        {
            return datEmpleado.Instancia.DeshabilitarEmpleado(o);
        }
    }
}
