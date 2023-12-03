using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain
{
    public class Nota
    {
        [Key]
        public int Id { get; set; }

        public String Title { get; set; }

        public Contenido Contenido { get; set; }

        public String? Notaciones { get; set; }

        [InverseProperty("Notas")]
        public List<Emocion>? Emociones { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

    }
}