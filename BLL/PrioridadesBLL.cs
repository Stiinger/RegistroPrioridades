using Microsoft.EntityFrameworkCore;
using RegistroPrioridades.Components.Pages.Registros;
using RegistroPrioridades.DAL;
using RegistroPrioridades.Models;
using System.Linq.Expressions;

namespace RegistroPrioridades.BLL
{
    public class PrioridadesBLL
    {
        private readonly Contexto _contexto;

        public PrioridadesBLL(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> Guardar(Prioridades prioridad)
        {
            if (!await Existe(prioridad.PrioridadId))
                return await Insertar(prioridad);
            else
                return await Modificar(prioridad);
        }

        private async Task<bool> Insertar(Prioridades prioridad)
        {
            _contexto.Prioridades.Add(prioridad);
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Prioridades prioridad)
        {
            _contexto.Update(prioridad);
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Existe(int PrioridadId)
        {
            return await _contexto.Prioridades
                .AnyAsync(p => p.PrioridadId == PrioridadId);
        }

        public async Task<bool> Eliminar(Prioridades prioridad)
        {
            var cantidad = await _contexto.Prioridades
                .Where(p => p.PrioridadId == prioridad.PrioridadId)
                .ExecuteDeleteAsync();

            return cantidad > 0;
        }

        public async Task<Prioridades?> Buscar(int prioridadId)
        {
            return await _contexto.Prioridades
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.PrioridadId == prioridadId);
        }
        public async Task<List<Prioridades>> Listar(Expression<Func<Prioridades, bool>> criterio)
        {
            return await _contexto.Prioridades
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
        public async Task<Prioridades?> BuscarDescripcion(string? descripcion)
        {
            return await _contexto.Prioridades.SingleOrDefaultAsync(p => p.Descripcion == descripcion);
        }
    }
}