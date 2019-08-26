using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myFirstAzureWebApp.Models
{
    public class HojaDeVida
    {
        public int HojaDeVidaID { get; set; }
        public int EmpleadoID { get; set; }
        public Empleado Empleado { get; set; }
        public string Especialidad { get; set; }
        public string TiempoExperiencia { get; set; }
    }
}
