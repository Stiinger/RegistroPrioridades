using Microsoft.EntityFrameworkCore;
using RegistroPrioridades.DAL;
using RegistroPrioridades.Models;
using System.Linq.Expressions;

namespace RegistroPrioridades.BLL
{
    public class ClienteBLL
    {
        private readonly Contexto _contexto;
        public ClienteBLL(Contexto contexto)
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

        public async Task<Cliente?> Buscar(int clienteId)
        {
            return await _contexto.Clientes
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.ClienteId == clienteId);
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