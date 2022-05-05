using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMK2Modelo.DTO
{
    public class Tecnico : Persona
    {
        private static int nroTecnico;
        private int idTecnico;
        private List<Ticket> ticketsAsignados;
        public Tecnico(String rut, String nombre, String apellido, String sexo) : base(rut, nombre, apellido, sexo)
        {
            base.Rut = rut;
            base.Nombre = nombre;
            base.Apellido = apellido;
            base.Sexo = sexo;
            this.IdTecnico = ++Tecnico.nroTecnico;
            this.ticketsAsignados = new List<Ticket>();
        }

        public int IdTecnico { get => idTecnico; set => idTecnico = value; }
        public List<Ticket> TicketsAsignados { get => ticketsAsignados; set => ticketsAsignados = value; }

        public override string ToString()
        {

            return base.ToString() + ", IdTecnico: " + this.IdTecnico + "}";
        }

        public void agregarTicket(Ticket t) {
            this.TicketsAsignados.Add(t);
        }

        public List<Ticket> mostrarTicketsAsignados() {
            return TicketsAsignados;
        }
    }
}
