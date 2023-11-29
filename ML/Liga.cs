using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Liga
    {
        public int IdLiga { get; set; }
        public string NombreLiga { get; set; }
        public string Pais { get; set; }
        public Confederacion Confederacion { get; set; }

        public List<object> Ligas { get; set; }
    }
}
