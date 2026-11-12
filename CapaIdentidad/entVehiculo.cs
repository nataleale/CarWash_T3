using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entVehiculo
    {
        public int idVehiculo { get; set; }
        public string placa { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public string color { get; set; }
        public int anio { get; set; }
        public string tipoVehiculo { get; set; }
        public int idCliente { get; set; }
        public bool estVehiculo { get; set; }
        public string clienteNombre { get; set; }   
    }
}
