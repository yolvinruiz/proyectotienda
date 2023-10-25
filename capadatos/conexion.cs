using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace capadatos
{
    public class conexion
    {

        //patron de Diseño Singleton
        private static readonly conexion _instancia = new conexion();
        public static conexion Instancia
        {
            get { return conexion._instancia; }
        }

        public SqlConnection Conectar()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Data Source=.; Initial Catalog = moanso;" +"Password = 123;"+"Integrated Security=true";

            return cn;
        }
    }
}

