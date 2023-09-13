using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using CapaNegocio;

namespace SistemaBancario
{
    public partial class Depositar : Form
    {
        private Consulta_CN a;
        private int valor;
        int id;
        int monto, idDestino;
        int total;

        public string getUser, getPass;

        public Depositar(string getUser1, string getPass1)
        {
            InitializeComponent();
            a = new Consulta_CN();
            getUser = getUser1;
            getPass = getPass1;
            this.dataGridView3.DataSource = a.HistorialDeposito_CN(getUser, getPass);
            //this.dataGridView3.Columns[0].Visible = true;
            this.dataGridView1.DataSource = a.GetSaldoInvisible_CN(getUser, getPass);



        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            Main irMain = new Main(getUser, getPass,idDestino);
            this.Hide();
            irMain.ShowDialog();
            this.Close();
            //OcultarPagoRecibido();
        }

        private void btnDepositar_Click(object sender, EventArgs e)
        {

            //OcultarPagoRecibido();
        }

        private void btnRetirar_Click(object sender, EventArgs e)
        {
            Retirar irRetirar = new Retirar(getUser, getPass);
            this.Hide();
            irRetirar.ShowDialog();
            this.Close();
            //OcultarPagoRecibido();

        }

        private void btnSaldo_Click(object sender, EventArgs e)
        {
            Saldo irSaldo = new Saldo(getUser, getPass);
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

        private void Depositar_Load(object sender, EventArgs e)
        {
            //OcultarPagoRecibido();
            //OcultarElementosDeposito();
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

        private void btnRetirar_MouseHover(object sender, EventArgs e)
        {
            btnRetirar.ForeColor = Color.DeepSkyBlue;
        }

        private void btnRetirar_MouseLeave(object sender, EventArgs e)
        {
            btnRetirar.ForeColor = Color.Snow;
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



        private void dataGridView3_MouseLeave(object sender, EventArgs e)
        {

        }

        private void txtDepositar_Click(object sender, EventArgs e)
        {
            //OcultarPagoRecibido();
        }

        private void label9_MouseHover(object sender, EventArgs e)
        {
            label9.ForeColor = Color.DeepSkyBlue;
        }

        private void label9_MouseLeave(object sender, EventArgs e)
        {
            label9.ForeColor = Color.Snow;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            Terceros1 transferir = new Terceros1(id, getUser, getPass);
            transferir.ShowDialog();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {

            if (txtDepositar.Text=="0")
            {
                MessageBox.Show("Debe ingresar un valor distinto de cero");
            }
            else
            {
                try
                {

                    valor = Convert.ToInt32(txtDepositar.Text);

                    a.DepositarDinero_CN(valor, getUser, getPass);

                    //this.dataGridView1.DataSource = a.GetSaldoInvisible_CN(getUser, getPass);
                    monto = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value.ToString());

                    id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    Saldo idCart = new Saldo(getUser,getPass);

                    total = Convert.ToInt32(valor + monto);

                    //MessageBox.Show(total.ToString());

                    a.LogRegistroDeposito_CN(valor, total, id);

                    this.dataGridView3.DataSource = a.HistorialDeposito_CN(getUser, getPass);
                    MensajeAceptado mensaje = new MensajeAceptado();
                    mensaje.ShowDialog();
                    //MostrarPagoRecibido();
                    valor = 0;

                }
                catch
                {
                    MessageBox.Show("Debe ingresar una cifra");
                }
            }

            



            txtDepositar.Text = "";
            this.dataGridView1.DataSource = a.GetSaldoInvisible_CN(getUser, getPass);

        }

        //public void OcultarElementosDeposito()
        //{
        //    txtDepositar.Hide();
        //    labelIngreseMonto.Hide();

        //    btnIngresar.Hide();
            
        //}
    }
}
