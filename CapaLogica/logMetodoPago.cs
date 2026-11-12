using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaIdentidad;
using CapaDatos;

namespace CapaLogica
{
    public class logMetodoPago
    {
        #region singleton
        // Patrón Singleton
        private static readonly logMetodoPago _instancia = new logMetodoPago();
        public static logMetodoPago Instancia
        {
            get { return logMetodoPago._instancia; }
        }
        #endregion singleton

        #region metodos
        /// listado
        public List<entMetodoPago> ListarMetodoPago()
        {
            return datMetodoPago.Instancia.ListarMetodoPago();
        }
        /// inserta
        public Boolean InsertaMetodoPago(entMetodoPago o)
        {
            return datMetodoPago.Instancia.InsertarMetodoPago(o);
        }
        /// edita
        public Boolean EditaMetodoPago(entMetodoPago o)
        {
            return datMetodoPago.Instancia.EditarMetodoPago(o);
        }
        /// deshabilita
        public Boolean DeshabilitarMetodoPago(entMetodoPago o)
        {
            return datMetodoPago.Instancia.DeshabilitarMetodoPago(o);
        }
        #endregion metodos
    }
}