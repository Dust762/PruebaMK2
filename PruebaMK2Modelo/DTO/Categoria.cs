using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMK2Modelo.DTO
{
    public class Categoria
    {
        private static int nroCat;
        private String nombreCategoria;
        private int codCategoria;
        public Categoria(String categoria)
        {
            this.codCategoria = ++nroCat;
            this.nombreCategoria = categoria;
        }

        public string NombreCategoria { get => nombreCategoria; set => nombreCategoria = value; }
        public int CodCategoria { get => codCategoria; set => codCategoria = value; }


        public override string ToString()
        {
            return "{" + "Nombre de categoria: " + this.NombreCategoria + " y " + "Codigo de la categoria: " + this.CodCategoria;

        }
    }
}
