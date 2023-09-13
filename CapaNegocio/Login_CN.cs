using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;

namespace CapaNegocio
{
    public class Login_CN
    {
        public int ConsultaLogin(string usuario, string password)
        {


            Conectar conectar = new Conectar();
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DP04AGL\SQLEXPRESS;Initial Catalog=SistemaBancario;INTEGRATED SECURITY= TRUE");
            
            try
            {
                conectar.Abrir();
                SqlCommand cmd = new SqlCommand("spLogin", conectar.conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nombre1", usuario);
                cmd.Parameters.AddWithValue("@clave", password);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    return dr.GetInt32(0);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                conectar.Cerrar();
            }
            return -1;
        }
    }
}
