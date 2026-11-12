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
        
        private static readonly logMetodoPago _instancia = new logMetodoPago();
        public static logMetodoPago Instancia
        {
            get { return logMetodoPago._instancia; }
        }
        #endregion singleton

        #region metodos
        
        public List<entMetodoPago> ListarMetodoPago()
        {
            return datMetodoPago.Instancia.ListarMetodoPago();
        }
        
        public Boolean InsertaMetodoPago(entMetodoPago o)
        {
            return datMetodoPago.Instancia.InsertarMetodoPago(o);
        }
        
        public Boolean EditaMetodoPago(entMetodoPago o)
        {
            return datMetodoPago.Instancia.EditarMetodoPago(o);
        }
        
        public Boolean DeshabilitarMetodoPago(entMetodoPago o)
        {
            return datMetodoPago.Instancia.DeshabilitarMetodoPago(o);
        }
        #endregion metodos
    }
}