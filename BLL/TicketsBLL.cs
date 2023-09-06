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
            return _contexto.SaveChanges() > 0;
        }

        //metodo modificar
        public bool Modificar(Tickets Ticket)
        {

            var existe = _contexto.Tickets.Find(Ticket.TicketId);
            if (existe != null)
            {
                _contexto.Entry(existe).CurrentValues.SetValues(Ticket);
                return _contexto.SaveChanges() > 0;
            }
            return false;
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
        public bool Eliminar(int TicketId)
        {
            var eliminado = _contexto.Tickets.Where(op => op.TicketId == TicketId).SingleOrDefault();
            if(eliminado != null)
            {
                _contexto.Entry(eliminado).State = EntityState.Deleted;
                return _contexto.SaveChanges() > 0;
            }
            return false;
        }

        //metodo buscar
        public Tickets? Buscar(int TicketId)
        {
            return _contexto.Tickets.Where(op => op.TicketId == TicketId).AsNoTracking().SingleOrDefault();
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
