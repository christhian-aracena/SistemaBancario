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
using System.Data.SqlClient;
using CapaNegocio;
using System.Globalization;

namespace SistemaBancario
{
    public partial class Registro : Form
    {

        SqlCommand cmd;
        public DataTable dt;
        SqlDataAdapter da;
        private Consulta_CN a;
        SqlConnection conexion = new SqlConnection(@"Data Source=DESKTOP-DP04AGL\SQLEXPRESS;Initial Catalog=SistemaBancario;INTEGRATED SECURITY= TRUE");
        public Registro()
        {
            InitializeComponent();
            LimpiarRegistros();
            CargarRegion();
            CargarComuna();

        }


        private void Registro_Load(object sender, EventArgs e)
        {
            LimpiarRegistros();
            a = new Consulta_CN();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void label6_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtnombre1Registro.Text != "" && txtnombre2Registro.Text != "" && txtApellido1Registro.Text != "" && txtApellido2Registro.Text != "" && txtCorreoRegistro.Text != "" && txtContraniaRegistro.Text != "" && txtDireccionRegistro.Text != "" && txtTelefono.Text != "" && CBRegionRegistro.Text != "Seleccione Región" && CBComunaRegistro.Text != "Seleccione Comuna")
            {
                string nombre1, nombre2, apellido1, apellido2, clave, correo, direccion, telefono;
                int comuna, region, SaldoInicial;

                nombre1 = txtnombre1Registro.Text;
                nombre1.ToString().ToLower();
                nombre1 = (CultureInfo.InvariantCulture.TextInfo.ToTitleCase(nombre1));
                nombre2 = txtnombre2Registro.Text;
                nombre2.ToString().ToLower();
                nombre2 = (CultureInfo.InvariantCulture.TextInfo.ToTitleCase(nombre2));
                apellido1 = txtApellido1Registro.Text;
                apellido1.ToString().ToLower();
                apellido1 = (CultureInfo.InvariantCulture.TextInfo.ToTitleCase(apellido1));
                apellido2 = txtApellido2Registro.Text;
                apellido2.ToString().ToLower();
                apellido2 = (CultureInfo.InvariantCulture.TextInfo.ToTitleCase(apellido2));
                clave = txtContraniaRegistro.Text;
                correo = txtCorreoRegistro.Text;
                direccion = txtDireccionRegistro.Text;
                telefono = txtTelefono.Text;
                comuna = Convert.ToInt32(CBComunaRegistro.SelectedValue);
                region = Convert.ToInt32(CBRegionRegistro.SelectedValue);

                try
                {
                    SaldoInicial = Convert.ToInt32(txtSaldoInicialRegistro.Text);
                    a.RegistrarUsuario_CN(nombre1, nombre2, apellido1, apellido2, SaldoInicial, clave, correo, direccion, telefono, comuna, region);
                    MessageBox.Show("Felicitaciones, tu cuenta ha sido creada con exito.\nYa puedes iniciar sesion con tu  primer nombre y contraseña");
                    this.Close();

                }
                catch
                {
                    MessageBox.Show("Debe ingresar el saldo en formato numeros");
                }


            }
            else
            {
                MessageBox.Show("Debe completar todos los campos");
            }


        }

        private void btnLimpiarRegistro_Click(object sender, EventArgs e)
        {
            LimpiarRegistros();
        }
        private void LimpiarRegistros()
        {
            txtnombre1Registro.Text = "";
            txtnombre2Registro.Text = "";
            txtApellido1Registro.Text = "";
            txtApellido2Registro.Text = "";
            txtCorreoRegistro.Text = "";
            txtContraniaRegistro.Text = "";
            txtDireccionRegistro.Text = "";
            txtTelefono.Text = "";
            txtSaldoInicialRegistro.Text = "";
            CBRegionRegistro.Text = "Seleccione Región";
            CBComunaRegistro.Text = "Seleccione Comuna";

        }

        public void CargarRegion()
        {
            conexion.Open();

            cmd = new SqlCommand("SELECT idRegion, nombreRegion FROM region", conexion);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            conexion.Close();

            CBRegionRegistro.ValueMember = "idRegion";
            CBRegionRegistro.DisplayMember = "nombreRegion";
            CBRegionRegistro.DataSource = dt;

        }

        public void CargarComuna()
        {
            conexion.Open();

            cmd = new SqlCommand("SELECT idComuna, nombreComuna FROM Comuna", conexion);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            conexion.Close();

            CBComunaRegistro.ValueMember = "idComuna";
            CBComunaRegistro.DisplayMember = "nombreComuna";
            CBComunaRegistro.DataSource = dt;

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
