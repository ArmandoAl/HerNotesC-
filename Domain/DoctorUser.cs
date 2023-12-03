using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain
{
    [Table("Doctors")]
    public class DoctorUser: Usuario
    {
     //[InverseProperty("pacientes")]
     public List<PacienteUser>? pacientes { get; set; } = new List<PacienteUser>();
    }
}