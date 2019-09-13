using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myFirstAzureWebApp.Models
{
    public class Horario
    {
        public int HorarioID { get; set; }
        
        public string Hora { get; set; }
        public int EmpleadoID { get; set; }
        public Empleado Empleado { get; set; }
       
    }
}
