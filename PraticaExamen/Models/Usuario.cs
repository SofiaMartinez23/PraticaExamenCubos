using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PraticaExamen.Models
{
    [Table("USUARIOS")]
    public class Usuario
    {
        [Key]
        [Column("id_user")]
        public int IdUsuario { get; set; }
        [Column("nombre")]
        public string Nombre { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("password")]
        public string Password { get; set; }
       
    }
}
