namespace ProyectoU1_CCLl
{
    partial class Figura1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.boxPaso = new System.Windows.Forms.GroupBox();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.BoxGrafica = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BoxMovimiento = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.hScrollBar_Tamano = new System.Windows.Forms.HScrollBar();
            this.btnAntiHorario = new System.Windows.Forms.Button();
            this.btnHorario = new System.Windows.Forms.Button();
            this.lblSize = new System.Windows.Forms.Label();
            this.lblGiro = new System.Windows.Forms.Label();
            this.lblWASD = new System.Windows.Forms.Label();
            this.BoxInputs = new System.Windows.Forms.GroupBox();
            this.btnReset1 = new System.Windows.Forms.Button();
            this.btnGraficar1 = new System.Windows.Forms.Button();
            this.txtRadio1 = new System.Windows.Forms.TextBox();
            this.lblRadio = new System.Windows.Forms.Label();
            this.boxPaso.SuspendLayout();
            this.BoxGrafica.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.BoxMovimiento.SuspendLayout();
            this.BoxInputs.SuspendLayout();
            this.SuspendLayout();
            // 
            // boxPaso
            // 
            this.boxPaso.Controls.Add(this.btnAnterior);
            this.boxPaso.Controls.Add(this.btnSiguiente);
            this.boxPaso.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxPaso.Location = new System.Drawing.Point(10, 417);
            this.boxPaso.Name = "boxPaso";
            this.boxPaso.Size = new System.Drawing.Size(338, 93);
            this.boxPaso.TabIndex = 8;
            this.boxPaso.TabStop = false;
            this.boxPaso.Text = "Paso a Paso:";
            // 
            // btnAnterior
            // 
            this.btnAnterior.BackColor = System.Drawing.Color.PowderBlue;
            this.btnAnterior.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnterior.Location = new System.Drawing.Point(17, 34);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(113, 29);
            this.btnAnterior.TabIndex = 3;
            this.btnAnterior.Text = "Anterior";
            this.btnAnterior.UseVisualStyleBackColor = false;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.BackColor = System.Drawing.Color.PowderBlue;
            this.btnSiguiente.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSiguiente.Location = new System.Drawing.Point(163, 34);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(113, 29);
            this.btnSiguiente.TabIndex = 2;
            this.btnSiguiente.Text = "Siguiente";
            this.btnSiguiente.UseVisualStyleBackColor = false;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(7, 17);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(310, 18);
            this.lblTitulo.TabIndex = 9;
            this.lblTitulo.Text = "Polígono estrellado de 16 y 8 puntas.";
            // 
            // BoxGrafica
            // 
            this.BoxGrafica.Controls.Add(this.pictureBox1);
            this.BoxGrafica.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BoxGrafica.Location = new System.Drawing.Point(362, 17);
            this.BoxGrafica.Name = "BoxGrafica";
            this.BoxGrafica.Size = new System.Drawing.Size(431, 478);
            this.BoxGrafica.TabIndex = 7;
            this.BoxGrafica.TabStop = false;
            this.BoxGrafica.Text = "Gráfica:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(6, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(425, 444);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // BoxMovimiento
            // 
            this.BoxMovimiento.Controls.Add(this.label1);
            this.BoxMovimiento.Controls.Add(this.hScrollBar_Tamano);
            this.BoxMovimiento.Controls.Add(this.btnAntiHorario);
            this.BoxMovimiento.Controls.Add(this.btnHorario);
            this.BoxMovimiento.Controls.Add(this.lblSize);
            this.BoxMovimiento.Controls.Add(this.lblGiro);
            this.BoxMovimiento.Controls.Add(this.lblWASD);
            this.BoxMovimiento.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BoxMovimiento.Location = new System.Drawing.Point(7, 194);
            this.BoxMovimiento.Name = "BoxMovimiento";
            this.BoxMovimiento.Size = new System.Drawing.Size(338, 217);
            this.BoxMovimiento.TabIndex = 6;
            this.BoxMovimiento.TabStop = false;
            this.BoxMovimiento.Text = "Movimiento:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Giro Antihorario:";
            // 
            // hScrollBar_Tamano
            // 
            this.hScrollBar_Tamano.Location = new System.Drawing.Point(21, 177);
            this.hScrollBar_Tamano.Name = "hScrollBar_Tamano";
            this.hScrollBar_Tamano.Size = new System.Drawing.Size(263, 23);
            this.hScrollBar_Tamano.TabIndex = 5;
            this.hScrollBar_Tamano.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar_Tamano_Scroll);
            // 
            // btnAntiHorario
            // 
            this.btnAntiHorario.BackColor = System.Drawing.Color.PaleGreen;
            this.btnAntiHorario.Location = new System.Drawing.Point(27, 83);
            this.btnAntiHorario.Name = "btnAntiHorario";
            this.btnAntiHorario.Size = new System.Drawing.Size(82, 30);
            this.btnAntiHorario.TabIndex = 4;
            this.btnAntiHorario.Text = "- 5 º";
            this.btnAntiHorario.UseVisualStyleBackColor = false;
            this.btnAntiHorario.Click += new System.EventHandler(this.btnAntiHorario_Click);
            // 
            // btnHorario
            // 
            this.btnHorario.BackColor = System.Drawing.Color.LightBlue;
            this.btnHorario.Location = new System.Drawing.Point(202, 83);
            this.btnHorario.Name = "btnHorario";
            this.btnHorario.Size = new System.Drawing.Size(82, 30);
            this.btnHorario.TabIndex = 3;
            this.btnHorario.Text = "+ 5 º";
            this.btnHorario.UseVisualStyleBackColor = false;
            this.btnHorario.Click += new System.EventHandler(this.btnHorario_Click);
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize.Location = new System.Drawing.Point(17, 136);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(148, 18);
            this.lblSize.TabIndex = 2;
            this.lblSize.Text = "Ajusta el tamaño";
            // 
            // lblGiro
            // 
            this.lblGiro.AutoSize = true;
            this.lblGiro.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiro.Location = new System.Drawing.Point(189, 62);
            this.lblGiro.Name = "lblGiro";
            this.lblGiro.Size = new System.Drawing.Size(121, 18);
            this.lblGiro.TabIndex = 1;
            this.lblGiro.Text = "Giro Horario:";
            // 
            // lblWASD
            // 
            this.lblWASD.AutoSize = true;
            this.lblWASD.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWASD.Location = new System.Drawing.Point(18, 25);
            this.lblWASD.Name = "lblWASD";
            this.lblWASD.Size = new System.Drawing.Size(307, 16);
            this.lblWASD.TabIndex = 0;
            this.lblWASD.Text = "Usa las teclas direccionales para mover la figura.";
            // 
            // BoxInputs
            // 
            this.BoxInputs.Controls.Add(this.btnReset1);
            this.BoxInputs.Controls.Add(this.btnGraficar1);
            this.BoxInputs.Controls.Add(this.txtRadio1);
            this.BoxInputs.Controls.Add(this.lblRadio);
            this.BoxInputs.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BoxInputs.Location = new System.Drawing.Point(7, 38);
            this.BoxInputs.Name = "BoxInputs";
            this.BoxInputs.Size = new System.Drawing.Size(338, 150);
            this.BoxInputs.TabIndex = 5;
            this.BoxInputs.TabStop = false;
            this.BoxInputs.Text = "Entradas:";
            // 
            // btnReset1
            // 
            this.btnReset1.BackColor = System.Drawing.SystemColors.Control;
            this.btnReset1.Location = new System.Drawing.Point(27, 104);
            this.btnReset1.Name = "btnReset1";
            this.btnReset1.Size = new System.Drawing.Size(113, 29);
            this.btnReset1.TabIndex = 3;
            this.btnReset1.Text = "Resetear";
            this.btnReset1.UseVisualStyleBackColor = false;
            this.btnReset1.Click += new System.EventHandler(this.btnReset1_Click);
            // 
            // btnGraficar1
            // 
            this.btnGraficar1.BackColor = System.Drawing.SystemColors.Control;
            this.btnGraficar1.Location = new System.Drawing.Point(202, 55);
            this.btnGraficar1.Name = "btnGraficar1";
            this.btnGraficar1.Size = new System.Drawing.Size(113, 29);
            this.btnGraficar1.TabIndex = 2;
            this.btnGraficar1.Text = "Graficar";
            this.btnGraficar1.UseVisualStyleBackColor = false;
            this.btnGraficar1.Click += new System.EventHandler(this.btnGraficar1_Click);
            // 
            // txtRadio1
            // 
            this.txtRadio1.Location = new System.Drawing.Point(27, 57);
            this.txtRadio1.Name = "txtRadio1";
            this.txtRadio1.Size = new System.Drawing.Size(158, 26);
            this.txtRadio1.TabIndex = 1;
            this.txtRadio1.TextChanged += new System.EventHandler(this.txtRadio1_TextChanged);
            // 
            // lblRadio
            // 
            this.lblRadio.AutoSize = true;
            this.lblRadio.Location = new System.Drawing.Point(23, 25);
            this.lblRadio.Name = "lblRadio";
            this.lblRadio.Size = new System.Drawing.Size(210, 18);
            this.lblRadio.TabIndex = 0;
            this.lblRadio.Text = "Ingresa el radio del polígono:";
            // 
            // Figura1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(800, 527);
            this.Controls.Add(this.boxPaso);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.BoxGrafica);
            this.Controls.Add(this.BoxMovimiento);
            this.Controls.Add(this.BoxInputs);
            this.Name = "Figura1";
            this.Text = "Polígono estrellado de 16 y 8 puntas.";
            this.Load += new System.EventHandler(this.Figura1_Load);
            this.boxPaso.ResumeLayout(false);
            this.BoxGrafica.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.BoxMovimiento.ResumeLayout(false);
            this.BoxMovimiento.PerformLayout();
            this.BoxInputs.ResumeLayout(false);
            this.BoxInputs.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox boxPaso;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox BoxGrafica;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox BoxMovimiento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.HScrollBar hScrollBar_Tamano;
        private System.Windows.Forms.Button btnAntiHorario;
        private System.Windows.Forms.Button btnHorario;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Label lblGiro;
        private System.Windows.Forms.Label lblWASD;
        private System.Windows.Forms.GroupBox BoxInputs;
        private System.Windows.Forms.Button btnReset1;
        private System.Windows.Forms.Button btnGraficar1;
        private System.Windows.Forms.TextBox txtRadio1;
        private System.Windows.Forms.Label lblRadio;
    }
}

