using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoU1_CCLl
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_load(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is MdiClient mdi)
                {
                    mdi.BackColor = Color.LightSteelBlue;
                }
            }
        }

        private void figuraNo1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(Figura1.Instancia);
        }

        private void OcultarFormulariosHijos()
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Hide();
            }
        }

        private void AbrirFormulario(Form frm)
        {
            OcultarFormulariosHijos();  

            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill; 
            frm.Show();
            frm.BringToFront();
        }

        private void figuraNo2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(Figura2.Instancia);
        }

        private void figuraNo3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
     
        }

        private void figuraNo4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(Figura4.Instancia);
        }

        private void figuraNo5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(Figura5.Instancia);
        }
    }
}
