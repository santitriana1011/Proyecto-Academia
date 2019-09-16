using Microsoft.AspNetCore.Http;
using myFirstAzureWebApp.Models;
using myFirstAzureWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace myFirstAzureWebApp.Services
{
    public interface IFormFile
    {
        IEnumerable<Estudiante> GetAllEmployees();
        Estudiante Add(Estudiante employee);
        Estudiante GetEmployee(int id);


        void Update(Estudiante employeeChanges);
        void Delete(int Id);
        EmployeeCreateViewModel TotEmpDept(string dep);
        string ContentType { get; }
        string ContentDisposition { get; }
        IHeaderDictionary Headers { get; }
        long Length { get; }
        string Nombre { get; }
        string FileName { get; }
        Stream OpenReadStream();
        void CopyTo(Stream target);
        Task CopyToAsync(Stream target);
    }
}
