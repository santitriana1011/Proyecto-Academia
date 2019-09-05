using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using myFirstAzureWebApp.Models;

namespace myFirstAzureWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<myFirstAzureWebApp.Models.Escuela> Escuela { get; set; }
        public DbSet<myFirstAzureWebApp.Models.Cargo> Cargo { get; set; }
        public DbSet<myFirstAzureWebApp.Models.Acudiente> Acudiente { get; set; }
        public DbSet<myFirstAzureWebApp.Models.Item> Item { get; set; }
        public DbSet<myFirstAzureWebApp.Models.Empleado> Empleado { get; set; }
        public DbSet<myFirstAzureWebApp.Models.Estudiante> Estudiante { get; set; }
        public DbSet<myFirstAzureWebApp.Models.Mensualidad> Mensualidad { get; set; }
        public DbSet<myFirstAzureWebApp.Models.Nomina> Nomina { get; set; }
        public DbSet<myFirstAzureWebApp.Models.NovedadMedica> NovedadMedica { get; set; }
        public DbSet<myFirstAzureWebApp.Models.HojaDeVida> HojaDeVida { get; set; }
        public DbSet<myFirstAzureWebApp.Models.Traspaso> Traspaso { get; set; }
        public DbSet<myFirstAzureWebApp.Models.Horario> Horario { get; set; }
        public DbSet<myFirstAzureWebApp.Models.Encuentros> Encuentros { get; set; }

    }
}
