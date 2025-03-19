using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PraticaExamen.Models
{
    [Table("VISTACOMPRAS")]
    public class VistaCompra
    {
        [Key]
        [Column("IDVISTACOMPRA")]
        public int IdVistaCompra { get; set; }

        [Column("IdUsuario")]
        public int IdUsuario { get; set; }

        [Column("NombreUsuario")]
        public string NombreUsuario { get; set; }

        [Column("IdCubo")]
        public int IdCubo { get; set; }

        [Column("NombreCubo")]
        public string NombreCubo { get; set; }

        [Column("PrecioCubo")]
        public int PrecioCubo { get; set; }

        [Column("ImagenCubo")]
        public string ImagenCubo { get; set; }

        [Column("Cantidad")]
        public int Cantidad { get; set; }

        [Column("FechaCompra")]
        public DateTime FechaCompra { get; set; }

        [Column("PrecioFinal")]
        public int PrecioFinal { get; set; }
    }
}
