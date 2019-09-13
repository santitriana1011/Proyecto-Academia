using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace myFirstAzureWebApp.Models
{
    public class Actualidad
    {
        public int ActualidadID { get; set; }
        [Required]
        public String Nombre { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",ApplyFormatInEditMode = false)]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        [Required]
        public String Descripcion { get; set; }
        
    }
}
