using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaBancario
{
    public partial class Tercero2 : Form
    {
        public int montoTransferencia;
        public string mensaje;
        public int idOrigen, idDestino;
        public string user, pass;
        public Tercero2(int idOrigen, int idDestino, string user, string pass)
        {
            InitializeComponent();
            this.idOrigen = idOrigen;
            this.idDestino = idDestino;
            this.user = user;
            this.pass = pass;
            //MessageBox.Show(idOrigen.ToString()+"\n"+idDestino.ToString());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Tercero2_Load(object sender, EventArgs e)
        {

        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Terceros1 volver = new Terceros1(idOrigen, user, pass);
            this.Hide();
            volver.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTransferir.Text == "")
                {
                    MessageBox.Show("Debe ingresar un monto");
                }
                else
                {
                    montoTransferencia = Convert.ToInt32(txtTransferir.Text);

                    mensaje = txtMensaje.Text;

                    Terceros3 terminar = new Terceros3(idOrigen, idDestino, user, pass, montoTransferencia, mensaje);
                    this.Hide();
                    terminar.ShowDialog();
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Debe ingresar un monto");
            }



        }
    }
}
