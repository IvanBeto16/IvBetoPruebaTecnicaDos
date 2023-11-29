using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Equipo
    {
        public int IdEquipo { get; set; }
        public string NombreEquipo { get; set; }
        public int AnioFundacion { get; set; }
        public string CiudadSede { get; set; }
        public string Estadio { get; set; }
        public int TitulosNacionales { get; set; }
        public int TitulosInternacionales { get; set; }
        public Liga Liga { get; set; }

        public List<object> Equipos { get; set; }
    }
}
