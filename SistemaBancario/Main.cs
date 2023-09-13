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
using System.Reflection.Emit;
using System.Threading;
using Timer = System.Windows.Forms.Timer;
using System.Xml.Linq;


namespace SistemaBancario
{
    public partial class Main : Form
    {
        private Consulta_CN a;
        public string getUser, getPass;
        public string contacta;
        public int id, notificaciones;

        public Main(string user, string password, int idDestino)
        {
            InitializeComponent();
            a = new Consulta_CN();

            this.dataGridView1.DataSource = a.GetNombre_CN(user,password);
            this.dataGridView2.DataSource = a.GetSaldoInvisible_CN(user,password);


            //notificaciones = idDestino;

            //int notificacion = Convert.ToInt32(dataGridView4.CurrentRow.Cells[1].Value.ToString());






            //int longitud = dataGridView3.Rows.Count;

            //MessageBox.Show(longitud.ToString());
            //MessageBox.Show(notificacion.ToString());

            getUser = user;
            getPass = password;

            this.dataGridView2.Columns[0].Visible = false;
            this.dataGridView2.Columns[1].Visible = false;
            this.dataGridView2.Columns[2].Visible = false;
            this.dataGridView2.Columns[3].Visible = false;
            //this.panel5.BackColor = Color.FromArgb(125, Color.Black);


        }

        private void Main_Load(object sender, EventArgs e)
        {
            OcultarMain();
            MostrarContacta();
            RecargarDatos();


        }

        public void RecargarDatos()
        {
            id = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString());
            //MessageBox.Show(id.ToString());
            this.dataGridView3.DataSource = a.GetNotificacion_CN(id);
            notificaciones = Convert.ToInt32(dataGridView3.Rows.Count);

            lblNotificacion.Text = Convert.ToString(notificaciones.ToString());


            MostrarNotificacion();
        }
        public void MostrarNotificacion()
        {
            if (notificaciones == 0)
            {

                lblNotificacion.Visible = false;
                sinNotificacion.Visible = true;


            }
            else
            {
                lblNotificacion.Visible = true;
            }
        }

        private void OcultarMain()
        {
            labelDeposito.Hide();
            labelTerceros.Hide();
            labelSaldo.Hide();
            labelCartola.Hide();
            labelPerfil.Hide();
            labelCuenta.Hide();
            cuadroDepos.Hide();
            cuadroTerceros.Hide();
            CuadroSaldo.Hide();
            cuadroCartola.Hide();
            cuadroPerfil.Hide();
            cuadroCuenta.Hide();
            linea1.Hide();
            linea2.Hide();
            linea3.Hide();
            linea4.Hide();
            linea5.Hide();
            linea6.Hide();
            seguridadInicio.Show();

            labelTerceros1.Hide();
            labelTerceros2.Hide();
            labelTerceros3.Hide();

            lblCartola1.Hide();
            lblCartola2.Hide();
            lblCartola3.Hide();

            lblCuenta1.Hide();
            lblCuenta2.Hide();
            lblCuenta3.Hide();

            lblPerfil1.Hide();
            lblPerfil2.Hide();
            lblPerfil3.Hide();

            lblSaldo1.Hide();
            lblSaldo2.Hide();
            lblSaldo3.Hide();

            lblDeposito1.Hide();
            lblDeposito2.Hide();
            lblDeposito3.Hide();
            


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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Login cerrarSesion = new Login();
            this.Hide();
            cerrarSesion.ShowDialog();
            this.Close();

        }

