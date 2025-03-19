using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PraticaExamen.Models
{
    [Table("CUBOS")]
    public class Cubo
    {
        [Key]
        [Column("id_cubo")]
        public int IdCubo { get; set; }
        [Column("nombre")]
        public string Nombre { get; set; }
        [Column("modelo")]
        public string Modelo { get; set; }
        [Column("precio")]
        public int Precio { get; set; }
        [Column("imagen")]
        public string Imagen { get; set; }
        [Column("id_marca")]
        public int IdMarca { get; set; }

    }
}
