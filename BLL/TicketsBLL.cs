using Microsoft.EntityFrameworkCore;
using Registro_Clientes.DAL;
using Registro_Clientes.Models;
using System.Linq.Expressions;

namespace Registro_Clientes.BLL
{
    public class TicketsBLL
    {
        private readonly TicketContext _contexto;

        public TicketsBLL(TicketContext contexto)
        {
            _contexto = contexto;
        }

        //metodo existe
        public bool Existe(int TicketId)
        {
            return _contexto.Tickets.Any(op => op.TicketId == TicketId);
        }

        //metodo insertar
        private bool Insertar(Tickets Ticket)
        {
            _contexto.Tickets.Add(Ticket);
            int cantidad = _contexto.SaveChanges();
            return cantidad > 0;
        }

        //metodo modificar
        public bool Modificar(Tickets Ticket)
        {
            _contexto.Update(Ticket);
            int cantidad = _contexto.SaveChanges();
            return cantidad > 0;
        }

        //metodo guardar
        public bool Guardar(Tickets Ticket)
        {
            if (!Existe(Ticket.TicketId))
                return Insertar(Ticket);
            else
                return Modificar(Ticket);
        }

        //metodo eliminar
        public bool Eliminar(Tickets Ticket)
        {
            _contexto.Tickets.Remove(Ticket);
            int cantidad = _contexto.SaveChanges();
            return cantidad > 0;
        }

        //metodo buscar
        public Tickets? Buscar(int TicketId)
        {
            return _contexto.Tickets
                .AsTracking()
                .FirstOrDefault(op => op.TicketId == TicketId);
        }

        //metodo Getlist
        public List<Tickets> GetList(Expression<Func<Tickets, bool>> Criterio)
        {
            return _contexto.Tickets
                .Where(Criterio)
                .AsNoTracking() 
                .ToList();
        }
    }
}
