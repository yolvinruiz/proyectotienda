using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaentidad;
using capadatos;
using capalogica;

namespace capalogica
{
    public class logproducto
    {

        //Patron Singleton
        // Variable estática para la instancia
        private static readonly logproducto _instancia = new logproducto();
        //privado para evitar la instanciación directa
        public static logproducto Instancia
        {
            get
            {
                return logproducto._instancia;
            }
        }
        ///inserta
         public  void InsertarProducto(entproducto c)
            {
                datproducto.Instancia.InsertarProducto(c);
            }
        }

    }
}   


