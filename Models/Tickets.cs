using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroPrioridades.Models
{
	public class Tickets
	{
        [Key]
        public int TicketId { get; set; }
		[Required(ErrorMessage = "Debe ingresar una fecha.")]
		[DataType(DataType.Date)]
		public DateTime Fecha { get; set; } = DateTime.Now;
		[ForeignKey("Clientes")]
		[Required(ErrorMessage = "Este campo es obligatorio.")]
		public int ClienteId { get; set; }
		[ForeignKey("Sistemas")]
		[Required(ErrorMessage = "Este campo es obligatorio.")]
		public int? SistemaId { get; set; }
		[ForeignKey("Prioridades")]
		[Required(ErrorMessage = "Este campo es obligatorio.")]
		public int? PrioridadId { get; set; }
		[Required(ErrorMessage = "Este campo es obligatorio.")]
		public string SolicitadoPor { get; set; } = string.Empty;
		[Required(ErrorMessage = "Este campo es obligatorio.")]
		public string Asunto { get; set; } = string.Empty;
		[Required(ErrorMessage = "Este campo es obligatorio.")]

		public string Descripcion { get; set; } = string.Empty;
    }
}