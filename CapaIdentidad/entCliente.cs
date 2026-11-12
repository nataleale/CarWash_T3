using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaIdentidad
{
    public class entCliente
    {
        public int idCliente { get; set; }
        public string razonSocial { get; set; }
        public string documento { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public string email { get; set; }
        public DateTime fecRegCliente { get; set; }
        public bool estCliente { get; set; }
    }
}
