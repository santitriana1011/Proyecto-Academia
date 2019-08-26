using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace myFirstAzureWebApp.Models
{
    public class NovedadMedica
    {
        public int NovedadMedicaID { get; set; }
        public int EstudianteID { get; set; }
        public int EmpleadoID { get; set; }
        public Estudiante Estudiante { get; set; }
        public Empleado Empleado { get; set; }
        public DateTime FechaLesion { get; set; }
        [StringLength(256)]
        public string  Descripcion { get; set; }
    }
}
