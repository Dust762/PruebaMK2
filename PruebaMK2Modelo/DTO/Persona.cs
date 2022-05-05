using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMK2Modelo.DTO
{
    public class Persona
    {
        private String rut;
        private String nombre;
        private String apellido;
        private String sexo;


        public Persona(String rut, String nombre, String apellido, String sexo)
        {
            this.Rut = rut;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Sexo = sexo;

        }

        public string Rut { get => rut; set => rut = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Sexo { get => sexo; set => sexo = value; }

        public override string ToString()
        {
            String dato = "{" + "Rut: " + this.Rut + ", Nombre: " + this.Nombre + ", Apellido: " + this.Apellido + ", Sexo: " + this.Sexo;
            return dato;
        }
    }
}
