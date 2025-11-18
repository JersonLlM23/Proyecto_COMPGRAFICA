using ProyectoU1_CCLl;
using System;
using System.Drawing;
using System.Windows.Forms;

public partial class Figura3 : Form
{
    private static Figura3 instancia = null;
    public static Figura3 Instancia
    {
        get
        {
            if (instancia == null || instancia.IsDisposed)
                instancia = new Figura3();
            return instancia;
        }
    }

    private Figure3 figuraLogica = new Figure3();

    public Figura3()
    {
       
    }

    private void Figura3_Load(object sender, EventArgs e)
    {
 
    }

    private void btnGraficar3_Click(object sender, EventArgs e)
    {
 
    }

    private void InitializeComponent()
    {
            this.SuspendLayout();
            // 
            // Figura3
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "Figura3";
            this.Load += new System.EventHandler(this.Figura3_Load_1);
            this.ResumeLayout(false);

    }

    private void Figura3_Load_1(object sender, EventArgs e)
    {

    }
}