using PruebaMK2Modelo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMK2Modelo.DAL
{
    public class MensajeDAL
    {
        public static List<Mensaje> mensajes = new List<Mensaje>();

        public void crearMensaje(Mensaje m)
        {

            mensajes.Add(m);
        }

        public void eliminarMensaje(Mensaje m)
        {
            mensajes.Remove(m);
        }

        public List<Mensaje> mostrarMensajes()
        {
            return mensajes;
        }

        public void actualizarCategoria()
        {

        }
    }
}
