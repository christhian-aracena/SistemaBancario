using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using CapaNegocio;
using System.Threading;

namespace SistemaBancario
{
    public partial class Retirar : Form
    {
        private Consulta_CN a;
        private int valor;
        private int saldoRecibido;
        private string getUsuario, getPass;
        private int saldo;
        private int id;
        private int total;
        int idDestino;
        public Retirar(string user, string pass)
        {
            InitializeComponent();
            a = new Consulta_CN();
            getUsuario = user;
            getPass = pass;
            this.dataGridView3.DataSource = a.GetSaldoInvisible_CN(getUsuario, getPass);
            this.dataGridView1.DataSource = a.HistorialRetiro_CN(getUsuario, getPass);

        }

        private void btnInicio_Click(object sender, EventArgs e)
        {

            Main irMain = new Main(getUsuario, getPass, idDestino);
            this.Hide();
            irMain.ShowDialog();
            this.Close();
            //OcultarPagoRecibido();
        }

        private void btnDepositar_Click(object sender, EventArgs e)
        {
            Depositar irDepos = new Depositar(getUsuario, getPass);
            this.Hide();
            irDepos.ShowDialog();
            this.Close();
            //OcultarPagoRecibido();
        }

        private void btnRetirar_Click(object sender, EventArgs e)
        {

            //OcultarPagoRecibido();
        }

        private void btnSaldo_Click(object sender, EventArgs e)
        {
            Saldo irSaldo = new Saldo(getUsuario, getPass);
            this.Hide();
            irSaldo.ShowDialog();
            this.Close();
            //OcultarPagoRecibido();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Login cerrarSesion = new Login();
            this.Hide();
            cerrarSesion.ShowDialog();
            this.Close();
            //OcultarPagoRecibido();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void label6_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Retirar_Load(object sender, EventArgs e)
        {
            //OcultarPagoRecibido();
            this.dataGridView3.DataSource = a.GetSaldoInvisible_CN(getUsuario, getPass);
            this.dataGridView1.DataSource = a.HistorialRetiro_CN(getUsuario, getPass);
        }

        //private void OcultarPagoRecibido()
        //{
        //    labelDepositoAceptado.Visible = false;
        //    labelRecibidoporBanco.Visible = false;
        //    labelAccepted.Visible = false;
        //}

        //private void MostrarPagoRecibido()
        //{
        //    labelDepositoAceptado.Visible = true;
        //    labelRecibidoporBanco.Visible = true;
        //    labelAccepted.Visible = true;
        //}

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelHora.Text = DateTime.Now.ToLongTimeString();
            labelFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void btnInicio_MouseHover(object sender, EventArgs e)
        {
            btnInicio.ForeColor = Color.DeepSkyBlue;
        }

        private void btnInicio_MouseLeave(object sender, EventArgs e)
        {
            btnInicio.ForeColor = Color.Snow;
        }

        private void btnDepositar_MouseHover(object sender, EventArgs e)
        {
            btnDepositar.ForeColor = Color.DeepSkyBlue;
        }

        private void btnDepositar_MouseLeave(object sender, EventArgs e)
        {
            btnDepositar.ForeColor = Color.Snow;
        }

        private void btnSaldo_MouseHover(object sender, EventArgs e)
        {
            btnSaldo.ForeColor = Color.DeepSkyBlue;
        }

        private void btnSaldo_MouseLeave(object sender, EventArgs e)
        {
            btnSaldo.ForeColor = Color.Snow;
        }

        private void btnSalir_MouseHover(object sender, EventArgs e)
        {
            btnSalir.ForeColor = Color.DeepSkyBlue;
        }

        private void btnSalir_MouseLeave(object sender, EventArgs e)
        {
            btnSalir.ForeColor = Color.Snow;
        }

        private void txtRetirarSaldo_Click(object sender, EventArgs e)
        {
            //OcultarPagoRecibido();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                valor = Convert.ToInt32(txtRetirarSaldo.Text.ToString());
                a.RetirarDinero_CN(valor, getUsuario, getPass);
                //LAS SIGUIENTES DOS LINEAS ENTREGAN EL VALOR DE ID Y SALDO DEL USUARIO ACTUAL DESDE UNA TABLA INSERTADA EN EL FORM PERO OCULTA AL USUARIO
                id = Convert.ToInt32(dataGridView3.CurrentRow.Cells[0].Value.ToString());
                saldo = Convert.ToInt32(dataGridView3.CurrentRow.Cells[1].Value.ToString());

                if (valor==0)
                {
                    MessageBox.Show("Debe ingresar un valor distinto de 0");
                    //OcultarPagoRecibido();
                }
                else
                {
                    if (saldo >= valor)
                    {
                        total = Convert.ToInt32(saldo - valor);
                        saldo = Convert.ToInt32(dataGridView3.CurrentRow.Cells[1].Value.ToString());
                        a.LogRegistroRetiro_CN(valor, total, id);
                        //valor = 0;
                        this.dataGridView1.DataSource = a.HistorialRetiro_CN(getUsuario, getPass);
                        MensajeAceptado mensaje = new MensajeAceptado();
                        mensaje.ShowDialog();
                        //MostrarPagoRecibido();
                    }
                    else
                    {
                        MessageBox.Show("Saldo insuficiente. Por favor deposite");
                        //OcultarPagoRecibido();
                    }
                    //ESTA LINEA ACTUALIZA LOS VALORES DE LA TABLA PARA OBTENER EL SALDO ACTUAL AL REALIZAR UNA NUEVA OPERACION
                    this.dataGridView3.DataSource = a.GetSaldoInvisible_CN(getUsuario, getPass);
                }
            }
            catch
            {
                MessageBox.Show("Debe ingresar una cifra");
            }
            txtRetirarSaldo.Text = "";
        }
    }
}
