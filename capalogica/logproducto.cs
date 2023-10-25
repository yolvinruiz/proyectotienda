﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaentidad;
using capadatos;

namespace capalogica
{
    public class logproducto
    {
        #region sigleton
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
        #endregion singleton
        #region metodos
        ///listado

        public List<entproducto> ListarCliente()
        {
            return datproducto.Instancia.ListarCliente();
        }
        ///inserta
        public void InsertaCliente(entproducto Cli)
        {
            datproducto.Instancia.InsertarCliente(Cli);
        }
        //edita
        public void EditaCliente(entproducto Cli)
        {
            datproducto.Instancia.EditarCliente(Cli);
        }
        public void DeshabilitarCliente(entproducto Cli)
        {
            datproducto.Instancia.DeshabilitarCliente(Cli);
        }
        #endregion metodos
    
}
}