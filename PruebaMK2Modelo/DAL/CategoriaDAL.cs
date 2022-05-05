using PruebaMK2Modelo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMK2Modelo.DAL
{
    public class CategoriaDAL
    {
        public static List<Categoria> categorias = new List<Categoria>();

        public void agregarCategoria(Categoria c) {

            categorias.Add(c);
        }

        public void eliminarCategoria(Categoria c) {
            categorias.Remove(c);
        }

        public List<Categoria> mostrarCategorias() {
            return categorias;
        }

        public void actualizarCategoria() { 
            
        }
    }
}
