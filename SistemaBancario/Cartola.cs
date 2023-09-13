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
using System.Runtime.InteropServices;


namespace SistemaBancario
{
    public partial class Cartola : Form
    {
        Consulta_CN a;
        string user1, pass1;
        int id;
        public Cartola(string user, string pass)
        {
            InitializeComponent();
            a = new Consulta_CN();
            user1 = user;
            pass1 = pass;
            this.dataGridView1.DataSource = a.GetSaldoInvisible_CN(user1, pass1);
            //this.dataGridView2.DataSource = a.GetSaldoInvisible_CN(user1, pass1);

            //this.dataGridView2.Columns[1].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Cartola_Load(object sender, EventArgs e)
        {
            this.dataGridView1.Visible = false;
            id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            this.dataGridView3.DataSource = a.Cartola(id);
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                string valor = Convert.ToString(dataGridView3.Rows[i].Cells[0].Value.ToString().Substring(0, 1));


                if (valor == "+")
                {


                    this.dataGridView3.Rows[i].Cells[0].Style.BackColor = Color.DarkGreen;
                    this.dataGridView3.Rows[i].Cells[1].Style.BackColor = Color.DarkGreen;
                    this.dataGridView3.Rows[i].Cells[2].Style.BackColor = Color.DarkGreen;

                }
                else
                {
                    //this.dataGridView3.CurrentCell.Style.BackColor = Color.IndianRed;
                    this.dataGridView3.Rows[i].Cells[0].Style.BackColor = Color.IndianRed;
                    this.dataGridView3.Rows[i].Cells[1].Style.BackColor = Color.IndianRed;
                    this.dataGridView3.Rows[i].Cells[2].Style.BackColor = Color.IndianRed;
                }




            }



        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
    }
}
