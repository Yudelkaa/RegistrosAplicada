using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
	public class TicketDetalle
	{
		[Key]
		public int DetalleId { get; set; }

		[ForeignKey("Tickets")]
		public int TicketId { get; set; }

		[Required(ErrorMessage = "Campo obligatorio")]
		[RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Este campo no acepta números")]
		public string? Emisor { get; set; }

		[Required(ErrorMessage = "Campo Obligatorio")]
		public string? Mensaje { get; set; }
	}
}
