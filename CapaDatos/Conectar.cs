using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class Conectar
    {
        public SqlConnection conexion { get; set; }
        private SqlTransaction transaccion { get; set; }

        public Conectar()
        {
            string cadenaConexion = @"Data Source=DESKTOP-DP04AGL\SQLEXPRESS;Initial Catalog=SistemaBancario;INTEGRATED SECURITY= TRUE";
            conexion = new SqlConnection(cadenaConexion);

        }

        public void Abrir()
        {

            if (conexion.State != ConnectionState.Open)
            {
                try
                {
                    conexion.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR AL CONECTAR A LA BASE DE DATOS: " + ex.Message);
                }
            }
        }

        public void Cerrar()
        {
            if (transaccion == null) { conexion.Close(); }
        }


        public DataTable EjecutarConsultaSelect(string sql, CommandType tipo, params SqlParameter[] parametros)
        {
            var cmd = conexion.CreateCommand();

            cmd.CommandTimeout = int.MaxValue;
            if (transaccion != null)
            {
                cmd.Transaction = transaccion;
            }

            cmd.CommandText = sql;
            cmd.CommandType = tipo;

            if (parametros != null)
            {
                cmd.Parameters.AddRange(parametros);
            }

            DataTable tabla = new DataTable("resultado");

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);
                this.Cerrar();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                tabla = null;
            }

            return tabla;
        }
    }
}
