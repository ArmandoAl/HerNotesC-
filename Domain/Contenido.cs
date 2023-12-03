using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Contenido
    {
        [Key]

        public int Id { get; set; }

        public String? Texto { get; set; }

        public String? ImagenUrl { get; set; }

        public String? NotaDeVozUrl { get; set; }
    }
}
