using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaIdentidad
{
    public class entProveedor
    {
        public int idProveedor { get; set; }
        public string razonSocial { get; set; }
        public string ruc { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public string email { get; set; }
        public bool estProveedor { get; set; }
    }
}
