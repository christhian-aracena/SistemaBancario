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

namespace SistemaBancario
{
    public partial class Saldo : Form
    {
        private Consulta_CN b;
        public int saldo, idDestino;
        public int saldoconvert;


        public string getUser, getPass;

        public Saldo(string getNombre1, string getPass1)
        {
            InitializeComponent();
            b = new Consulta_CN();
            this.dataGridView1.DataSource = b.GetNombre_CN(getNombre1, getPass1);
            this.dataGridView2.DataSource = b.GetSaldo_CN(getNombre1,getPass1);

            getUser = getNombre1;
            getPass = getPass1;

        }

        private void btnDepositar_Click(object sender, EventArgs e)
        {
            Depositar irDepos = new Depositar(getUser, getPass);
            this.Hide();
            irDepos.ShowDialog();
            this.Close();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            Main irMain = new Main(getUser, getPass, idDestino);
            this.Hide();
            irMain.ShowDialog();
            this.Close();
        }

        private void btnSaldo_Click(object sender, EventArgs e)
        {

        }

        private void btnRetirar_Click(object sender, EventArgs e)
        {
            Retirar irRetir = new Retirar(getUser,getPass);
            this.Hide();
            irRetir.ShowDialog();
            this.Close();

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Login cerrarSesion = new Login();
            this.Hide();
            cerrarSesion.ShowDialog();
            this.Close();
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

        private void Saldo_Load(object sender, EventArgs e)
        {

            Retirar limite = new Retirar(getUser, getPass);
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

        private void btnRetirar_MouseHover(object sender, EventArgs e)
        {
            btnRetirar.ForeColor = Color.DeepSkyBlue;
        }

        private void btnRetirar_MouseLeave(object sender, EventArgs e)
        {
            btnRetirar.ForeColor = Color.Snow;
        }

        private void btnSalir_MouseHover(object sender, EventArgs e)
        {
            btnSalir.ForeColor = Color.DeepSkyBlue;
        }

        private void btnSalir_MouseLeave(object sender, EventArgs e)
        {
            btnSalir.ForeColor = Color.Snow;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {

            Cartola cartola = new Cartola(getUser,getPass);
            cartola.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelHora.Text = DateTime.Now.ToLongTimeString();
            labelFecha.Text = DateTime.Now.ToLongDateString();
        }
    }
}
