using Microsoft.AspNetCore.Http;
using myFirstAzureWebApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace myFirstAzureWebApp.ViewModels
{
    public class EmployeeCreateViewModel
    {
        //public int AcudienteID { get; set; }
        //public Acudiente Acudiente { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre debe tener de 3 a 50 caracteres")]
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Documento { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public IFormFile Photo { get; set; }
    }
}
