using PruebaMK2Modelo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMK2Modelo.DAL
{
    
    public class TecnicoDAL
    {
        public static List<Tecnico> tecnicos = new List<Tecnico>();

        public void agregarTecnico(Tecnico t) {

            tecnicos.Add(t);
        }

        public void eliminarTecnico(Tecnico t) {
            tecnicos.Remove(t);
        }
        public List<Tecnico> mostrarTecnicos() {

            return tecnicos;
        }

        public void actualizarTecnico() { 
            
        }

    }
}
