using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PraticaExamen.Models
{
    [Table("COMPRA")]
    public class Compra
    {
        [Key]
        [Column("id_compra")]
        public int IdCompra { get; set; }

        [Column("id_usuario")]
        public int IdUsuario { get; set; }

        [Column("id_cubo")]
        public int IdCubo { get; set; }

        [Column("cantidad")]
        public int Cantidad { get; set; } 

        [Column("fecha")]
        public DateTime FechaPedido { get; set; }

        [Column("precio_final")]
        public int PrecioFinal { get; set; }
    }
}
