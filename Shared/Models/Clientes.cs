using System.ComponentModel.DataAnnotations;


namespace Shared.Models
{
    public class Clientes
    {
        [Key]
        public int ClientesId { get; set; }

        [Required(ErrorMessage = "Ingrese su nombre")]
        public string? Nombres { get; set; }

		[RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Ingrese un número de celular válido")]
		public long Celular { get; set; }

		[RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Ingrese un número de teléfono válido")]
		public long Telefono { get; set; }

		[RegularExpression(@"^\d{9}$|^\d{11}$", ErrorMessage = "Ingrese un RNC válido de 9 o 11 dígitos")]
		[Required(ErrorMessage = "Por favor, ingrese el RNC correctamente")]
		public long RNC { get; set; }

        [Required(ErrorMessage = "Por favor, complete el campo")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Por favor, ingrese su dirección")]
        public string? Direccion { get; set; }
    } 
}