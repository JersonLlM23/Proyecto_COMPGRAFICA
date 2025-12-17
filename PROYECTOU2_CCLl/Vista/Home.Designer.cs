namespace PROYECTO_U2_CCLl
{
    partial class Home
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
            this.pnlLayout = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.comboMaterial = new System.Windows.Forms.ComboBox();
            this.lblMaterial = new System.Windows.Forms.Label();
            this.comboCamara = new System.Windows.Forms.ComboBox();
            this.lblCamera = new System.Windows.Forms.Label();
            this.comboColor = new System.Windows.Forms.ComboBox();
            this.lblColor = new System.Windows.Forms.Label();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.btnResetear = new System.Windows.Forms.Button();
            this.lblFiguras = new System.Windows.Forms.Label();
            this.pictureEsfera = new System.Windows.Forms.PictureBox();
            this.picturePrismaRectang = new System.Windows.Forms.PictureBox();
            this.pictureCilindro = new System.Windows.Forms.PictureBox();
            this.pictureCono = new System.Windows.Forms.PictureBox();
            this.pictureCubo = new System.Windows.Forms.PictureBox();
            this.picturePiramide = new System.Windows.Forms.PictureBox();
            this.pnlSliders = new System.Windows.Forms.Panel();
            this.panelTransfo = new System.Windows.Forms.Panel();
            this.trackZESCAL = new System.Windows.Forms.TrackBar();
            this.trackYESCAL = new System.Windows.Forms.TrackBar();
            this.trackXESCAL = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTranslacion = new System.Windows.Forms.Label();
            this.trackZROT = new System.Windows.Forms.TrackBar();
            this.trackYROT = new System.Windows.Forms.TrackBar();
            this.trackXROT = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRotación = new System.Windows.Forms.Label();
            this.lblZ = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.numZPosicion = new System.Windows.Forms.NumericUpDown();
            this.numYPosicion = new System.Windows.Forms.NumericUpDown();
            this.lblPosicion = new System.Windows.Forms.Label();
            this.numXPosicion = new System.Windows.Forms.NumericUpDown();
            this.pnlListBox = new System.Windows.Forms.Panel();
            this.boxFiguras = new System.Windows.Forms.ListBox();
            this.glControlWindow = new OpenTK.GLControl();
            this.pnlLayout.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEsfera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturePrismaRectang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCilindro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCono)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCubo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturePiramide)).BeginInit();
            this.pnlSliders.SuspendLayout();
            this.panelTransfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackZESCAL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackYESCAL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackXESCAL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackZROT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackYROT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackXROT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numZPosicion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYPosicion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numXPosicion)).BeginInit();
            this.pnlListBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLayout
            // 
            this.pnlLayout.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlLayout.Controls.Add(this.lblTitulo);
            this.pnlLayout.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLayout.Location = new System.Drawing.Point(0, 0);
            this.pnlLayout.Margin = new System.Windows.Forms.Padding(4);
            this.pnlLayout.Name = "pnlLayout";
            this.pnlLayout.Size = new System.Drawing.Size(1573, 114);
            this.pnlLayout.TabIndex = 1;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTitulo.Font = new System.Drawing.Font("Cambria", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(299, 40);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Editor Gráfico 3D  ";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlFooter.Controls.Add(this.comboMaterial);
            this.pnlFooter.Controls.Add(this.lblMaterial);
            this.pnlFooter.Controls.Add(this.comboCamara);
            this.pnlFooter.Controls.Add(this.lblCamera);
            this.pnlFooter.Controls.Add(this.comboColor);
            this.pnlFooter.Controls.Add(this.lblColor);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 766);
            this.pnlFooter.Margin = new System.Windows.Forms.Padding(4);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1573, 43);
            this.pnlFooter.TabIndex = 2;
            // 
            // comboMaterial
            // 
            this.comboMaterial.FormattingEnabled = true;
            this.comboMaterial.Location = new System.Drawing.Point(359, 7);
            this.comboMaterial.Margin = new System.Windows.Forms.Padding(4);
            this.comboMaterial.Name = "comboMaterial";
            this.comboMaterial.Size = new System.Drawing.Size(160, 24);
            this.comboMaterial.TabIndex = 19;
            // 
            // lblMaterial
            // 
            this.lblMaterial.AutoSize = true;
            this.lblMaterial.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaterial.Location = new System.Drawing.Point(263, 10);
            this.lblMaterial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(94, 23);
            this.lblMaterial.TabIndex = 18;
            this.lblMaterial.Text = "Material:";
            // 
            // comboCamara
            // 
            this.comboCamara.FormattingEnabled = true;
            this.comboCamara.Location = new System.Drawing.Point(1408, 7);
            this.comboCamara.Margin = new System.Windows.Forms.Padding(4);
            this.comboCamara.Name = "comboCamara";
            this.comboCamara.Size = new System.Drawing.Size(160, 24);
            this.comboCamara.TabIndex = 17;
            // 
            // lblCamera
            // 
            this.lblCamera.AutoSize = true;
            this.lblCamera.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCamera.Location = new System.Drawing.Point(1307, 10);
            this.lblCamera.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCamera.Name = "lblCamera";
            this.lblCamera.Size = new System.Drawing.Size(87, 23);
            this.lblCamera.TabIndex = 16;
            this.lblCamera.Text = "Cámara:";
            // 
            // comboColor
            // 
            this.comboColor.FormattingEnabled = true;
            this.comboColor.Location = new System.Drawing.Point(81, 7);
            this.comboColor.Margin = new System.Windows.Forms.Padding(4);
            this.comboColor.Name = "comboColor";
            this.comboColor.Size = new System.Drawing.Size(160, 24);
            this.comboColor.TabIndex = 15;
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColor.Location = new System.Drawing.Point(16, 10);
            this.lblColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(64, 23);
            this.lblColor.TabIndex = 14;
            this.lblColor.Text = "Color:";
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.Silver;
            this.pnlLeft.Controls.Add(this.btnResetear);
            this.pnlLeft.Controls.Add(this.lblFiguras);
            this.pnlLeft.Controls.Add(this.pictureEsfera);
            this.pnlLeft.Controls.Add(this.picturePrismaRectang);
            this.pnlLeft.Controls.Add(this.pictureCilindro);
            this.pnlLeft.Controls.Add(this.pictureCono);
            this.pnlLeft.Controls.Add(this.pictureCubo);
            this.pnlLeft.Controls.Add(this.picturePiramide);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 114);
            this.pnlLeft.Margin = new System.Windows.Forms.Padding(4);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(156, 652);
            this.pnlLeft.TabIndex = 3;
            // 
            // btnResetear
            // 
            this.btnResetear.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnResetear.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.btnResetear.Location = new System.Drawing.Point(7, 537);
            this.btnResetear.Margin = new System.Windows.Forms.Padding(4);
            this.btnResetear.Name = "btnResetear";
            this.btnResetear.Size = new System.Drawing.Size(141, 33);
            this.btnResetear.TabIndex = 14;
            this.btnResetear.Text = "Resetear";
            this.btnResetear.UseVisualStyleBackColor = true;
            this.btnResetear.Click += new System.EventHandler(this.btnResetear_Click);
            // 
            // lblFiguras
            // 
            this.lblFiguras.AutoSize = true;
            this.lblFiguras.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiguras.Location = new System.Drawing.Point(29, 20);
            this.lblFiguras.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFiguras.Name = "lblFiguras";
            this.lblFiguras.Size = new System.Drawing.Size(97, 23);
            this.lblFiguras.TabIndex = 13;
            this.lblFiguras.Text = "FIGURAS:";
            // 
            // pictureEsfera
            // 
            this.pictureEsfera.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureEsfera.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureEsfera.Image = global::PROYECTO_U2_CCLl.Properties.Resources.imgEsfera;
            this.pictureEsfera.Location = new System.Drawing.Point(81, 357);
            this.pictureEsfera.Margin = new System.Windows.Forms.Padding(4);
            this.pictureEsfera.Name = "pictureEsfera";
            this.pictureEsfera.Size = new System.Drawing.Size(65, 61);
            this.pictureEsfera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureEsfera.TabIndex = 12;
            this.pictureEsfera.TabStop = false;
            this.pictureEsfera.Click += new System.EventHandler(this.pictureEsfera_Click);
            // 
            // picturePrismaRectang
            // 
            this.picturePrismaRectang.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.picturePrismaRectang.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picturePrismaRectang.Image = global::PROYECTO_U2_CCLl.Properties.Resources.imgPrismaRect;
            this.picturePrismaRectang.Location = new System.Drawing.Point(7, 357);
            this.picturePrismaRectang.Margin = new System.Windows.Forms.Padding(4);
            this.picturePrismaRectang.Name = "picturePrismaRectang";
            this.picturePrismaRectang.Size = new System.Drawing.Size(65, 61);
            this.picturePrismaRectang.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picturePrismaRectang.TabIndex = 11;
            this.picturePrismaRectang.TabStop = false;
            this.picturePrismaRectang.Click += new System.EventHandler(this.picturePrismaRectang_Click);
            // 
            // pictureCilindro
            // 
            this.pictureCilindro.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureCilindro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureCilindro.Image = global::PROYECTO_U2_CCLl.Properties.Resources.imgCilindro;
            this.pictureCilindro.Location = new System.Drawing.Point(81, 234);
            this.pictureCilindro.Margin = new System.Windows.Forms.Padding(4);
            this.pictureCilindro.Name = "pictureCilindro";
            this.pictureCilindro.Size = new System.Drawing.Size(65, 61);
            this.pictureCilindro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureCilindro.TabIndex = 10;
            this.pictureCilindro.TabStop = false;
            this.pictureCilindro.Click += new System.EventHandler(this.pictureCilindro_Click);
            // 
            // pictureCono
            // 
            this.pictureCono.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureCono.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureCono.Image = global::PROYECTO_U2_CCLl.Properties.Resources.imgCono;
            this.pictureCono.Location = new System.Drawing.Point(7, 234);
            this.pictureCono.Margin = new System.Windows.Forms.Padding(4);
            this.pictureCono.Name = "pictureCono";
            this.pictureCono.Size = new System.Drawing.Size(65, 61);
            this.pictureCono.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureCono.TabIndex = 9;
            this.pictureCono.TabStop = false;
            this.pictureCono.Click += new System.EventHandler(this.pictureCono_Click);
            // 
            // pictureCubo
            // 
            this.pictureCubo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureCubo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureCubo.Image = global::PROYECTO_U2_CCLl.Properties.Resources.iconCubo;
            this.pictureCubo.Location = new System.Drawing.Point(81, 111);
            this.pictureCubo.Margin = new System.Windows.Forms.Padding(4);
            this.pictureCubo.Name = "pictureCubo";
            this.pictureCubo.Size = new System.Drawing.Size(65, 61);
            this.pictureCubo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureCubo.TabIndex = 8;
            this.pictureCubo.TabStop = false;
            this.pictureCubo.Click += new System.EventHandler(this.pictureCubo_Click);
            // 
            // picturePiramide
            // 
            this.picturePiramide.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.picturePiramide.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picturePiramide.Image = global::PROYECTO_U2_CCLl.Properties.Resources.iconPiramide;
            this.picturePiramide.Location = new System.Drawing.Point(7, 111);
            this.picturePiramide.Margin = new System.Windows.Forms.Padding(4);
            this.picturePiramide.Name = "picturePiramide";
            this.picturePiramide.Size = new System.Drawing.Size(65, 61);
            this.picturePiramide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picturePiramide.TabIndex = 0;
            this.picturePiramide.TabStop = false;
            this.picturePiramide.Click += new System.EventHandler(this.picturePiramide_Click);
            // 
            // pnlSliders
            // 
            this.pnlSliders.Controls.Add(this.panelTransfo);
            this.pnlSliders.Controls.Add(this.pnlListBox);
            this.pnlSliders.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlSliders.Location = new System.Drawing.Point(1352, 114);
            this.pnlSliders.Margin = new System.Windows.Forms.Padding(4);
            this.pnlSliders.Name = "pnlSliders";
            this.pnlSliders.Size = new System.Drawing.Size(221, 652);
            this.pnlSliders.TabIndex = 4;
            // 
            // panelTransfo
            // 
            this.panelTransfo.BackColor = System.Drawing.Color.Silver;
            this.panelTransfo.Controls.Add(this.trackZESCAL);
            this.panelTransfo.Controls.Add(this.trackYESCAL);
            this.panelTransfo.Controls.Add(this.trackXESCAL);
            this.panelTransfo.Controls.Add(this.label4);
            this.panelTransfo.Controls.Add(this.label5);
            this.panelTransfo.Controls.Add(this.label6);
            this.panelTransfo.Controls.Add(this.lblTranslacion);
            this.panelTransfo.Controls.Add(this.trackZROT);
            this.panelTransfo.Controls.Add(this.trackYROT);
            this.panelTransfo.Controls.Add(this.trackXROT);
            this.panelTransfo.Controls.Add(this.label1);
            this.panelTransfo.Controls.Add(this.label2);
            this.panelTransfo.Controls.Add(this.label3);
            this.panelTransfo.Controls.Add(this.lblRotación);
            this.panelTransfo.Controls.Add(this.lblZ);
            this.panelTransfo.Controls.Add(this.lblY);
            this.panelTransfo.Controls.Add(this.lblX);
            this.panelTransfo.Controls.Add(this.numZPosicion);
            this.panelTransfo.Controls.Add(this.numYPosicion);
            this.panelTransfo.Controls.Add(this.lblPosicion);
            this.panelTransfo.Controls.Add(this.numXPosicion);
            this.panelTransfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTransfo.Location = new System.Drawing.Point(0, 166);
            this.panelTransfo.Margin = new System.Windows.Forms.Padding(4);
            this.panelTransfo.Name = "panelTransfo";
            this.panelTransfo.Size = new System.Drawing.Size(221, 486);
            this.panelTransfo.TabIndex = 3;
            // 
            // trackZESCAL
            // 
            this.trackZESCAL.Location = new System.Drawing.Point(67, 426);
            this.trackZESCAL.Margin = new System.Windows.Forms.Padding(4);
            this.trackZESCAL.Name = "trackZESCAL";
            this.trackZESCAL.Size = new System.Drawing.Size(139, 56);
            this.trackZESCAL.TabIndex = 21;
            // 
            // trackYESCAL
            // 
            this.trackYESCAL.Location = new System.Drawing.Point(67, 378);
            this.trackYESCAL.Margin = new System.Windows.Forms.Padding(4);
            this.trackYESCAL.Name = "trackYESCAL";
            this.trackYESCAL.Size = new System.Drawing.Size(139, 56);
            this.trackYESCAL.TabIndex = 20;
            // 
            // trackXESCAL
            // 
            this.trackXESCAL.BackColor = System.Drawing.Color.Silver;
            this.trackXESCAL.Location = new System.Drawing.Point(67, 332);
            this.trackXESCAL.Margin = new System.Windows.Forms.Padding(4);
            this.trackXESCAL.Name = "trackXESCAL";
            this.trackXESCAL.Size = new System.Drawing.Size(139, 56);
            this.trackXESCAL.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(35, 426);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 23);
            this.label4.TabIndex = 19;
            this.label4.Text = "Z";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(32, 378);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 23);
            this.label5.TabIndex = 18;
            this.label5.Text = "Y";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(32, 332);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 23);
            this.label6.TabIndex = 17;
            this.label6.Text = "X";
            // 
            // lblTranslacion
            // 
            this.lblTranslacion.AutoSize = true;
            this.lblTranslacion.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.lblTranslacion.Location = new System.Drawing.Point(8, 306);
            this.lblTranslacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTranslacion.Name = "lblTranslacion";
            this.lblTranslacion.Size = new System.Drawing.Size(133, 23);
            this.lblTranslacion.TabIndex = 16;
            this.lblTranslacion.Text = "Escalamiento";
            // 
            // trackZROT
            // 
            this.trackZROT.Location = new System.Drawing.Point(67, 252);
            this.trackZROT.Margin = new System.Windows.Forms.Padding(4);
            this.trackZROT.Name = "trackZROT";
            this.trackZROT.Size = new System.Drawing.Size(139, 56);
            this.trackZROT.TabIndex = 14;
            // 
            // trackYROT
            // 
            this.trackYROT.Location = new System.Drawing.Point(67, 204);
            this.trackYROT.Margin = new System.Windows.Forms.Padding(4);
            this.trackYROT.Name = "trackYROT";
            this.trackYROT.Size = new System.Drawing.Size(139, 56);
            this.trackYROT.TabIndex = 13;
            // 
            // trackXROT
            // 
            this.trackXROT.Location = new System.Drawing.Point(67, 159);
            this.trackXROT.Margin = new System.Windows.Forms.Padding(4);
            this.trackXROT.Name = "trackXROT";
            this.trackXROT.Size = new System.Drawing.Size(139, 56);
            this.trackXROT.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(35, 252);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 23);
            this.label1.TabIndex = 12;
            this.label1.Text = "Z";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(32, 204);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 23);
            this.label2.TabIndex = 11;
            this.label2.Text = "Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(32, 159);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 23);
            this.label3.TabIndex = 10;
            this.label3.Text = "X";
            // 
            // lblRotación
            // 
            this.lblRotación.AutoSize = true;
            this.lblRotación.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.lblRotación.Location = new System.Drawing.Point(8, 133);
            this.lblRotación.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRotación.Name = "lblRotación";
            this.lblRotación.Size = new System.Drawing.Size(90, 23);
            this.lblRotación.TabIndex = 6;
            this.lblRotación.Text = "Rotación";
            // 
            // lblZ
            // 
            this.lblZ.AutoSize = true;
            this.lblZ.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.lblZ.Location = new System.Drawing.Point(33, 97);
            this.lblZ.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblZ.Name = "lblZ";
            this.lblZ.Size = new System.Drawing.Size(21, 23);
            this.lblZ.TabIndex = 5;
            this.lblZ.Text = "Z";
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.lblY.Location = new System.Drawing.Point(33, 66);
            this.lblY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(22, 23);
            this.lblY.TabIndex = 4;
            this.lblY.Text = "Y";
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.lblX.Location = new System.Drawing.Point(33, 36);
            this.lblX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(22, 23);
            this.lblX.TabIndex = 3;
            this.lblX.Text = "X";
            // 
            // numZPosicion
            // 
            this.numZPosicion.Location = new System.Drawing.Point(67, 100);
            this.numZPosicion.Margin = new System.Windows.Forms.Padding(4);
            this.numZPosicion.Name = "numZPosicion";
            this.numZPosicion.Size = new System.Drawing.Size(68, 22);
            this.numZPosicion.TabIndex = 2;
            // 
            // numYPosicion
            // 
            this.numYPosicion.Location = new System.Drawing.Point(67, 66);
            this.numYPosicion.Margin = new System.Windows.Forms.Padding(4);
            this.numYPosicion.Name = "numYPosicion";
            this.numYPosicion.Size = new System.Drawing.Size(68, 22);
            this.numYPosicion.TabIndex = 1;
            // 
            // lblPosicion
            // 
            this.lblPosicion.AutoSize = true;
            this.lblPosicion.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.lblPosicion.Location = new System.Drawing.Point(8, 4);
            this.lblPosicion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPosicion.Name = "lblPosicion";
            this.lblPosicion.Size = new System.Drawing.Size(118, 23);
            this.lblPosicion.TabIndex = 0;
            this.lblPosicion.Text = "Translación";
            // 
            // numXPosicion
            // 
            this.numXPosicion.Location = new System.Drawing.Point(67, 36);
            this.numXPosicion.Margin = new System.Windows.Forms.Padding(4);
            this.numXPosicion.Name = "numXPosicion";
            this.numXPosicion.Size = new System.Drawing.Size(68, 22);
            this.numXPosicion.TabIndex = 0;
            // 
            // pnlListBox
            // 
            this.pnlListBox.BackColor = System.Drawing.Color.Silver;
            this.pnlListBox.Controls.Add(this.boxFiguras);
            this.pnlListBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlListBox.Location = new System.Drawing.Point(0, 0);
            this.pnlListBox.Margin = new System.Windows.Forms.Padding(4);
            this.pnlListBox.Name = "pnlListBox";
            this.pnlListBox.Size = new System.Drawing.Size(221, 166);
            this.pnlListBox.TabIndex = 0;
            // 
            // boxFiguras
            // 
            this.boxFiguras.BackColor = System.Drawing.Color.Silver;
            this.boxFiguras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.boxFiguras.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxFiguras.FormattingEnabled = true;
            this.boxFiguras.ItemHeight = 23;
            this.boxFiguras.Location = new System.Drawing.Point(0, 0);
            this.boxFiguras.Margin = new System.Windows.Forms.Padding(4);
            this.boxFiguras.Name = "boxFiguras";
            this.boxFiguras.Size = new System.Drawing.Size(221, 166);
            this.boxFiguras.TabIndex = 5;
            // 
            // glControlWindow
            // 
            this.glControlWindow.BackColor = System.Drawing.Color.Black;
            this.glControlWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glControlWindow.Location = new System.Drawing.Point(156, 114);
            this.glControlWindow.Margin = new System.Windows.Forms.Padding(5);
            this.glControlWindow.Name = "glControlWindow";
            this.glControlWindow.Size = new System.Drawing.Size(1196, 652);
            this.glControlWindow.TabIndex = 5;
            this.glControlWindow.VSync = false;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1573, 809);
            this.Controls.Add(this.glControlWindow);
            this.Controls.Add(this.pnlSliders);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Home";
            this.Text = "Blender 2";
            this.Load += new System.EventHandler(this.Home_Load);
            this.pnlLayout.ResumeLayout(false);
            this.pnlLayout.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEsfera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturePrismaRectang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCilindro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCono)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCubo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturePiramide)).EndInit();
            this.pnlSliders.ResumeLayout(false);
            this.panelTransfo.ResumeLayout(false);
            this.panelTransfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackZESCAL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackYESCAL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackXESCAL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackZROT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackYROT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackXROT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numZPosicion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYPosicion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numXPosicion)).EndInit();
            this.pnlListBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLayout;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlSliders;
        private System.Windows.Forms.PictureBox picturePiramide;
        private System.Windows.Forms.PictureBox picturePrismaRectang;
        private System.Windows.Forms.PictureBox pictureCilindro;
        private System.Windows.Forms.PictureBox pictureCono;
        private System.Windows.Forms.PictureBox pictureCubo;
        private System.Windows.Forms.Label lblFiguras;
        private System.Windows.Forms.PictureBox pictureEsfera;
        private System.Windows.Forms.Button btnResetear;
        private System.Windows.Forms.Panel pnlListBox;
        private System.Windows.Forms.NumericUpDown numXPosicion;
        private System.Windows.Forms.TrackBar trackXROT;
        private System.Windows.Forms.Panel panelTransfo;
        private System.Windows.Forms.NumericUpDown numZPosicion;
        private System.Windows.Forms.NumericUpDown numYPosicion;
        private System.Windows.Forms.Label lblPosicion;
        private System.Windows.Forms.Label lblZ;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRotación;
        private System.Windows.Forms.TrackBar trackZROT;
        private System.Windows.Forms.TrackBar trackYROT;
        private System.Windows.Forms.TrackBar trackZESCAL;
        private System.Windows.Forms.TrackBar trackYESCAL;
        private System.Windows.Forms.TrackBar trackXESCAL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTranslacion;
        private System.Windows.Forms.ComboBox comboColor;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.ComboBox comboCamara;
        private System.Windows.Forms.Label lblCamera;
        private System.Windows.Forms.ListBox boxFiguras;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.ComboBox comboMaterial;
        private System.Windows.Forms.Label lblMaterial;
        private OpenTK.GLControl glControlWindow;
    }
}

