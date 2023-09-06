using Microsoft.EntityFrameworkCore;
using Registro_Clientes.Models;

namespace Registro_Clientes.DAL
{
    public class TicketContext : DbContext
    {
        public TicketContext(DbContextOptions<TicketContext> options) : base(options) { }

        public DbSet<Tickets> Tickets { get; set; }
    }
}
