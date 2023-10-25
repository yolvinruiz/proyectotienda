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
    class datproducto
    { 
 #region sigleton
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
        #endregion singleton
        #region metodos
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
 public Boolean InsertarCliente(entCliente Cli)
{
    SqlCommand cmd = null;
    Boolean inserta = false;
    try
    {
        SqlConnection cn = Conexion.Instancia.Conectar();
        cmd = new SqlCommand("spInsertarCliente", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@razonSocial", Cli.razonSocial);
        cmd.Parameters.AddWithValue("@idTipoCliente", Cli.idTipoCliente);
        cmd.Parameters.AddWithValue("@fecRegCliente", Cli.fecRegCliente);
        cmd.Parameters.AddWithValue("@idCiudad", Cli.idCiudad);
        cmd.Parameters.AddWithValue("@estCliente", Cli.estCliente);
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
public Boolean EditarCliente(entCliente Cli)
{
    SqlCommand cmd = null;
    Boolean edita = false;
    try
    {
        SqlConnection cn = Conexion.Instancia.Conectar();
        cmd = new SqlCommand("spEditarCliente", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@idCliente", Cli.idCliente);
        cmd.Parameters.AddWithValue("@razonSocial", Cli.razonSocial);
        cmd.Parameters.AddWithValue("@idTipoCliente", Cli.idTipoCliente);
        cmd.Parameters.AddWithValue("@fecRegCliente", Cli.fecRegCliente);
 cmd.Parameters.AddWithValue("@idCiudad", Cli.idCiudad);
 cmd.Parameters.AddWithValue("@estCliente", Cli.estCliente);
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
 public Boolean DeshabilitarCliente(entCliente Cli)
{
    SqlCommand cmd = null;
    Boolean delete = false;
    try
    {
        SqlConnection cn = Conexion.Instancia.Conectar();
        cmd = new SqlCommand("spDesabilitarCliente", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@idCliente", Cli.idCliente);
        cmd.Parameters.AddWithValue("@estCliente", Cli.estCliente);
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
 #endregion metodos
 }
    }

