using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroPrioridades.Models
{
	public class Ticket
	{
        [Key]
        public int TicketId { get; set; }
        [Required(ErrorMessage = "Debe ingresar una fecha.")]
		[DataType(DataType.Date)]
		public string Fecha { get; set; } = string.Empty;
		[ForeignKey("Clientes")]
		[Required(ErrorMessage = "Campo requerido.")]
		public int ClienteId { get; set; }
		[ForeignKey("Sistemas")]
		[Required(ErrorMessage = "Campo requerido.")]
		public int SistemaId { get; set; }
		[ForeignKey("Prioridades")]
		[Required(ErrorMessage = "Campo requerido.")]
		public int PrioridadId { get; set; }
		[Required(ErrorMessage = "Campo requerido.")]
		public string SolicitadoPor { get; set; } = string.Empty;
		[Required(ErrorMessage = "Campo requerido.")]
		public string Asunto { get; set; } = string.Empty;
		[Required(ErrorMessage = "Campo requerido.")]

		public string Descripcion { get; set; } = string.Empty;
    }
}