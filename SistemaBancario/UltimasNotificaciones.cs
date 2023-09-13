using CapaNegocio;
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
    public partial class UltimasNotificaciones : Form
    {
        public int idDestino, notificaciones, numeroCuenta;
        public string nombre1, nombre2, apellido1,apellido2, fecha, nombreCompleto;





        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblFecha.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[5].Value.ToString().Substring(0, 10));
            lblHora.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[5].Value.ToString().Substring(11, 5));



            lblMontoATrasnferir.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[6].Value.ToString());
            lblMensaje.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[8].Value.ToString());

            lblSaldoFinal.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[7].Value.ToString());

            nombre1 = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value.ToString());
            nombre2 = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value.ToString());
            apellido1 = Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value.ToString());
            apellido2 = Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value.ToString());
            nombreCompleto = nombre1 +" "+ nombre2 + " " + apellido1 + " " + apellido2;
            lblNombreTitular.Text = nombreCompleto;
            lblNumeroCuenta.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[9].Value.ToString());


        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnUltimasNotificaciones_Click(object sender, EventArgs e)
        {
            btnUltimasNotificaciones.BackColor = Color.FromArgb(42, 55, 71);
            btnTodasNotificaciones.BackColor = Color.FromArgb(41, 118, 174);
            this.dataGridView1.DataSource = a.MostrarNotificacion_CN(idDestino);
            lblSinNotificacion.Visible = false;


        }

        private void btnTodasNotificaciones_Click(object sender, EventArgs e)
        {
            btnTodasNotificaciones.BackColor = Color.FromArgb(41, 55, 71);
            btnUltimasNotificaciones.BackColor = Color.FromArgb(41, 118, 174);

        }

        private void lblFecha_Click(object sender, EventArgs e)
        {

        }

        public Consulta_CN a;
        public UltimasNotificaciones(int notificaciones,int idDestino)
        {
            InitializeComponent();
            this.idDestino = idDestino;
            this.notificaciones = notificaciones;
            a = new Consulta_CN();
            //MessageBox.Show(notificaciones.ToString() + "\n" + idDestino);
            a.ActualizarNotificacion_CN(idDestino);

            this.dataGridView1.DataSource = a.MostrarNotificacion_CN(notificaciones, idDestino);





            if (notificaciones==0)
            {
                lblSinNotificacion.Visible = true;

            }
            else
            {
                lblSinNotificacion.Visible = false;
            }

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void UltimasNotificaciones_Load(object sender, EventArgs e)
        {


            lblNombreTitular.Text = "--";
            lblFecha.Text = "--";
            lblHora.Text = "--";
            lblMensaje.Text = "--";
            lblMontoATrasnferir.Text = "--";
            lblNumeroCuenta.Text = "--";
            lblSaldoFinal.Text = "--";
            lblMensaje.Text = "--";

            this.dataGridView1.Columns[2].Visible = false;
            this.dataGridView1.Columns[4].Visible = false;
            this.dataGridView1.Columns[5].Visible = false;
            this.dataGridView1.Columns[7].Visible = false;
            this.dataGridView1.Columns[8].Visible = false;
            this.dataGridView1.Columns[9].Visible = false;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
    }
}
