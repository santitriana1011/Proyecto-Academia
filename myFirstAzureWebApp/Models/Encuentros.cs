using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myFirstAzureWebApp.Models
{
    public class Encuentros 
    {
        public int EncuentrosID { get; set; }
        public int EscuelaID { get; set; }
        public Escuela Escuela { get; set; }
        public string Categoria { get; set; }
        public string NombreEvento { get; set; }
        public string Descripcion { get; set; }
    }
}
