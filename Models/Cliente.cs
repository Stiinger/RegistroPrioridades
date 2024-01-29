using System.ComponentModel.DataAnnotations;

namespace RegistroPrioridades.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }
        [Required(ErrorMessage = "El campo Nombre no puede estar vacío.")]
        [RegularExpression(@"^[^\d]+$", ErrorMessage = "El nombre no puede contener números.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "El nombre ingresado es demasiado corto.")]
        public string Nombres { get; set; } = string.Empty;
        [Required(ErrorMessage = "El campo Teléfono no puede estar vacío.")]
		[Phone(ErrorMessage = "Error, el número de teléfono no es válido.")]
		public string Telefono { get; set; } = string.Empty;
        [Required(ErrorMessage = "El campo Celular no puede estar vacío.")]
		[Phone(ErrorMessage = "Error, el número de celular no es válido.")]
		public string Celular { get; set; } = string.Empty;
        [Required(ErrorMessage = "El campo RNC no puede estar vacío.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "El RNC debe contener solo numeros.")]
        [StringLength(maximumLength:9, ErrorMessage = "El RNC debe contener exactamente {1} dígitos.")]
        public string RNC { get; set; } = string.Empty;
        [Required(ErrorMessage = "El campo Email no puede estar vacío.")]
		[EmailAddress(ErrorMessage = "Email no válido. Ejemplo: usuario@dominio.com")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "El campo Dirección no puede estar vacío.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Debe introducir una direccion real.")]
        public string Direccion { get; set; } = string.Empty;
    }
}