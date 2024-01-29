using Microsoft.EntityFrameworkCore;
using RegistroPrioridades.DAL;
using RegistroPrioridades.Models;
using System.Linq.Expressions;

namespace RegistroPrioridades.Services
{
    public class PrioridadServices
    {
        private readonly Contexto _contexto;

        public PrioridadServices(Contexto contexto)
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

        public async Task<Prioridades?> BuscarId(int prioridadId)
        {
            return await _contexto.Prioridades
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.PrioridadId == prioridadId);
        }

        public async Task<Prioridades?> BuscarDescripcion(string descripcion)
        {
            return await _contexto.Prioridades
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Descripcion.ToLower() == descripcion.ToLower());
        }
        public List<Prioridades> Listar(Expression<Func<Prioridades, bool>> criterio)
        {
            return _contexto.Prioridades
                .AsNoTracking()
                .Where(criterio)
                .ToList();
        }
    }
}