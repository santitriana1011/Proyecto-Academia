using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace myFirstAzureWebApp.Models
{
    public class Empleado
    {
        public int EmpleadoID { get; set; }
        public int CargoID { get; set; }
        public Cargo Cargo { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre debe tener de 3 a 50 caracteres")]
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Documento { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Contrasenia { get; set; }
        [StringLength(256)]
        public string Rol { get; set; }
        public Boolean Estado { get; set; } = true;
    }
}
