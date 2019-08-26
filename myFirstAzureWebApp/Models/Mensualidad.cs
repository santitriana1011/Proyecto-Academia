using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myFirstAzureWebApp.Models
{
    public class Mensualidad
    {
        public int MensualidadID { get; set; }
        public int AcudienteID { get; set; }
        public Acudiente Acudiente { get; set; }
        public DateTime FechaPago { get; set; }
        public int Valor { get; set; }
        public string Mes { get; set; }
        public string Anio { get; set; }
    }
}
