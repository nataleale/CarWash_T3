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

        private static readonly logMaterial _instancia = new logMaterial();
        
        public static logMaterial Instancia
        {
            get
            {
                return logMaterial._instancia;
            }
        }
        #endregion singleton

        #region metodos
        
        public List<entMaterial> ListarMaterial()
        {
            return datMaterial.Instancia.ListarMaterial();
        }
        
        public Boolean InsertaMaterial(entMaterial o)
        {
            return datMaterial.Instancia.InsertarMaterial(o);
        }
        
        public Boolean EditaMaterial(entMaterial o)
        {
            return datMaterial.Instancia.EditarMaterial(o);
        }
        
        public Boolean DeshabilitarMaterial(entMaterial o)
        {
            return datMaterial.Instancia.DeshabilitarMaterial(o);
        }
        #endregion metodos
    }
}