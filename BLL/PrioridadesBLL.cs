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

        public bool Guardar(Prioridades Prioridad)
        {
            if (!Existe(Prioridad.PrioridadId))
                return Insertar(Prioridad);
            else
                return Modificar(Prioridad);
        }
        public bool Existe(int PrioridadId)
        {
            return _contexto.Prioridades.Any(p => p.PrioridadId == PrioridadId);
        }
        private bool Insertar(Prioridades Prioridad)
        {
            _contexto.Prioridades.Add(Prioridad);
            int cantidad = _contexto.SaveChanges();
            return cantidad > 0;
        }
        private bool Modificar(Prioridades Prioridad)
        {
            _contexto.Update(Prioridad);
            int cantidad = _contexto.SaveChanges();
            return cantidad > 0;
        }
        public Prioridades? Buscar(int PrioridadId)
        {
            return _contexto.Prioridades
                    .AsNoTracking()
                    .SingleOrDefault(p => p.PrioridadId == PrioridadId);
        }
        public Prioridades? BuscarDescripcion(string? descripcion)
        {
            return _contexto.Prioridades.SingleOrDefault(p => p.Descripcion == descripcion);
        }

        public bool Eliminar(Prioridades Prioridad)
        {
            var prioridad = _contexto.Prioridades.Find(Prioridad.PrioridadId);
            if (prioridad != null)
            {
                _contexto.Prioridades.Remove(prioridad);
                return _contexto.SaveChanges() > 0;
            }
            return false;
        }
        public List<Prioridades> GetList(Expression<Func<Prioridades, bool>> Criterio)
        {
            return _contexto.Prioridades
                    .Where(Criterio)
                    .AsNoTracking()
                    .ToList();
        }
    }
}
