using System;
using System.Collections.Generic;
using CapaEntidad;
using CapaDatos;

namespace CapaLogica
{
    public class logVehiculo
    {
        #region singleton
        // Patrón Singleton
        private static readonly logVehiculo _instancia = new logVehiculo();
        public static logVehiculo Instancia
        {
            get { return logVehiculo._instancia; }
        }
        #endregion singleton

        #region metodos
        /// listado
        public List<entVehiculo> ListarVehiculo()
        {
            return datVehiculo.Instancia.ListarVehiculo();
        }
        /// inserta
        public Boolean InsertaVehiculo(entVehiculo o)
        {
            return datVehiculo.Instancia.InsertarVehiculo(o);
        }
        /// edita
        public Boolean EditaVehiculo(entVehiculo o)
        {
            return datVehiculo.Instancia.EditarVehiculo(o);
        }
        /// deshabilita
        public Boolean DeshabilitarVehiculo(entVehiculo o)
        {
            return datVehiculo.Instancia.DeshabilitarVehiculo(o);
        }
        #endregion metodos
    }
}

