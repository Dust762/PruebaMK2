using PruebaMK2Modelo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMK2Modelo.DAL
{
    public class TicketDAL
    {
        public static List<Ticket> tickets = new List<Ticket>();

        public static readonly Estado EnProgreso = new Estado()
        {
            estadoNombre = "En progreso",
            codEstado = 1

        };
        public static readonly Estado Pendiente = new Estado()
        {
            estadoNombre = "Pendiente",
            codEstado = 2

        };

        public static readonly Estado Bloqueado = new Estado()
        {
            estadoNombre = "Bloqueado",
            codEstado = 3

        };

        public static readonly Estado Cerrado = new Estado() 
        { 
            estadoNombre = "Cerrado",
            codEstado = 4

        };

        public static readonly Prioridad Emergencia = new Prioridad() 
        {
            Nombre = "Emergencia",
            codPrioridad = 1
            
        };

        public static readonly Prioridad Necesaria = new Prioridad()
        {
            Nombre = "Necesaria",
            codPrioridad = 2
            
        };

        public static readonly Prioridad Opcional = new Prioridad()
        {
            Nombre = "Opcional",
            codPrioridad = 3
        };

        
        public void agregarTicket(Ticket t) {
            tickets.Add(t);
        }
        public List<Ticket> mostrarTicket() {
            return tickets;
        }
        public void eliminarTicket(Ticket t) {
            tickets.Remove(t);
        }
        public void actualizarTicket(Ticket t, String cambio, string option) {
            switch (option)
	        {
		     case "1":
                t.NombreUsuario = cambio;
                break;
             case "2":
                t.NombreTecnico = cambio;
                break;
             case "3":
                t.Descripcion = cambio;
                break;
             case "4":
                t.Categoria = cambio;
                break;
	        }

        }
    }
}
