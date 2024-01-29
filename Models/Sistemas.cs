using System.ComponentModel.DataAnnotations;

namespace RegistroPrioridades.Models
{
	public class Sistemas
	{
		[Key]
		public int SistemaId { get; set; }

		[Required(ErrorMessage = "Campo requerido.")]
		public string Nombre { get; set; } = string.Empty;
	}
}