        private void label6_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnDepositar_Click(object sender, EventArgs e)
        {
            Depositar irDepositar = new Depositar(getUser, getPass);
            this.Hide();
            irDepositar.ShowDialog();
            this.Close();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {

        }

        private void btnRetirar_Click(object sender, EventArgs e)
        {

            Retirar irRetirar = new Retirar(getUser,getPass);
            this.Hide();
            irRetirar.ShowDialog();
            this.Close();
        }

        private void btnSaldo_Click(object sender, EventArgs e)
        {
            Saldo irSaldo = new Saldo(getUser, getPass);
            this.Hide();
            irSaldo.ShowDialog();
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.dataGridView3.DataSource = a.GetNotificacion_CN(id);
            notificaciones = Convert.ToInt32(dataGridView3.Rows.Count);
            MostrarNotificacion();

            lblNotificacion.Text = Convert.ToString(notificaciones.ToString());
            labelHora.Text = DateTime.Now.ToLongTimeString();
            labelFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnInicio_MouseDown(object sender, MouseEventArgs e)
        {

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

        private void btnSaldo_MouseHover(object sender, EventArgs e)
        {
            btnSaldo.ForeColor = Color.DeepSkyBlue;
            //cuadroDepos.Show();
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

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void btnrapDepositar_MouseHover(object sender, EventArgs e)
        {
            cuadroDepos.Show();
            labelDeposito.Show();
            linea1.Show();
            seguridadInicio.Hide();
            lblDeposito1.Show();
            lblDeposito2.Show();
            lblDeposito3.Show();
            OcultarContacta();
            lblAvisanosSi.Hide();


        }
        public void OcultarContacta()
        {
            labelcontacta1.Hide();
            labelcontacta2.Hide();
            labelcontacta3.Hide();
        }
        public void MostrarContacta()
        {
            labelcontacta1.Show();
            labelcontacta2.Show();
            labelcontacta3.Show();
        }



        private void btnrapDepositar_MouseLeave(object sender, EventArgs e)
        {
            OcultarMain();
            cuadroDepos.Hide();
            linea1.Hide();
            MostrarContacta();
            lblAvisanosSi.Show();

        }

        private void btnrapTerceros_MouseHover(object sender, EventArgs e)
        {
            cuadroTerceros.Show(); ;
            labelTerceros.Show();
            linea2.Show();
            seguridadInicio.Hide();
            labelTerceros1.Show();
            labelTerceros2.Show();
            labelTerceros3.Show();
            OcultarContacta();
            lblAvisanosSi.Hide();
        }

        private void btnrapTerceros_MouseLeave(object sender, EventArgs e)
        {
            OcultarMain();
            linea2.Hide();
            MostrarContacta();
            lblAvisanosSi.Show();
        }

        private void btnrapSaldo_MouseHover(object sender, EventArgs e)
        {
            CuadroSaldo.Show();
            labelSaldo.Show();
            linea3.Show();
            seguridadInicio.Hide();
            lblSaldo1.Show();
            lblSaldo2.Show();
            lblSaldo3.Show();
            OcultarContacta();
            lblAvisanosSi.Hide();
        }

        private void btnrapSaldo_MouseLeave(object sender, EventArgs e)
        {
            OcultarMain();
            linea3.Hide();
            MostrarContacta();
            lblAvisanosSi.Show();
        }

        private void cuadroCartola_MouseHover(object sender, EventArgs e)
        {
            cuadroCartola.Show();
            labelCartola.Show();
            linea4.Show();
            seguridadInicio.Hide();
            lblCartola1.Show();
            lblCartola2.Show();
            lblCartola3.Show();
            OcultarContacta();
            lblAvisanosSi.Hide();
        }

        private void cuadroCartola_MouseLeave(object sender, EventArgs e)
        {
            OcultarMain();
            linea4.Hide();
            MostrarContacta();
            lblAvisanosSi.Show();
        }

        private void btnrapPerfil_MouseHover(object sender, EventArgs e)
        {
            cuadroPerfil.Show();
            labelPerfil.Show();
            linea5.Show();
            seguridadInicio.Hide();
            lblPerfil1.Show();
            lblPerfil2.Show();
            lblPerfil3.Show();
            OcultarContacta();
            lblAvisanosSi.Hide();
        }

        private void btnrapPerfil_MouseLeave(object sender, EventArgs e)
        {
            OcultarMain();
            linea5.Hide();
            MostrarContacta();
            lblAvisanosSi.Show();
        }

        private void btnrapCuenta_MouseHover(object sender, EventArgs e)
        {
            cuadroCuenta.Show();
            labelCuenta.Show();
            linea6.Show();
            seguridadInicio.Hide();
            lblCuenta1.Show();
            lblCuenta2.Show();
            lblCuenta3.Show();
            OcultarContacta();
            lblAvisanosSi.Hide();
        }

        private void btnrapCuenta_MouseLeave(object sender, EventArgs e)
        {
            OcultarMain();
        }

        private void btnrapCuenta_MouseLeave_1(object sender, EventArgs e)
        {
            OcultarMain();
            linea6.Hide();
            MostrarContacta();
            lblAvisanosSi.Show();
        }

        private void label3_MouseHover(object sender, EventArgs e)
        {
            labelcontacta2.ForeColor = Color.DeepSkyBlue;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            labelcontacta1.ForeColor = Color.Snow;
        }

        private void labelcontacta1_MouseHover(object sender, EventArgs e)
        {
            labelcontacta1.ForeColor = Color.DeepSkyBlue;
        }

        private void labelcontacta2_MouseHover(object sender, EventArgs e)
        {
            labelcontacta2.ForeColor = Color.DeepSkyBlue;
        }

        private void labelcontacta3_MouseHover(object sender, EventArgs e)
        {
            labelcontacta3.ForeColor = Color.DeepSkyBlue;
        }

        private void labelcontacta1_MouseLeave(object sender, EventArgs e)
        {
            labelcontacta1.ForeColor = Color.Snow;

        }

        private void labelcontacta2_MouseLeave(object sender, EventArgs e)
        {
            labelcontacta2.ForeColor = Color.Snow;
        }

        private void labelcontacta3_MouseLeave(object sender, EventArgs e)
        {
            labelcontacta3.ForeColor = Color.Snow;
        }

        private void labelcontacta1_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString());
            contacta = labelcontacta1.Text;
            Soporte soporte1 = new Soporte(contacta, id);
            soporte1.ShowDialog();

        }

        private void btnrapCartola_Click(object sender, EventArgs e)
        {
            Cartola abrir = new Cartola(getUser,getPass);
            abrir.ShowDialog();

        }

        private void btnrapDepositar_Click(object sender, EventArgs e)
        {
            Depositar irDepositar = new Depositar(getUser,getPass);
            this.Hide();
            irDepositar.ShowDialog();
            this.Close();
        }

        private void labelcontacta2_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString());
            contacta = labelcontacta2.Text;
            Soporte soporte2 = new Soporte(contacta,id);
            soporte2.ShowDialog();

        }

        private void labelcontacta3_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString());
            contacta = labelcontacta3.Text;
            Soporte soporte3 = new Soporte(contacta, id);
            soporte3.ShowDialog();
        }

        private void btnrapSaldo_Click(object sender, EventArgs e)
        {
            Saldo irSaldo = new Saldo(getUser,getPass);
            this.Hide();
            irSaldo.ShowDialog();
            this.Close();
        }




        private void sinNotificacion_Click(object sender, EventArgs e)
        {
            UltimasNotificaciones notificacion = new UltimasNotificaciones(notificaciones, id);

            RecargarDatos();

            notificacion.Show();


        }



        private void btnrapTerceros_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString());
            Terceros1 nuevatransferencia = new Terceros1(id, getUser, getPass);
            nuevatransferencia.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
