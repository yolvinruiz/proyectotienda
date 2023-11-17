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
 //Patron Singleton
 // Variable estática para la instancia
 private static readonly datproducto _instancia = new datproducto();
        //privado para evitar la instanciación directa
        public static datproducto Instancia
        {
            get
            {
                return datproducto._instancia;
            }
        }
 /////////////////////////InsertaProducto
 public Boolean InsertarProducto(entproducto pro)
{
    SqlCommand cmd = null;
    Boolean inserta = false;
    try
    {
        SqlConnection cn = conexion.Instancia.Conectar();
        cmd = new SqlCommand("spInsertarProducto", cn);
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
    catch (Exception e)
    {
        throw e;
    }
    finally { cmd.Connection.Close(); }
    return inserta;
}


