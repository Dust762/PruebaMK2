using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMK2Modelo.DTO
{
    public class Mensaje
    {
        private String emisor;
        private String receptor;
        private String mensa;
        
        public Mensaje(String emisor, String receptor, String mensa) {
            this.emisor = emisor;
            this.receptor = receptor;
            this.mensa = mensa;
        
        }
        public string Emisor {get => emisor; set => emisor = value; }
        public string Receptor {get => receptor; set  => receptor = value; }
        public string Mensa {get => mensa; set => mensa = value; }

        public override string ToString()
        {
            String direccion = "Emisor: " + this.Emisor + ", Receptor: " + this.Receptor;
            String msg = this.Mensa;
            return direccion +"\n" + msg;
        }
    }
}
