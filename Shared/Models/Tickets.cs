using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models
{
	public class Tickets
	{
		[Key]
		public int TicketId { get; set; }

		[DataType(DataType.Date)]
		[Range(typeof(DateTime), "1900-01-01", "2100-12-31")]
		[Required(ErrorMessage = "Es requerido")]
		public DateTime? Fecha { get; set; }

		[Required(ErrorMessage = "Es requerido")]
		[ForeignKey("Clientes")]
		public int ClienteId { get; set; }


		[Range(1, int.MaxValue, ErrorMessage = "Debe ser válido")]
		[ForeignKey("Sistemas")]
		public int SistemaId { get; set; }


		[Required(ErrorMessage = "Es requerido")]
		[ForeignKey("Prioridades")]
		public string? PrioridadId { get; set; }


		[Required(ErrorMessage = "Es requerido")]
		public string? SolicitadoPor { get; set; }


		[Required(ErrorMessage = "Es requerido")]
		public string? Asunto { get; set; }

		[Required(ErrorMessage = "Es requerido")]
		public string? Descripcion { get; set; }

		[ForeignKey("TicketId")]
		public ICollection<TicketDetalle> TicketsDetalle { get; set; } = new List<TicketDetalle>();

	}
}
