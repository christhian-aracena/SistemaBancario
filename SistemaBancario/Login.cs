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
using System.Globalization;

namespace SistemaBancario
{
    public partial class Login : Form
    {
        public string getUsuario, getPassword;
        int idDestino;
        public Login_CN a;
        public Login()
        {
            InitializeComponent();
            a = new Login_CN();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {

            if (txtUser.Text == "" && txtPassword.Text == "")
            {
                MessageBox.Show("Debe rellenar ambos campos");
            }
            else if(txtPassword.Text=="")
            {
                MessageBox.Show("Debe ingresar una clave");
            }
            else if (txtUser.Text=="")

            {
                MessageBox.Show("Debe ingresar su primer nombre");
            }
            else
            {
                getUsuario = txtUser.Text;
                getUsuario = (CultureInfo.InvariantCulture.TextInfo.ToTitleCase(getUsuario));
                getPassword = txtPassword.Text;

                Saldo ingresar = new Saldo(getUsuario, getPassword);
                Depositar ingresarDep = new Depositar(getUsuario, getPassword);
                Retirar ingresarRet = new Retirar(getUsuario, getPassword);
                Cartola inresoCartola = new Cartola(getUsuario, getPassword);

                int resultado = a.ConsultaLogin(txtUser.Text, txtPassword.Text);

                if (resultado == 1)
                {
                    MessageBox.Show("Bienvenido " + getUsuario);

                    Main Ingreso = new Main(getUsuario, getPassword, idDestino);


                    this.Hide();
                    Ingreso.ShowDialog();
                    this.Close();

                }
                else if (resultado == 0)
                {
                    MessageBox.Show("Usuario y/o contrasenia incorrectas");
                }
            }
        }



        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void label3_MouseHover(object sender, EventArgs e)
        {
            labelRegistrate.ForeColor = Color.DeepSkyBlue;
        }

        private void labelRegistrate_MouseLeave(object sender, EventArgs e)
        {
            labelRegistrate.ForeColor = Color.Azure;
        }

        private void labelRegistrate_Click(object sender, EventArgs e)
        {
            Registro Registrar = new Registro();
            Registrar.ShowDialog();
        }

        private void label6_MouseDown_1(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void label6_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
