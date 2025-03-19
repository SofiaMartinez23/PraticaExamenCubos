using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PraticaExamen.Models
{

    [Table("MARCA")] 
    public class Marca
    {
        [Key] 
        [Column("id_marca")] 
        public int IdMarca { get; set; }  

        [Column("nombre")] 
        public string Nombre { get; set; } 
    }
}

