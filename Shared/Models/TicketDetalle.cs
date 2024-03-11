using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
	public class TicketDetalle
	{
		[Key]
		public int Id { get; set; }

		public int TicketId { get; set; }

		[Required(ErrorMessage = "Es requerido")]
		public string? Emisor { get; set; }

		[Required(ErrorMessage = "Es requerido")]
		public string? Mensaje { get; set; }
	}
}
