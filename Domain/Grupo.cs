using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Grupo
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }

        public String? Description { get; set; }

        public List<Nota>? Notas { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
