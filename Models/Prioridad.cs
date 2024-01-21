using System.ComponentModel.DataAnnotations;

namespace RegistroPrioridades.Models
{
    public class Prioridad
    {
        [Key]
        public int PrioridadId { get; set; }
        [Required(ErrorMessage = "El campo Descripción no puede estar vacío")]
        public string? Descripcion { get; set; }
        [Required(ErrorMessage = "El campo Días Compromiso no puede estar vacío")]
        [Range(1, 365, ErrorMessage = "Debe ingresar valores entre 1 y 365")]
        public int? DiasCompromiso { get; set; }
    }
}