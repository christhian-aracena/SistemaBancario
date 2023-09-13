namespace SistemaBancario
{
    partial class MensajeAceptado
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MensajeAceptado));
            this.labelRecibidoporBanco = new System.Windows.Forms.Label();
            this.labelDepositoAceptado = new System.Windows.Forms.Label();
            this.labelAccepted = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelRecibidoporBanco
            // 
            this.labelRecibidoporBanco.AutoSize = true;
            this.labelRecibidoporBanco.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.labelRecibidoporBanco.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRecibidoporBanco.ForeColor = System.Drawing.Color.Ivory;
            this.labelRecibidoporBanco.Location = new System.Drawing.Point(205, 94);
            this.labelRecibidoporBanco.Name = "labelRecibidoporBanco";
            this.labelRecibidoporBanco.Size = new System.Drawing.Size(233, 15);
            this.labelRecibidoporBanco.TabIndex = 23;
            this.labelRecibidoporBanco.Text = "Registrado y aceptado por  banco Águilas";
            // 
            // labelDepositoAceptado
            // 
            this.labelDepositoAceptado.AutoSize = true;
            this.labelDepositoAceptado.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.labelDepositoAceptado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDepositoAceptado.ForeColor = System.Drawing.Color.Ivory;
            this.labelDepositoAceptado.Location = new System.Drawing.Point(179, 63);
            this.labelDepositoAceptado.Name = "labelDepositoAceptado";
            this.labelDepositoAceptado.Size = new System.Drawing.Size(276, 24);
            this.labelDepositoAceptado.TabIndex = 22;
            this.labelDepositoAceptado.Text = "Transaccion realizada con exito";
            // 
            // labelAccepted
            // 
            this.labelAccepted.BackColor = System.Drawing.Color.Transparent;
            this.labelAccepted.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("labelAccepted.BackgroundImage")));
            this.labelAccepted.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.labelAccepted.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.labelAccepted.FlatAppearance.BorderSize = 0;
            this.labelAccepted.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.labelAccepted.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.labelAccepted.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelAccepted.Location = new System.Drawing.Point(12, 4);
            this.labelAccepted.Name = "labelAccepted";
            this.labelAccepted.Size = new System.Drawing.Size(25, 25);
            this.labelAccepted.TabIndex = 21;
            this.labelAccepted.UseVisualStyleBackColor = false;
            this.labelAccepted.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(24, 57);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 80);
            this.button1.TabIndex = 24;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnIngresar
            // 
            this.btnIngresar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(118)))), ((int)(((byte)(174)))));
            this.btnIngresar.FlatAppearance.BorderSize = 0;
            this.btnIngresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresar.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnIngresar.Location = new System.Drawing.Point(210, 124);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(212, 27);
            this.btnIngresar.TabIndex = 25;
            this.btnIngresar.Text = "Aceptar";
            this.btnIngresar.UseVisualStyleBackColor = false;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(118)))), ((int)(((byte)(174)))));
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.btnCerrar);
            this.panel1.Controls.Add(this.labelAccepted);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(476, 31);
            this.panel1.TabIndex = 26;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Snow;
            this.label6.Location = new System.Drawing.Point(39, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(153, 18);
            this.label6.TabIndex = 8;
            this.label6.Text = "Transaccion realizada";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            this.label6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.ForeColor = System.Drawing.SystemColors.Info;
            this.btnCerrar.Location = new System.Drawing.Point(761, 0);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(0);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(30, 30);
            this.btnCerrar.TabIndex = 6;
            this.btnCerrar.Text = "X";
            this.btnCerrar.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.Info;
            this.button2.Location = new System.Drawing.Point(437, -1);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(30, 30);
            this.button2.TabIndex = 9;
            this.button2.Text = "X";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MensajeAceptado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(110)))), ((int)(((byte)(174)))));
            this.ClientSize = new System.Drawing.Size(476, 181);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelRecibidoporBanco);
            this.Controls.Add(this.labelDepositoAceptado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MensajeAceptado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transferencia exitosa";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelRecibidoporBanco;
        private System.Windows.Forms.Label labelDepositoAceptado;
        private System.Windows.Forms.Button labelAccepted;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button button2;
    }
}