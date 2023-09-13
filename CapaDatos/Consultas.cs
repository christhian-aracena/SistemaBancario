using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaDatos
{
    public class Consultas
    {
        Conectar conexion = new Conectar();


        public DataTable GetNombre(string nombre1, string clave)
        {

            conexion.Abrir();


            DataTable tabla = conexion.EjecutarConsultaSelect("select nombre1, apellidoPaterno, apellidoMaterno from Usuario where nombre1 = '" + nombre1 + "' AND clave = '" + clave + "'", CommandType.Text, null);

            conexion.Cerrar();

            return tabla;

        }

        public DataTable GetSaldo(string nombre1, string clave)
        {

            conexion.Abrir();


            DataTable tabla = conexion.EjecutarConsultaSelect("SELECT FORMAT (saldo, 'c', 'es-CL') from usuario where nombre1 = '" + nombre1 + "' AND clave = '" + clave + "'", CommandType.Text, null);

            conexion.Cerrar();

            return tabla;

        }

        public DataTable GetSaldoInvisible(string nombre1, string clave)
        {

            conexion.Abrir();


            DataTable tabla = conexion.EjecutarConsultaSelect("SELECT idUsuario, saldo, nombre1, apellidoPaterno from usuario where nombre1 = '" + nombre1 + "' AND clave = '" + clave + "'", CommandType.Text, null);

            conexion.Cerrar();

            return tabla;

        }

        public DataTable GetNotificacion(int idDestino)
        {

            conexion.Abrir();


            DataTable tabla = conexion.EjecutarConsultaSelect("SELECT * FROM notificaciones WHERE idDestino = '" + idDestino + "' AND numeroNotificacion = 1", CommandType.Text, null);

            conexion.Cerrar();

            return tabla;

        }

        public DataTable MostrarNotificacion(int top, int id)
        {

            conexion.Abrir();



            DataTable tabla = conexion.EjecutarConsultaSelect("SELECT top ("+top+") idTransferencia, nombre1, nombre2, apellidoPaterno, apellidoMaterno, fechaMovimiento, montoRecibido, totalTransEnviada, mensaje, id_Origen FROM transferenciasRecibidas inner join Usuario on transferenciasRecibidas.id_Origen = Usuario.idUsuario where id_Destino = '" + id + "' ORDER BY fechaMovimiento DESC;", CommandType.Text, null);

            conexion.Cerrar();

            return tabla;

        }

        public DataTable MostrarNotificacion(int id)
        {

            conexion.Abrir();



            DataTable tabla = conexion.EjecutarConsultaSelect("SELECT top (5) idTransferencia, nombre1, nombre2, apellidoPaterno, apellidoMaterno, fechaMovimiento, montoRecibido, totalTransEnviada, mensaje, id_Origen FROM transferenciasRecibidas inner join Usuario on transferenciasRecibidas.id_Origen = Usuario.idUsuario where id_Destino = '" + id + "' ORDER BY fechaMovimiento DESC;", CommandType.Text, null);

            conexion.Cerrar();

            return tabla;

        }



        public void SetNumeroNotificaciones(int idDestino, int idOrigen)
        {
            conexion.Abrir();
            conexion.EjecutarConsultaSelect("INSERT INTO notificaciones VALUES (1, '" + idDestino + "', '" + idOrigen + "') ", CommandType.Text, null);
            conexion.Cerrar();

        }

        public void ActualizarNotificacion(int idOrigen)
        {
            conexion.Abrir();
            conexion.EjecutarConsultaSelect("UPDATE notificaciones SET numeroNotificacion =(0) WHERE idDestino = '" + idOrigen + "'", CommandType.Text, null);
            conexion.Cerrar();
        }
        //public void SetNotificacionCero(int idDestino)
        //{
        //    conexion.Abrir();

        //    conexion.EjecutarConsultaSelect("INSERT INTO notificaciones VALUES (0, '"+idDestino+"') WHERE idDestino= '" + idDestino + "'", CommandType.Text, null);
        //    conexion.Cerrar();

        //}


        public void RetirarDinero(int valor, string user, string pass)
        {
            conexion.Abrir();
            conexion.EjecutarConsultaSelect("UPDATE Usuario SET saldo =(saldo -'" + valor + "') WHERE nombre1 = '" + user + "' AND clave = '" + pass + "'", CommandType.Text, null);
            conexion.Cerrar();
        }

        public void DepositarDinero(int valor, string user, string pass)
        {
            conexion.Abrir();
            conexion.EjecutarConsultaSelect("UPDATE Usuario SET saldo =(saldo +'" + valor + "') WHERE nombre1 = '" + user + "' AND clave = '" + pass + "'", CommandType.Text, null);
            conexion.Cerrar();
        }


        public void DescontarSaldoTransferenciasEnviadas(int valor, int idOrigen)
        {
            conexion.Abrir();
            conexion.EjecutarConsultaSelect("UPDATE Usuario SET saldo =(saldo -'" + valor + "') WHERE idUsuario = '" + idOrigen + "' ", CommandType.Text, null);
            conexion.Cerrar();
        }

        public void SumarSaldoTransferenciasRecibidas(int valor, int idDestino)
        {
            conexion.Abrir();
            conexion.EjecutarConsultaSelect("UPDATE Usuario SET saldo =(saldo +'" + valor + "') WHERE idUsuario = '" + idDestino + "' ", CommandType.Text, null);
            conexion.Cerrar();
        }





        public void RegistrarUsuario(string nombre1, string nombre2, string apellido1, string apellido2, int saldo, string clave, string correo, string direccion, string telefono, int comuna, int region)
        {
            conexion.Abrir();
            conexion.EjecutarConsultaSelect("INSERT INTO Usuario VALUES ('" + nombre1 + "', '" + nombre2 + "', '" + apellido1 + "', '" + apellido2 + "', '" + saldo + "', '" + clave + "', '" + correo + "','" + direccion + "', '" + telefono + "', '" + comuna + "', '" + region + "') ", CommandType.Text, null);
            conexion.Cerrar();

        }

        public void LogMovimientosDeposito(int monto, int total, int id)
        {
            conexion.Abrir();
            conexion.EjecutarConsultaSelect("INSERT INTO movimientosDeposito VALUES ('" + monto + "', GETDATE(), '" + total + "', '" + id + "') ", CommandType.Text, null);
            conexion.Cerrar();
        }


        public void LogMovimientosRetiro(int monto, int total, int id)
        {
            conexion.Abrir();
            conexion.EjecutarConsultaSelect("INSERT INTO movimientosRetiro VALUES ('" + monto + "', GETDATE(), '" + total + "', '" + id + "') ", CommandType.Text, null);
            conexion.Cerrar();
        }

        public void MensajeSoporte(string asunto, string mensaje, int id)
        {
            conexion.Abrir();
            conexion.EjecutarConsultaSelect("INSERT INTO soporte VALUES ('" + asunto + "', '" + mensaje + "', '" + id + "');", CommandType.Text, null);
            conexion.Cerrar();
        }

        public DataTable GetNombreCompletoYSaldo(int id)
        {

            conexion.Abrir();


            DataTable tabla = conexion.EjecutarConsultaSelect("SELECT nombre1, nombre2, apellidoPaterno, apellidoMaterno, saldo FROM Usuario WHERE idUsuario = '" + id + "'", CommandType.Text, null);

            conexion.Cerrar();

            return tabla;

        }



        public DataTable HistorialDeposito(string user, string pass)
        {
            conexion.Abrir();


            DataTable tabla = conexion.EjecutarConsultaSelect("SELECT top 4 FORMAT (montoDeposito, 'c', 'es-CL') AS 'Monto deposito', FORMAT ( totalMontoDeposito,'c', 'es-CL') AS 'Saldo final', fechaDeposito AS 'Fecha deposito' FROM movimientosDeposito INNER JOIN Usuario ON movimientosDeposito.id_Usuario = Usuario.idUsuario WHERE nombre1 = '" + user + "' AND clave = '" + pass + "'ORDER BY fechaDeposito DESC", CommandType.Text, null);

            conexion.Cerrar();

            return tabla;


        }


        public DataTable HistorialRetiro(string user, string pass)
        {
            conexion.Abrir();


            DataTable tabla = conexion.EjecutarConsultaSelect("SELECT TOP 4 FORMAT (montoRetiro, 'c', 'es-CL') AS 'Monto retiro', FORMAT (totalMontoRetiro, 'c', 'es-CL') AS 'Saldo final', fechaMovimiento AS 'Fecha deposito' FROM movimientosRetiro INNER JOIN Usuario ON movimientosRetiro.id_Usuario = Usuario.idUsuario  WHERE nombre1 = '" + user + "' AND clave = '" + pass + "' ORDER BY fechaMovimiento DESC", CommandType.Text, null);

            conexion.Cerrar();

            return tabla;


        }

        public DataTable Cartola(int id)
        {
            conexion.Abrir();


            DataTable tabla = conexion.EjecutarConsultaSelect("SELECT concat('+   ',format (montoDeposito, 'c', 'es-CL')) AS 'Movimiento', format(totalMontoDeposito, 'c', 'es-CL') AS 'Saldo Final', fechaDeposito AS 'Fecha de movimiento' FROM movimientosDeposito where id_Usuario = '" + id + "' UNION SELECT concat('-   ',format(montoRetiro, 'c', 'es-CL')), format(totalMontoRetiro, 'c', 'es-CL'), fechaMovimiento FROM movimientosRetiro  where id_Usuario = '" + id + "' order by fechaDeposito desc", CommandType.Text, null);

            conexion.Cerrar();

            return tabla;
        }


        public DataTable BuscarNombreCuenta(string nombre1, string apellido1)
        {
            conexion.Abrir();


            DataTable tabla = conexion.EjecutarConsultaSelect("SELECT idUsuario , nombre1 , nombre2, apellidoPaterno,apellidoMaterno, correo FROM Usuario WHERE nombre1 like '%" + nombre1 + "%' AND apellidoPaterno  like '%" + apellido1 + "%'", CommandType.Text, null);

            conexion.Cerrar();

            return tabla;

        }

        public DataTable BuscarNombreCuenta(int id)
        {
            conexion.Abrir();


            DataTable tabla = conexion.EjecutarConsultaSelect("SELECT idUsuario, nombre1, nombre2, apellidoPaterno,apellidoMaterno, correo FROM Usuario WHERE idUsuario = '" + id + "'", CommandType.Text, null);

            conexion.Cerrar();

            return tabla;

        }

        public void LogTransferenciasEnviadas(int montoIngresado, int saldoFinal, string mensaje, int idOrigen, int idDestino)
        {
            conexion.Abrir();
            conexion.EjecutarConsultaSelect("INSERT INTO transferenciasEnviadas VALUES('" + montoIngresado + "', '" + saldoFinal + "', '" + mensaje + "', GETDATE(), '" + idOrigen + "', '" + idDestino + "') ", CommandType.Text, null);
            conexion.Cerrar();

        }

        public void LogTransferenciasRecibidas(int montoIngresado, int saldoFinal, string mensaje, int idOrigen, int idDestino)
        {
            conexion.Abrir();
            conexion.EjecutarConsultaSelect("INSERT INTO transferenciasRecibidas VALUES('" + montoIngresado + "', '" + saldoFinal + "', '" + mensaje + "', GETDATE(), '" + idOrigen + "','" + idDestino + "') ", CommandType.Text, null);
            conexion.Cerrar();

        }

        //public int GetSaldoSuficiente(string user, string pass)
        //{
        //    conexion.Abrir();
        //    int valor = Convert.ToInt32(conexion.EjecutarConsultaSelect("SELECT saldo FROM usuario WHERE nombre1 = '" + user + " AND clave = '" + pass + "' ", CommandType.Text));
        //    return valor;
        //}

        //public void Registrar(string nombre1, string nombre2, string apellido1, string apellido2, int saldo, string clave,  string correo, )
        //{
        //    conexion.Abrir();
        //    conexion.EjecutarConsultaSelect("UPDATE Usuario SET saldo =(saldo -'" + valor + "') WHERE nombre1 = '" + user + "' AND clave = '" + pass + "'", CommandType.Text, null);
        //    conexion.Cerrar();
        //}
    }
}
