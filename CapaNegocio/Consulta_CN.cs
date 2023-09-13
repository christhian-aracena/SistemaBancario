using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{

    public class Consulta_CN
    {
        private Consultas a = new Consultas();

        public DataTable GetNombre_CN(string nombre1, string clave)
        {
            return a.GetNombre(nombre1, clave);
        }
        public void RetirarDinero_CN(int valor, string user, string pass)
        {
            a.RetirarDinero(valor, user, pass);
        }

        public void DepositarDinero_CN(int valor, string user, string pass)
        {
            a.DepositarDinero(valor, user, pass);
        }
        public DataTable GetSaldo_CN(string nombre1, string clave)
        {
            return a.GetSaldo(nombre1, clave);
        }

        public DataTable GetSaldoInvisible_CN(string nombre1, string clave)
        {
            return a.GetSaldoInvisible(nombre1, clave);
        }
        public DataTable GetNotificacion_CN(int idDestino)
        {
            return a.GetNotificacion(idDestino);
        }

        public DataTable MostrarNotificacion_CN(int top, int id)
        {
            return a.MostrarNotificacion(top, id);
        }

        public DataTable MostrarNotificacion_CN(int id)
        {
            return a.MostrarNotificacion(id);
        }
        public void ActualizarNotificacion_CN(int idOrigen)
        {
            a.ActualizarNotificacion(idOrigen);
        }

        public void SetNumeroNotificaciones_CN(int idDestino, int idOrigen)
        {
            a.SetNumeroNotificaciones(idDestino, idOrigen);
        }

        public void RegistrarUsuario_CN(string nombre1, string nombre2, string apellido1, string apellido2, int saldo, string clave, string correo, string direccion, string telefono, int comuna, int region)
        {
            a.RegistrarUsuario(nombre1, nombre2, apellido1, apellido2, saldo, clave, correo, direccion, telefono, comuna, region);
        }

        public void LogRegistroDeposito_CN(int monto, int total, int id)
        {
            a.LogMovimientosDeposito(monto, total, id);
        }

        public void LogRegistroRetiro_CN(int monto, int total, int id)
        {
            a.LogMovimientosRetiro(monto, total, id);
        }

        public void MensajeSoporte_CN(string asunto, string mensaje, int id)
        {
            a.MensajeSoporte(asunto, mensaje, id);
        }
        public void LogTransferenciasEnviadas_CN(int montoIngresado, int saldoFinal, string mensaje, int idOrigen, int idDestino)
        {
            a.LogTransferenciasEnviadas(montoIngresado, saldoFinal, mensaje, idOrigen, idDestino);
        }

        public void LogTransferenciasRecibidas_CN(int montoIngresado, int saldoFinal, string mensaje, int idOrigen, int idDestino)
        {
            a.LogTransferenciasRecibidas(montoIngresado, saldoFinal, mensaje, idOrigen, idDestino);
        }

        public void DescontarSaldoTransferenciasEnviadas_CN(int valor, int idOrigen)
        {
            a.DescontarSaldoTransferenciasEnviadas(valor, idOrigen);
        }

        public void SumarSaldoTransferenciasRecibidas(int valor, int idDestino)
        {
            a.SumarSaldoTransferenciasRecibidas(valor, idDestino);
        }

        public DataTable HistorialDeposito_CN(string user, string pass)
        {
            return a.HistorialDeposito(user, pass);
        }

        public DataTable HistorialRetiro_CN(string user, string pass)
        {
            return a.HistorialRetiro(user, pass);
        }

        public DataTable Cartola(int id)
        {
            return a.Cartola(id);
        }

        public DataTable BuscarCuenta_CN(string nombre1, string apellido1)
        {
            return a.BuscarNombreCuenta(nombre1, apellido1);
        }
        public DataTable BuscarCuenta_CN(int id)
        {
            return a.BuscarNombreCuenta(id);
        }

        public DataTable GetNombreCompletoYSaldo_CN(int id)
        {
            return a.GetNombreCompletoYSaldo(id);
        }

        //public int getSaldoSuficiente_CN(string user, string pass)
        //{
        //    return a.GetSaldoSuficiente(user, pass);
        //}

    }
}
