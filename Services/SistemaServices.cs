using Microsoft.EntityFrameworkCore;
using RegistroPrioridades.DAL;
using RegistroPrioridades.Models;
using System.Linq;
using System.Linq.Expressions;

namespace RegistroPrioridades.Services
{
	public class SistemaServices
	{
		private readonly Contexto _contexto;

		public SistemaServices(Contexto context)
		{
			_contexto = context;
		}

		public async Task<bool> Crear(Sistema sistema)
		{
			if (!await Existe(sistema.SistemaId))
				return await Insertar(sistema);
			else
				return await Modificar(sistema);
		}

		public async Task<bool> Insertar(Sistema sistema)
		{
			_contexto.Sistemas.Add(sistema);
			return await _contexto.SaveChangesAsync() > 0;
		}

		public async Task<bool> Modificar(Sistema sistema)
		{
			_contexto.Update(sistema);
			return await _contexto.SaveChangesAsync() > 0;
		}

		public async Task<bool> Existe(int sistemaId)
		{
			return await _contexto.Sistemas.AnyAsync(s => s.SistemaId == sistemaId);
		}

		public async Task<bool> Eliminar(Sistema sistema)
		{
			var cantidad = await _contexto.Sistemas
				.Where(s => s.SistemaId == sistema.SistemaId)
				.ExecuteDeleteAsync();
			return cantidad > 0;
		}

		public async Task<Sistema?> BuscarId(int sistemaId)
		{
			return await _contexto.Sistemas
				.AsNoTracking()
				.FirstOrDefaultAsync(s => s.SistemaId == sistemaId);
		}

		public async Task<Sistema?> BuscarNombre(string nombre)
		{
			return await _contexto.Sistemas
			.AsNoTracking()
			.FirstOrDefaultAsync(s => s.Nombre.ToLower() == nombre.ToLower());
		}

		public List<Sistema> Listar(Expression<Func<Sistema, bool>> criterio)
		{
			return _contexto.Sistemas
				.AsNoTracking()
				.Where(criterio)
				.ToList();
		}
	}
}