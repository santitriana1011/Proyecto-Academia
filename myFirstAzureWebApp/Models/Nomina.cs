using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myFirstAzureWebApp.Models
{
    public class Nomina
    {
        public int NominaID { get; set; }
        public int EmpleadoID { get; set; }
        public int ItemID { get; set; }
        public Empleado Empleado { get; set; }
        public Item Item { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int Valor { get; set; }
    }
}
