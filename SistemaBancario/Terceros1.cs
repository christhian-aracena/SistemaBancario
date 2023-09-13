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
    public partial class Terceros1 : Form
    {
        Consulta_CN a;
        public string user, pass;

        public string nombreBuscar, apellidoBuscar;
        public int idOrigen;
        public int idDestino;
        public int idIngresado;
        public Terceros1(int idOrigen, string user, string pass)
        {
            InitializeComponent();
            OCultar();
            this.user = user;
            this.pass = pass;
            this.idOrigen = idOrigen;



            a = new Consulta_CN();
        }

        private void Terceros1_Load(object sender, EventArgs e)
        {


        }
        public void OCultar()
        {
            lblNombre.Hide();
            lblApellido.Hide();
            dataGridView3.Hide();
            lblcompleteDestinatario.Hide();
            txtApellido.Hide();
            txtNombre.Hide();

            txtNumeroCuenta.Hide();
            lblIngreseNumeroCuenta.Hide();
            lblNumeroCuenta.Hide();
            lbl1.Hide();
            lbl2.Hide();
        }

        public void MostrarBusquedaNombreApe()
        {
            lblNombre.Show();
            lblApellido.Show();
            dataGridView3.Show();
            lblcompleteDestinatario.Show();
            txtApellido.Show();
            txtNombre.Show();
            lbl1.Show();
            lbl2.Show();
        }

        public void MostrarBusquedaNumeroCuenta()
        {
            txtNumeroCuenta.Show();
            lblIngreseNumeroCuenta.Show();
            lblNumeroCuenta.Show();
            dataGridView3.Show();
            lbl1.Show();
            lbl2.Show();
        }



        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void checkBox1_Click(object sender, EventArgs e)
        {
            OCultar();
            checkBox2.Checked = false;
            MostrarBusquedaNombreApe();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            OCultar();
            checkBox1.Checked = false;
            MostrarBusquedaNumeroCuenta();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            OCultar();
            checkBox2.Checked = false;
            checkBox1.Checked = true;
            MostrarBusquedaNombreApe();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkBox1.Checked)
                {

                    nombreBuscar = txtNombre.Text;
                    apellidoBuscar = txtApellido.Text;

                    this.dataGridView3.DataSource = a.BuscarCuenta_CN(nombreBuscar, apellidoBuscar);
                    this.dataGridView3.Columns[5].Visible = false;
                    this.dataGridView3.Columns[0].Width = 120;
                    CentrarRegistros();

                }
                else if (checkBox2.Checked)
                {

                    idIngresado = Convert.ToInt32(txtNumeroCuenta.Text.ToString());

                    this.dataGridView3.DataSource = a.BuscarCuenta_CN(idIngresado);
                    this.dataGridView3.Columns[5].Visible = false;
                    this.dataGridView3.Columns[0].Width = 120;
                    CentrarRegistros();
                }
                else
                {
                    MessageBox.Show("Selecciona una opcion");
                }
            }
            catch
            {
                MessageBox.Show("Debe ingresa solo numeros");
            }

        }
        private void CentrarRegistros()
        {
            this.dataGridView3.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void button1_Click(object sender, EventArgs e)
        {


            try
            {
                idDestino = Convert.ToInt32(dataGridView3.CurrentRow.Cells[0].Value.ToString());
                if (idOrigen == idDestino)

                {
                    MessageBox.Show("Si quieres agregar saldo a tu cuenta, elije  la opcion deposito");
                }
                else
                {

                    if (idDestino == 0)
                    {
                        MessageBox.Show("Sebe seleccionar un destinatario");
                    }
                    else
                    {
                        if (!checkBox1.Checked && !checkBox2.Checked)
                        {
                            MessageBox.Show("Debe seleccionar una opcion de busqueda");
                        }
                        else
                        {



                            Tercero2 final = new Tercero2(idOrigen, idDestino, user, pass);
                            this.Hide();
                            final.ShowDialog();
                            this.Close();
                        }

                    }
                }

            }
            catch
            {
                MessageBox.Show("Debes seleccionar un usuario de destino");
            }





        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idDestino = Convert.ToInt32(dataGridView3.CurrentRow.Cells[0].Value.ToString());

        }

        private void label5_Click(object sender, EventArgs e)
        {
            OCultar();
            checkBox1.Checked = false;
            checkBox2.Checked = true;
            MostrarBusquedaNumeroCuenta();
        }

        private void panel3_MouseDown_1(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
