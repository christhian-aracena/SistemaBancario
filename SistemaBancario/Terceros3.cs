using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaBancario
{
    
    public partial class Terceros3 : Form
    {
        Consulta_CN a;
        public int idOrigen, idDestino, montoTransferencia, total, montoNormal, totalDestino;
        public string user, pass, mensaje;
        public Terceros3(int idOrigen, int idDestino, string user, string pass, int montoTransferencia, string mensaje)
        {
            InitializeComponent();
            this.idOrigen = idOrigen;
            this.idDestino = idDestino;
            this.user = user;
            this.pass = pass;
            this.montoTransferencia = montoTransferencia;
            this.mensaje = mensaje;
            a = new Consulta_CN();
            this.dataGridView3.DataSource = a.GetNombreCompletoYSaldo_CN(idOrigen);
            this.dataGridView1.DataSource = a.GetNombreCompletoYSaldo_CN(idDestino);
            



            //this.dataGridView2.DataSource = a.GetNotificacion_CN(idDestino);
            //notificacionActual = Convert.ToInt32(this.dataGridView2.RowCount);
            //MessageBox.Show(notificacionActual.ToString());
            this.dataGridView1.Columns[4].Visible = false;
            this.dataGridView3.Columns[4].Visible = false;
            //MessageBox.Show(lblMontoATrasnferir.Text.ToString());
            //MessageBox.Show();

            //UltimasNotificaciones pasardatos = new UltimasNotificaciones();


            Main pasarDatos = new Main(user,pass,idDestino);


        }

        private void Terceros3_Load(object sender, EventArgs e)
        {
            total = Convert.ToInt32(dataGridView3.CurrentRow.Cells[4].Value.ToString());
            totalDestino = Convert.ToInt32(dataGridView1.CurrentRow.Cells[4].Value.ToString());

            montoNormal = Convert.ToInt32(montoTransferencia);

            lblIdCuentaOrigen.Text = idOrigen.ToString();
            lblIdCuentaDestino.Text = idDestino.ToString();
            lblMontoATrasnferir.Text = montoTransferencia.ToString("C",new CultureInfo("es-CL"));
            lblMontoATrasnferir.Text.ToString();

            lblMensaje.Text = mensaje;

        }




        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            total = Convert.ToInt32(dataGridView3.CurrentRow.Cells[4].Value.ToString());
            if (total<montoNormal)
            {
                MessageBox.Show("No tienes saldo suficiente para transferir");
            }
            else
            {
                int resultadoOrigen = (total - montoNormal);
                int resultadoDestino = (totalDestino + montoNormal);



                a.SumarSaldoTransferenciasRecibidas(montoNormal, idDestino);
                a.DescontarSaldoTransferenciasEnviadas_CN(montoNormal, idOrigen);


                a.LogTransferenciasEnviadas_CN(montoTransferencia, resultadoOrigen, mensaje, idOrigen, idDestino);
                a.LogTransferenciasRecibidas_CN(montoTransferencia, resultadoDestino, mensaje, idOrigen, idDestino);

                a.SetNumeroNotificaciones_CN(idDestino,idOrigen);




                MensajeAceptado aceptado = new MensajeAceptado();
                aceptado.ShowDialog();
                this.Close();

            }
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Tercero2 volver2 = new Tercero2(idOrigen,idDestino,user, pass);
            this.Hide();
            volver2.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }




        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


    }
}
