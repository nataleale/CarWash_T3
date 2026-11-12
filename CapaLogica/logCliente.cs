using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaIdentidad;

namespace CapaLogica
{
    public class logCliente
    {
        #region sigleton
        //Patron Singleton
        // Variable estática para la instancia
        private static readonly logCliente _instancia = new logCliente();
        //privado para evitar la instanciación directa
        public static logCliente Instancia
        {
            get
            {
                return logCliente._instancia;
            }
        }
        #endregion singleton

        #region metodos
        /// listado
        public List<entCliente> ListarCliente()
        {
            return datCliente.Instancia.ListarCliente();
        }
        /// inserta
        public Boolean InsertaCliente(entCliente o)
        {
            return datCliente.Instancia.InsertarCliente(o);
        }
        /// edita
        public Boolean EditaCliente(entCliente o)
        {
            return datCliente.Instancia.EditarCliente(o);
        }
        /// deshabilita
        public Boolean DeshabilitarCliente(entCliente o)
        {
            return datCliente.Instancia.DeshabilitarCliente(o);
        }
        #endregion metodos
    }
}
