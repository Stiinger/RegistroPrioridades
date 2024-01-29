using Microsoft.EntityFrameworkCore;
using RegistroPrioridades.DAL;
using RegistroPrioridades.Models;
using System.Linq.Expressions;

namespace RegistroPrioridades.BLL
{
    public class PrioridadServices
    {
        private readonly Contexto _contexto;

        public PrioridadServices(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> Guardar(Prioridad prioridad)
        {
            if (!await Existe(prioridad.PrioridadId))
                return await Insertar(prioridad);
            else
                return await Modificar(prioridad);
        }

        private async Task<bool> Insertar(Prioridad prioridad)
        {
            _contexto.Prioridades.Add(prioridad);
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Prioridad prioridad)
        {
            _contexto.Update(prioridad);
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Existe(int PrioridadId)
        {
            return await _contexto.Prioridades
                .AnyAsync(p => p.PrioridadId == PrioridadId);
        }

        public async Task<bool> Eliminar(Prioridad prioridad)
        {
            var cantidad = await _contexto.Prioridades
                .Where(p => p.PrioridadId == prioridad.PrioridadId)
                .ExecuteDeleteAsync();

            return cantidad > 0;
        }

        public async Task<Prioridad?> BuscarId(int prioridadId)
        {
            return await _contexto.Prioridades
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.PrioridadId == prioridadId);
        }

        public async Task<Prioridad?> BuscarDescripcion(string descripcion)
        {
            return await _contexto.Prioridades
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Descripcion.ToLower() == descripcion.ToLower());
        }
        public List<Prioridad> Listar(Expression<Func<Prioridad, bool>> criterio)
        {
            return _contexto.Prioridades
                .AsNoTracking()
                .Where(criterio)
                .ToList();
        }
    }
}