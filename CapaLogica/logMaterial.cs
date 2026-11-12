using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaIdentidad;

namespace CapaLogica
{
    public class logMaterial
    {
        #region sigleton
        //Patron Singleton
        // Variable estática para la instancia
        private static readonly logMaterial _instancia = new logMaterial();
        //privado para evitar la instanciación directa
        public static logMaterial Instancia
        {
            get
            {
                return logMaterial._instancia;
            }
        }
        #endregion singleton

        #region metodos
        /// listado
        public List<entMaterial> ListarMaterial()
        {
            return datMaterial.Instancia.ListarMaterial();
        }
        /// inserta
        public Boolean InsertaMaterial(entMaterial o)
        {
            return datMaterial.Instancia.InsertarMaterial(o);
        }
        /// edita
        public Boolean EditaMaterial(entMaterial o)
        {
            return datMaterial.Instancia.EditarMaterial(o);
        }
        /// deshabilita
        public Boolean DeshabilitarMaterial(entMaterial o)
        {
            return datMaterial.Instancia.DeshabilitarMaterial(o);
        }
        #endregion metodos
    }
}