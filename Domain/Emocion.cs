using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace Domain
{
    public class Emocion
    {
        [Key]
        public int Id { get; set; }

        public String Tipo { get; set; }

        public double Valor { get; set; }
        
        public String EmocionBase { get; set; }

        [InverseProperty("Emociones")]
        [JsonIgnore]
        public List<Nota>? Notas { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

    }
}
