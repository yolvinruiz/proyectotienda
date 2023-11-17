using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using capaentidad;
using capadatos;
namespace capadatos
{
    public class datproducto
    { 
        #region singleton
        private static readonly datCliente _instancia = new datCliente();
        public static datCliente Instancia{
            get { return datCliente._instancia; }
        }
        #endregion singleton
 /////////////////////////InsertaProducto
 public Boolean InsertarProducto(entproducto c)
{
    SqlCommand cmd = null;
    Boolean inserta = false;
    try
    {
        SqlConnection c = conexion.Instancia.Conectar();
        cmd = new SqlCommand("spInsertarProducto", c);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@nombre", pro.nombre);
        cmd.Parameters.AddWithValue("@precio", pro.precio);
        cmd.Parameters.AddWithValue("@estado", pro.estado);
        cn.Open();
        int i = cmd.ExecuteNonQuery();
        if (i > 0)
        {
            inserta = true;
        }
    }
    catch (Exception c)
    {
        throw c;
    }
    finally { cmd.Connection.Close(); }
    return inserta;
}


