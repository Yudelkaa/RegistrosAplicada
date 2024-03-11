using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    public class Sistemas
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Es requerido")]
        public string? Nombre { get; set; }
    }
}
