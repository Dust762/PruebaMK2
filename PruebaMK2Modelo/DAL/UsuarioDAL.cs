using PruebaMK2Modelo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMK2Modelo.DAL
{
    public class UsuarioDAL
    {
        public static List<Usuario> usuarios = new List<Usuario>();

        public void agregarUsuario(Usuario u) {
            usuarios.Add(u);
        }
        public List<Usuario> mostrarUsuarios() {
            return usuarios;
        }

        public void eliminarUsuario(Usuario u) {
            usuarios.Remove(u);
        }

        public void actualizarUsuario(Usuario u) { 
            
        }
    }
}
