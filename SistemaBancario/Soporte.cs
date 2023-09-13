using CapaNegocio;
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

namespace SistemaBancario
{
    public partial class Soporte : Form
    {
        public string contacta;
        public int id;
        public string asunto, descripcion;
        Consulta_CN a;
        public Soporte(string contact, int id)
        {
            InitializeComponent();
            contacta = contact;
            contacta = contacta.ToLower();
            labelMensaje.Text = contacta;
            this.id = id;

            a = new Consulta_CN();
        }

        private void Soporte_Load(object sender, EventArgs e)
        {

        }
        public void Limpiar()
        {
            txtAsunto.Text = "";
            txtDescripcion.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_MouseDown_1(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (txtAsunto.Text != "" && txtDescripcion.Text != "")
            {
                asunto = txtAsunto.Text;
                descripcion = txtDescripcion.Text;
                a.MensajeSoporte_CN(asunto, descripcion, id);
                MessageBox.Show("Tu mensaje se envio a soporte. Gracias");
                this.Close();
            }
            else
            {
                MessageBox.Show("Debe ingresar asunto y descripcion.");
            }

        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
    }
}
