using Registro_Clientes.DAL;

namespace Registro_Clientes.BLL
{
    public class TicketsBLL
    {
        private readonly TicketContext _contexto;

        public TicketsBLL(TicketContext contexto)
        {
            _contexto = contexto;
        }
    }
}
