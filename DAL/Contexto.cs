using Microsoft.EntityFrameworkCore;
using RegistroPrioridades.Models;

namespace RegistroPrioridades.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }
        public DbSet<Prioridades> Prioridades { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Sistemas> Sistemas { get; set; }
        public DbSet<Tickets> Tickets { get; set; }
    }
}