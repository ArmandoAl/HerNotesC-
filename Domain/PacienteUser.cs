using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("Pacientes")]
    public class PacienteUser : Usuario
    {
        //[InverseProperty("doctor")]
        public int? doctorid { get; set; }
        public List<Nota> Notas { get; set; } = new List<Nota>();
    }
}
