using CapaDatos;
using CapaIdentidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class logProveedor
    {
        #region singleton
        // Patrón Singleton
        private static readonly logProveedor _instancia = new logProveedor();
        public static logProveedor Instancia
        {
            get { return logProveedor._instancia; }
        }
        #endregion singleton

        #region metodos
        /// listado
        public List<entProveedor> ListarProveedor()
        {
            return datProveedor.Instancia.ListarProveedor();
        }
        /// inserta
        public Boolean InsertaProveedor(entProveedor o)
        {
            return datProveedor.Instancia.InsertarProveedor(o);
        }
        /// edita
        public Boolean EditaProveedor(entProveedor o)
        {
            return datProveedor.Instancia.EditarProveedor(o);
        }
        /// deshabilita
        public Boolean DeshabilitarProveedor(entProveedor o)
        {
            return datProveedor.Instancia.DeshabilitarProveedor(o);
        }
        #endregion metodos
    }
}
