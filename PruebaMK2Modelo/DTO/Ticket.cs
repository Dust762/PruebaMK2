using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMK2Modelo.DTO
{

    public struct Prioridad
    {

        public String Nombre { get; set; }
        public int codPrioridad { get; set; }
    }
    public struct Estado
    {
        public String estadoNombre { get; set; }
        public int codEstado { get; set; }
    }
    public class Ticket
    {
        private static int nroTicket;
        private int idTicket;
        private String categoria;
        private String descripcion;
        private String observaciones;
        private String nombreUsuario;
        private String nombreTecnico;
        
        private List<String> listaDeObservaciones;
        public Ticket(string nombreUsuario, string nombreTecnico, string descripcion, string categoria)
        {
            this.idTicket = ++Ticket.nroTicket;
            this.categoria = categoria;
            this.descripcion = descripcion;
            this.nombreUsuario = nombreUsuario;
            this.nombreTecnico = nombreTecnico;
            
            this.listaDeObservaciones = new List<string>();
        }

        public int IdTicket { get => idTicket; set => idTicket = value; }
        public string Categoria { get => categoria; set => categoria = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public string NombreTecnico { get => nombreTecnico; set => nombreTecnico = value; }
        public List<string> ListaDeObservaciones { get => listaDeObservaciones; set => listaDeObservaciones = value; }

        public Estado Estado { get; set; }
        public Prioridad Prioridad { get; set; }
        

        public override string ToString()
        {
            return "{" + "Id Ticket: " + this.IdTicket + ", Usuario: " + this.NombreUsuario + ", Tecnico asignado: " + this.NombreTecnico + ", Descripcion: " + this.Descripcion + ", Categoria: " + this.Categoria;
        }

        public void agregarObservacion(String s)
        {

            this.listaDeObservaciones.Add(s);
        }
        public List<String> mostrarObservaciones()
        {

            return listaDeObservaciones;
        }

    }
}
