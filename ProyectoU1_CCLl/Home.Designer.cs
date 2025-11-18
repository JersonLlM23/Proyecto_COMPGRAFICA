namespace ProyectoU1_CCLl
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.figurasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.figuraNo1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.figuraNo2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.figuraNo3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.figuraNo4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.figuraNo5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.figuraNo6ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Chartreuse;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.figurasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // figurasToolStripMenuItem
            // 
            this.figurasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.figuraNo1ToolStripMenuItem,
            this.figuraNo2ToolStripMenuItem,
            this.figuraNo3ToolStripMenuItem,
            this.figuraNo4ToolStripMenuItem,
            this.figuraNo5ToolStripMenuItem,
            this.figuraNo6ToolStripMenuItem});
            this.figurasToolStripMenuItem.Name = "figurasToolStripMenuItem";
            this.figurasToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.figurasToolStripMenuItem.Text = "Figuras";
            // 
            // figuraNo1ToolStripMenuItem
            // 
            this.figuraNo1ToolStripMenuItem.Name = "figuraNo1ToolStripMenuItem";
            this.figuraNo1ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.figuraNo1ToolStripMenuItem.Text = "Figura No.1";
            this.figuraNo1ToolStripMenuItem.Click += new System.EventHandler(this.figuraNo1ToolStripMenuItem_Click);
            // 
            // figuraNo2ToolStripMenuItem
            // 
            this.figuraNo2ToolStripMenuItem.Name = "figuraNo2ToolStripMenuItem";
            this.figuraNo2ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.figuraNo2ToolStripMenuItem.Text = "Figura No.2";
            this.figuraNo2ToolStripMenuItem.Click += new System.EventHandler(this.figuraNo2ToolStripMenuItem_Click);
            // 
            // figuraNo3ToolStripMenuItem
            // 
            this.figuraNo3ToolStripMenuItem.Name = "figuraNo3ToolStripMenuItem";
            this.figuraNo3ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.figuraNo3ToolStripMenuItem.Text = "Figura No.3";
            this.figuraNo3ToolStripMenuItem.Click += new System.EventHandler(this.figuraNo3ToolStripMenuItem_Click);
            // 
            // figuraNo4ToolStripMenuItem
            // 
            this.figuraNo4ToolStripMenuItem.Name = "figuraNo4ToolStripMenuItem";
            this.figuraNo4ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.figuraNo4ToolStripMenuItem.Text = "Figura No.4";
            this.figuraNo4ToolStripMenuItem.Click += new System.EventHandler(this.figuraNo4ToolStripMenuItem_Click);
            // 
            // figuraNo5ToolStripMenuItem
            // 
            this.figuraNo5ToolStripMenuItem.Name = "figuraNo5ToolStripMenuItem";
            this.figuraNo5ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.figuraNo5ToolStripMenuItem.Text = "Figura No.5";
            this.figuraNo5ToolStripMenuItem.Click += new System.EventHandler(this.figuraNo5ToolStripMenuItem_Click);
            // 
            // figuraNo6ToolStripMenuItem
            // 
            this.figuraNo6ToolStripMenuItem.Name = "figuraNo6ToolStripMenuItem";
            this.figuraNo6ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.figuraNo6ToolStripMenuItem.Text = "Figura No.6";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Home";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem figurasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem figuraNo1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem figuraNo2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem figuraNo3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem figuraNo4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem figuraNo5ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem figuraNo6ToolStripMenuItem;
    }
}

