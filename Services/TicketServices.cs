using Microsoft.EntityFrameworkCore;
using RegistroPrioridades.DAL;
using RegistroPrioridades.Models;
using System.Linq.Expressions;

namespace RegistroPrioridades.Services
{
	public class TicketServices
	{
		private readonly Contexto _contexto;

		public TicketServices(Contexto context)
		{
			_contexto = context;
		}
		
		public async Task<bool> Guardar(Tickets ticket)
		{
			if (!await Existe(ticket.TicketId))
				return await Insertar(ticket);
			else
				return await Modificar(ticket);
		}

		public async Task<bool> Insertar(Tickets ticket)
		{
			_contexto.Tickets.Add(ticket);
			return await _contexto.SaveChangesAsync() > 0;
		}

		public async Task<bool> Modificar(Tickets ticket)
		{
			_contexto.Update(ticket);
			return await _contexto.SaveChangesAsync() > 0;
		}

		public async Task<bool> Existe(int sistemaId)
		{
			return await _contexto.Tickets
				.AnyAsync(t => t.SistemaId == sistemaId);
		}

		public async Task<bool> Eliminar(Tickets ticket)
		{
			var cantidad = await _contexto.Tickets
				.Where(t => t.TicketId == ticket.TicketId)
				.ExecuteDeleteAsync();
			return cantidad > 0;
		}

		public async Task<Tickets?> BuscarId(int ticketId)
		{
			return await _contexto.Tickets
				.AsNoTracking()
				.FirstOrDefaultAsync(t => t.TicketId == ticketId);
		}

		public async Task<Tickets?> BuscarCliente(int clienteId)
		{
			return await _contexto.Tickets
				.AsNoTracking()
				.FirstOrDefaultAsync(t => t.ClienteId == clienteId);
		}
		public async Task<Tickets?> BuscarFecha(DateTime fecha)
		{
			return await _contexto.Tickets
				.AsNoTracking()
				.FirstOrDefaultAsync(t => t.Fecha == fecha);
		}

		public async Task<Tickets?> BuscarDescripcion(string descripcion)
		{
			return await _contexto.Tickets
				.AsNoTracking()
				.FirstOrDefaultAsync(t => t.Descripcion == descripcion);
		}
		public List<Tickets> Listar(Expression<Func<Tickets, bool>> criterio)
		{
			return _contexto.Tickets
				.AsNoTracking()
				.Where(criterio)
				.ToList();
		}
	}
}