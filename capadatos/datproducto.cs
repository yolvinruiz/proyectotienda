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

        ////////////////////listado de Clientes
        public List<entproducto> ListarCliente()
        {
            SqlCommand cmd = null;
            List<entproducto> lista = new List<entproducto>();
            try
            {
                SqlConnection cn = conexion.Instancia.Conectar(); //singleton
                cmd = new SqlCommand("spListarCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entproducto pro = new entproducto();
                    pro.idproducto = Convert.ToInt32(dr["idproducto"]);
                    pro.nombre = dr["nombre"].ToString();
                    pro.descripcion = dr["descripcion"].ToString();
                    pro.precio = Convert.ToDecimal(dr["precion"]);
                    pro.estado = Convert.ToBoolean(dr["estado"]);
                    pro.rubro = dr["rubro"].ToString();
                    lista.Add(pro);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
 finally
 {
 cmd.Connection.Close();
 }
return lista;
 }
 /////////////////////////InsertaCliente
 public Boolean InsertarCliente(entproducto pro)
{
    SqlCommand cmd = null;
    Boolean inserta = false;
    try
    {
        SqlConnection cn = conexion.Instancia.Conectar();
        cmd = new SqlCommand("spInsertarCliente", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@nombre", pro.nombre);
        cmd.Parameters.AddWithValue("@descripcion", pro.descripcion);
        cmd.Parameters.AddWithValue("@precio", pro.precio);
        cmd.Parameters.AddWithValue("@estado", pro.estado);
        cmd.Parameters.AddWithValue("@rubro", pro.rubro);
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
//////////////////////////////////EditaCliente
public Boolean EditarCliente(entproducto pro)
{
    SqlCommand cmd = null;
    Boolean edita = false;
    try
    {
        SqlConnection cn = conexion.Instancia.Conectar();
        cmd = new SqlCommand("spEditarCliente", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@nombre", pro.nombre);
        cmd.Parameters.AddWithValue("@descripcion", pro.descripcion);
        cmd.Parameters.AddWithValue("@precio", pro.precio);
        cmd.Parameters.AddWithValue("@estado", pro.estado);
        cmd.Parameters.AddWithValue("@rubro", pro.rubro);
 
 cn.Open();
 int i = cmd.ExecuteNonQuery();
 if (i > 0)
 {
 edita = true;
 }
}
 catch (Exception e)
{
    throw e;
}
finally { cmd.Connection.Close(); }
return edita;
 }
 //deshabilitaCliente
 public Boolean DeshabilitarCliente(entproducto pro)
{
    SqlCommand cmd = null;
    Boolean delete = false;
    try
    {
        SqlConnection cn = conexion.Instancia.Conectar();
        cmd = new SqlCommand("spDesabilitarCliente", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@idproducto", pro.idproducto );
        cmd.Parameters.AddWithValue("@estado", pro.estado);
        cn.Open();
        int i = cmd.ExecuteNonQuery();
        if (i > 0)
        {
            delete = true;
        }
    }
    catch (Exception e)
    {
        throw e;
    }
    finally { cmd.Connection.Close(); }
    return delete;
}
 }
    }

