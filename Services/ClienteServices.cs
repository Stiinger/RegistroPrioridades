using Microsoft.EntityFrameworkCore;
using RegistroPrioridades.DAL;
using RegistroPrioridades.Models;
using System.Linq.Expressions;

namespace RegistroPrioridades.BLL
{
    public class ClienteServices
    {
        private readonly Contexto _contexto;
        public ClienteServices(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> Guardar(Cliente cliente)
        {
            if (!await Existe(cliente.ClienteId))
                return await Insertar(cliente);
            else
                return await Modificar(cliente);
        }

        private async Task<bool> Insertar(Cliente cliente)
        {
            _contexto.Clientes.Add(cliente);
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Cliente cliente)
        {
            _contexto.Update(cliente);
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Existe(int clienteId)
        {
            return await _contexto.Clientes
                .AnyAsync(c => c.ClienteId == clienteId);
        }

        public async Task<bool> Eliminar(Cliente cliente)
        {
            var cantidad = await _contexto.Clientes
                .Where(c => c.ClienteId == cliente.ClienteId)
                .ExecuteDeleteAsync();

            return cantidad > 0;
        }

        public async Task<Cliente?> BuscarId(int clienteId)
        {
            return await _contexto.Clientes
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.ClienteId == clienteId);
        }

        public async Task<Cliente?> BuscarNombre(string nombre)
        {
            return await _contexto.Clientes
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Nombres.ToLower() == nombre.ToLower());
        }

        public async Task<Cliente?> BuscarRNC(string RNC)
        {
            return await _contexto.Clientes
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.RNC == RNC);
        }
        public List<Cliente> Listar(Expression<Func<Cliente, bool>> criterio)
        {
            return _contexto.Clientes
                .AsNoTracking()
                .Where(criterio)
                .ToList();
        }
    }
}