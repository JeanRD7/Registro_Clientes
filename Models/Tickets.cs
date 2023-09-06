using System.ComponentModel.DataAnnotations;

namespace Registro_Clientes.Models
{
    public class Tickets
    {
        [Key]

        public int TicketId { get; set; }

        [Required (ErrorMessage ="El nombre del Ticket es necesario")]

        public string? Nombre { get; set;}
    }
}
