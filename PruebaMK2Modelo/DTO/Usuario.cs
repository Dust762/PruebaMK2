using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMK2Modelo.DTO
{
    public class Usuario : Persona
    {
        private static int nroUsuario;
        private int idUsuario;

        public Usuario(int idUsuario, String rut, String nombre, String apellido, String sexo) : base(rut,nombre,apellido,sexo)
        {
            base.Rut = rut;
            base.Nombre = nombre;
            base.Apellido = apellido;
            base.Sexo = sexo;
            this.idUsuario = ++Usuario.nroUsuario;
        }

        public int IdUsuario { get => idUsuario; set => idUsuario = value; }

        public override string ToString()
        {
            return base.ToString() + ", Id Usuario: " + this.IdUsuario + "}";
        }
    }
}
