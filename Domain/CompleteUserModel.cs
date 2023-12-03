using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CompleteUserModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public List<PacienteUser>? pacientes { get; set; } = new List<PacienteUser>();

        public int? doctorid { get; set; }

        public List<Nota>? Notas { get; set; } = new List<Nota>();
    }
}
