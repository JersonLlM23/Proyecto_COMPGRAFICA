namespace ProyectoU1_CCLl
{
    partial class Figura2
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
            this.boxPaso2 = new System.Windows.Forms.GroupBox();
            this.btn2Anterior = new System.Windows.Forms.Button();
            this.btn2Siguiente = new System.Windows.Forms.Button();
            this.lbl2Titulo = new System.Windows.Forms.Label();
            this.Box2Grafica = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.BoxMovimiento2 = new System.Windows.Forms.GroupBox();
            this.lblAntiH2 = new System.Windows.Forms.Label();
            this.hScrollBar_Tamano2 = new System.Windows.Forms.HScrollBar();
            this.btnAntiHorario2 = new System.Windows.Forms.Button();
            this.btnHorario2 = new System.Windows.Forms.Button();
            this.lblSize2 = new System.Windows.Forms.Label();
            this.lblHorario2 = new System.Windows.Forms.Label();
            this.lbl2MovimientoTeclas = new System.Windows.Forms.Label();
            this.BoxInputs2 = new System.Windows.Forms.GroupBox();
            this.btnReset2 = new System.Windows.Forms.Button();
            this.btnGraficar2 = new System.Windows.Forms.Button();
            this.txtRadio2 = new System.Windows.Forms.TextBox();
            this.lbl2Radio = new System.Windows.Forms.Label();
            this.boxPaso2.SuspendLayout();
            this.Box2Grafica.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.BoxMovimiento2.SuspendLayout();
            this.BoxInputs2.SuspendLayout();
            this.SuspendLayout();
            // 
            // boxPaso2
            // 
            this.boxPaso2.Controls.Add(this.btn2Anterior);
            this.boxPaso2.Controls.Add(this.btn2Siguiente);
            this.boxPaso2.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxPaso2.Location = new System.Drawing.Point(10, 415);
            this.boxPaso2.Name = "boxPaso2";
            this.boxPaso2.Size = new System.Drawing.Size(338, 93);
            this.boxPaso2.TabIndex = 13;
            this.boxPaso2.TabStop = false;
            this.boxPaso2.Text = "Paso a Paso:";
            // 
            // btn2Anterior
            // 
            this.btn2Anterior.BackColor = System.Drawing.Color.PowderBlue;
            this.btn2Anterior.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn2Anterior.Location = new System.Drawing.Point(17, 34);
            this.btn2Anterior.Name = "btn2Anterior";
            this.btn2Anterior.Size = new System.Drawing.Size(113, 29);
            this.btn2Anterior.TabIndex = 3;
            this.btn2Anterior.Text = "Anterior";
            this.btn2Anterior.UseVisualStyleBackColor = false;
            this.btn2Anterior.Click += new System.EventHandler(this.btn2Anterior_Click);
            // 
            // btn2Siguiente
            // 
            this.btn2Siguiente.BackColor = System.Drawing.Color.PowderBlue;
            this.btn2Siguiente.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn2Siguiente.Location = new System.Drawing.Point(163, 34);
            this.btn2Siguiente.Name = "btn2Siguiente";
            this.btn2Siguiente.Size = new System.Drawing.Size(113, 29);
            this.btn2Siguiente.TabIndex = 2;
            this.btn2Siguiente.Text = "Siguiente";
            this.btn2Siguiente.UseVisualStyleBackColor = false;
            this.btn2Siguiente.Click += new System.EventHandler(this.btn2Siguiente_Click);
            // 
            // lbl2Titulo
            // 
            this.lbl2Titulo.AutoSize = true;
            this.lbl2Titulo.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2Titulo.Location = new System.Drawing.Point(4, 9);
            this.lbl2Titulo.Name = "lbl2Titulo";
            this.lbl2Titulo.Size = new System.Drawing.Size(403, 18);
            this.lbl2Titulo.TabIndex = 14;
            this.lbl2Titulo.Text = "Pentágonos y polígonos estrellados de 5 puntas.";
            // 
            // Box2Grafica
            // 
            this.Box2Grafica.Controls.Add(this.pictureBox2);
            this.Box2Grafica.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Box2Grafica.Location = new System.Drawing.Point(354, 33);
            this.Box2Grafica.Name = "Box2Grafica";
            this.Box2Grafica.Size = new System.Drawing.Size(441, 486);
            this.Box2Grafica.TabIndex = 12;
            this.Box2Grafica.TabStop = false;
            this.Box2Grafica.Text = "Gráfica:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(6, 28);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(425, 444);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // BoxMovimiento2
            // 
            this.BoxMovimiento2.Controls.Add(this.lblAntiH2);
            this.BoxMovimiento2.Controls.Add(this.hScrollBar_Tamano2);
            this.BoxMovimiento2.Controls.Add(this.btnAntiHorario2);
            this.BoxMovimiento2.Controls.Add(this.btnHorario2);
            this.BoxMovimiento2.Controls.Add(this.lblSize2);
            this.BoxMovimiento2.Controls.Add(this.lblHorario2);
            this.BoxMovimiento2.Controls.Add(this.lbl2MovimientoTeclas);
            this.BoxMovimiento2.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BoxMovimiento2.Location = new System.Drawing.Point(7, 192);
            this.BoxMovimiento2.Name = "BoxMovimiento2";
            this.BoxMovimiento2.Size = new System.Drawing.Size(338, 217);
            this.BoxMovimiento2.TabIndex = 11;
            this.BoxMovimiento2.TabStop = false;
            this.BoxMovimiento2.Text = "Movimiento:";
            // 
            // lblAntiH2
            // 
            this.lblAntiH2.AutoSize = true;
            this.lblAntiH2.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAntiH2.Location = new System.Drawing.Point(18, 62);
            this.lblAntiH2.Name = "lblAntiH2";
            this.lblAntiH2.Size = new System.Drawing.Size(154, 18);
            this.lblAntiH2.TabIndex = 6;
            this.lblAntiH2.Text = "Giro Antihorario:";
            // 
            // hScrollBar_Tamano2
            // 
            this.hScrollBar_Tamano2.Location = new System.Drawing.Point(21, 177);
            this.hScrollBar_Tamano2.Name = "hScrollBar_Tamano2";
            this.hScrollBar_Tamano2.Size = new System.Drawing.Size(263, 23);
            this.hScrollBar_Tamano2.TabIndex = 5;
            this.hScrollBar_Tamano2.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar_Tamano2_Scroll);
            // 
            // btnAntiHorario2
            // 
            this.btnAntiHorario2.BackColor = System.Drawing.Color.PaleGreen;
            this.btnAntiHorario2.Location = new System.Drawing.Point(27, 83);
            this.btnAntiHorario2.Name = "btnAntiHorario2";
            this.btnAntiHorario2.Size = new System.Drawing.Size(82, 30);
            this.btnAntiHorario2.TabIndex = 4;
            this.btnAntiHorario2.Text = "- 5 º";
            this.btnAntiHorario2.UseVisualStyleBackColor = false;
            this.btnAntiHorario2.Click += new System.EventHandler(this.btnAntiHorario2_Click);
            // 
            // btnHorario2
            // 
            this.btnHorario2.BackColor = System.Drawing.Color.LightBlue;
            this.btnHorario2.Location = new System.Drawing.Point(202, 83);
            this.btnHorario2.Name = "btnHorario2";
            this.btnHorario2.Size = new System.Drawing.Size(82, 30);
            this.btnHorario2.TabIndex = 3;
            this.btnHorario2.Text = "+ 5 º";
            this.btnHorario2.UseVisualStyleBackColor = false;
            this.btnHorario2.Click += new System.EventHandler(this.btnHorario2_Click);
            // 
            // lblSize2
            // 
            this.lblSize2.AutoSize = true;
            this.lblSize2.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize2.Location = new System.Drawing.Point(17, 136);
            this.lblSize2.Name = "lblSize2";
            this.lblSize2.Size = new System.Drawing.Size(148, 18);
            this.lblSize2.TabIndex = 2;
            this.lblSize2.Text = "Ajusta el tamaño";
            // 
            // lblHorario2
            // 
            this.lblHorario2.AutoSize = true;
            this.lblHorario2.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHorario2.Location = new System.Drawing.Point(189, 62);
            this.lblHorario2.Name = "lblHorario2";
            this.lblHorario2.Size = new System.Drawing.Size(121, 18);
            this.lblHorario2.TabIndex = 1;
            this.lblHorario2.Text = "Giro Horario:";
            // 
            // lbl2MovimientoTeclas
            // 
            this.lbl2MovimientoTeclas.AutoSize = true;
            this.lbl2MovimientoTeclas.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2MovimientoTeclas.Location = new System.Drawing.Point(18, 25);
            this.lbl2MovimientoTeclas.Name = "lbl2MovimientoTeclas";
            this.lbl2MovimientoTeclas.Size = new System.Drawing.Size(307, 16);
            this.lbl2MovimientoTeclas.TabIndex = 0;
            this.lbl2MovimientoTeclas.Text = "Usa las teclas direccionales para mover la figura.";
            // 
            // BoxInputs2
            // 
            this.BoxInputs2.Controls.Add(this.btnReset2);
            this.BoxInputs2.Controls.Add(this.btnGraficar2);
            this.BoxInputs2.Controls.Add(this.txtRadio2);
            this.BoxInputs2.Controls.Add(this.lbl2Radio);
            this.BoxInputs2.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BoxInputs2.Location = new System.Drawing.Point(7, 36);
            this.BoxInputs2.Name = "BoxInputs2";
            this.BoxInputs2.Size = new System.Drawing.Size(338, 150);
            this.BoxInputs2.TabIndex = 10;
            this.BoxInputs2.TabStop = false;
            this.BoxInputs2.Text = "Entradas:";
            // 
            // btnReset2
            // 
            this.btnReset2.BackColor = System.Drawing.SystemColors.Control;
            this.btnReset2.Location = new System.Drawing.Point(27, 104);
            this.btnReset2.Name = "btnReset2";
            this.btnReset2.Size = new System.Drawing.Size(113, 29);
            this.btnReset2.TabIndex = 3;
            this.btnReset2.Text = "Resetear";
            this.btnReset2.UseVisualStyleBackColor = false;
            this.btnReset2.Click += new System.EventHandler(this.btnReset2_Click);
            // 
            // btnGraficar2
            // 
            this.btnGraficar2.BackColor = System.Drawing.SystemColors.Control;
            this.btnGraficar2.Location = new System.Drawing.Point(202, 55);
            this.btnGraficar2.Name = "btnGraficar2";
            this.btnGraficar2.Size = new System.Drawing.Size(113, 29);
            this.btnGraficar2.TabIndex = 2;
            this.btnGraficar2.Text = "Graficar";
            this.btnGraficar2.UseVisualStyleBackColor = false;
            this.btnGraficar2.Click += new System.EventHandler(this.btnGraficar2_Click);
            // 
            // txtRadio2
            // 
            this.txtRadio2.Location = new System.Drawing.Point(27, 57);
            this.txtRadio2.Name = "txtRadio2";
            this.txtRadio2.Size = new System.Drawing.Size(158, 26);
            this.txtRadio2.TabIndex = 1;
            this.txtRadio2.TextChanged += new System.EventHandler(this.txtRadio2_TextChanged);
            // 
            // lbl2Radio
            // 
            this.lbl2Radio.AutoSize = true;
            this.lbl2Radio.Location = new System.Drawing.Point(23, 25);
            this.lbl2Radio.Name = "lbl2Radio";
            this.lbl2Radio.Size = new System.Drawing.Size(210, 18);
            this.lbl2Radio.TabIndex = 0;
            this.lbl2Radio.Text = "Ingresa el radio del polígono:";
            // 
            // Figura2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(815, 523);
            this.Controls.Add(this.boxPaso2);
            this.Controls.Add(this.lbl2Titulo);
            this.Controls.Add(this.Box2Grafica);
            this.Controls.Add(this.BoxMovimiento2);
            this.Controls.Add(this.BoxInputs2);
            this.Name = "Figura2";
            this.Text = "Pentágonos y polígonos estrellados de 5 puntas.";
            this.Load += new System.EventHandler(this.Figura2_Load);
            this.boxPaso2.ResumeLayout(false);
            this.Box2Grafica.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.BoxMovimiento2.ResumeLayout(false);
            this.BoxMovimiento2.PerformLayout();
            this.BoxInputs2.ResumeLayout(false);
            this.BoxInputs2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox boxPaso2;
        private System.Windows.Forms.Button btn2Anterior;
        private System.Windows.Forms.Button btn2Siguiente;
        private System.Windows.Forms.Label lbl2Titulo;
        private System.Windows.Forms.GroupBox Box2Grafica;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.GroupBox BoxMovimiento2;
        private System.Windows.Forms.Label lblAntiH2;
        private System.Windows.Forms.HScrollBar hScrollBar_Tamano2;
        private System.Windows.Forms.Button btnAntiHorario2;
        private System.Windows.Forms.Button btnHorario2;
        private System.Windows.Forms.Label lblSize2;
        private System.Windows.Forms.Label lblHorario2;
        private System.Windows.Forms.Label lbl2MovimientoTeclas;
        private System.Windows.Forms.GroupBox BoxInputs2;
        private System.Windows.Forms.Button btnReset2;
        private System.Windows.Forms.Button btnGraficar2;
        private System.Windows.Forms.TextBox txtRadio2;
        private System.Windows.Forms.Label lbl2Radio;
    }
}

