using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    public class Prioridades
    {
        [Key]
        public int PrioridadesId { get; set; }
        [Required(ErrorMessage = "Es requerido")]
        public string? Descripcion { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "El día debe ser mayor a cero")]
        public int DiasCompromiso { get; set; }
		
	}
}
