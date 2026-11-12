using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaIdentidad
{
    public class entMaterial
    {
        public int idMaterial { get; set; }
        public string descripcion { get; set; }
        public decimal stock { get; set; }
        public decimal precio { get; set; }
        public DateTime fecRegMaterial { get; set; }
        public bool estMaterial { get; set; }
    }
}