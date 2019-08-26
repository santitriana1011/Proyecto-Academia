using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace myFirstAzureWebApp.Models
{
    public class Traspaso
    {
        public int TraspasoID { get; set; }
        public int EstudianteID { get; set; }
        public int EscuelaID { get; set; }
        public Estudiante Estudiante { get; set; }
        public Escuela Escuela { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        [StringLength(256)]
        public string Novedades { get; set; }
    }
}
