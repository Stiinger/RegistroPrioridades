using System.ComponentModel.DataAnnotations;

namespace RegistroPrioridades.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }
        [Required(ErrorMessage = "El campo Nombres no puede estar vacío.")]
        [RegularExpression(@"^[^\d]+$", ErrorMessage = "El nombre no puede contener números.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "El nombre ingresado es demasiado corto. Debe tener al menos {2} dígitos")]
        public string Nombres { get; set; } = string.Empty;
        [Required(ErrorMessage = "El campo Teléfono no puede estar vacío.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "El número de teléfono debe contener solo numeros.")]
        [StringLength(12, MinimumLength = 10, ErrorMessage = "El número de teléfono debe contener al menos {2} dígitos y maximo {1} dígitos.")]
        public string? Telefono { get; set; } = string.Empty;
        [Required(ErrorMessage = "El campo Celular no puede estar vacío.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "El número de celular debe contener solo numeros.")]
        [StringLength(12, MinimumLength = 10, ErrorMessage = "El número de celular debe contener al menos {2} dígitos y maximo {1} dígitos.")]
        public string Celular { get; set; } = string.Empty;
        [Required(ErrorMessage = "El campo RNC no puede estar vacío.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "El RNC debe contener solo numeros.")]
        public string RNC { get; set; } = string.Empty;
        [Required(ErrorMessage = "El campo Email no puede estar vacío.")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Email no válido. EJ: usuario@dominio.com")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "El campo Dirección no puede estar vacío.")]
        [StringLength(500, MinimumLength = 5, ErrorMessage = "Debe introducir una direccion real.")]
        public string Direccion { get; set; } = string.Empty;
    }
}